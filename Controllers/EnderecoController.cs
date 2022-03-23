using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPlace.Data;
using MyPlace.Negocios;
using MyPlace.ViewModels;

namespace MyPlace.Controllers
{
    [ApiController]
    [Route("v1")]
    public class EnderecoController : MainController{

        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper mapper;
        public EnderecoController(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("enderecos")]
        public async Task<ActionResult<IEnumerable<EnderecoViewModel>>> GetEnderecos(){

            var enderecos = mapper.Map<IEnumerable<EnderecoViewModel>>(await _enderecoRepository.ObterTodos());
            return Ok(enderecos);

        }

        [HttpGet]
        [Route("enderecos/{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> GetEnderecoId(Guid id){

            var endereco = mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterPorId(id));
            if(endereco == null) return NotFound();
            return Ok(endereco);
        }

        [HttpPost]
        [Route("enderecos")]
        public async Task<ActionResult<EnderecoViewModel>> PostEndereco(EnderecoViewModel enderecoViewModel){

            if(!ModelState.IsValid) return BadRequest();
            
            var endereco = mapper.Map<Endereco>(enderecoViewModel);
            await _enderecoRepository.Adicionar(endereco);
            return Ok(endereco);
        }

        [HttpPut]
        [Route("enderecos/{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> PutEndereco(Guid id, EnderecoViewModel enderecoViewModel){

            if(id.GetType() != enderecoViewModel.id.GetType()) return BadRequest("Valor inválido");

            var endereco = await _enderecoRepository.ObterPorId(id);
            
            if(endereco == null) return NotFound();
            if(!ModelState.IsValid) return BadRequest();

            try
            {
                 endereco.logradouro = enderecoViewModel.logradouro;
                 endereco.numero = enderecoViewModel.numero;
                 endereco.bairro = enderecoViewModel.bairro;
                 endereco.cep = enderecoViewModel.cep;
                 endereco.cidade = enderecoViewModel.cidade;
                 endereco.complemento = enderecoViewModel.complemento;
                 endereco.fornecedorId = enderecoViewModel.fornecedorId;

                 await _enderecoRepository.Atualizar(endereco);

                 return Created("v1/enderecos/{endereco.id}", endereco);
            }
            catch (Exception e)
            {
                
               return BadRequest(e.ToString());
            }


        }

        [HttpDelete]
        [Route("enderecos/{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> DeleteEndereco(Guid id){

            var endereco = await GetEnderecoId(id);
            
            try
            {
                 if(endereco == null) return NotFound();
                 if(!ModelState.IsValid) return BadRequest();
                 await _enderecoRepository.Remover(id);
                 await _enderecoRepository.SaveChanges();
                 return Ok();
            }
            catch (Exception e)
            {
                
                return BadRequest(e.ToString());
            }

        }

    }
}