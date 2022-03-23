using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;
using static MyPlace.ViewModels.UserViewModels;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using MyPlace.Extensions;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace MyPlace.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AuthController : MainController {

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly AppSettings appSettings;

        public AuthController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.appSettings = appSettings.Value;

        }

        [HttpPost("cadastrar-usuario")]
        public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro){

            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, usuarioRegistro.Senha);

            if(result.Succeeded){

                return CustomResponse(await GerarJwt(usuarioRegistro.Email));
            }

            foreach( var error in result.Errors){
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin){

            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);

            if(result.Succeeded){
                return CustomResponse(await GerarJwt(usuarioLogin.Email));
            }

            if(result.IsLockedOut){
                AdicionarErroProcessamento("Usuário temporariamente bloqueado por tentativas inválidas!");
                return CustomResponse();
            }

            AdicionarErroProcessamento("Usuário ou Senha incorretos!");
            return CustomResponse();
        }

        private async Task<UsuarioRespostaLogin> GerarJwt(string email){

            var user = await userManager.FindByEmailAsync(email);
            var claims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles){
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor{

                Issuer = appSettings.Emissor,
                Audience = appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new UsuarioRespostaLogin{
                AccessToken = encodedToken
                // ExpiresIn = TimeSpan.FromHours(appSettings.ExpiracaoHoras).TotalSeconds,
                // UsuarioToken = new UsuarioToken{
                //     Id = user.Id,
                //     Email = user.Email,
                //     Claims = claims.Select(c => new UsuarioClaim {Type = c.Type, Value = c.Value})
                // }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime data) 
            => (long)Math.Round((data.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    }
}