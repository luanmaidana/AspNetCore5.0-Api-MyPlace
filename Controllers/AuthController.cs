using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;
using static MyPlace.ViewModels.UserViewModels;
using System.Threading.Tasks;

namespace MyPlace.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AuthController : ControllerBase {

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

        }

        [HttpPost("cadastrar-usuario")]
        public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro){

            if(!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, usuarioRegistro.Senha);

            if(result.Succeeded){
                await signInManager.SignInAsync(user, false);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UsuarioRegistro usuarioLogin){

            if(!ModelState.IsValid) return BadRequest();

            var result = await signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);

            if(result.Succeeded){
                return Ok();
            }

            return BadRequest();
        }

    }
}