using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPlace.Negocios;
using MyPlace.ViewModels;
using Newtonsoft.Json;

namespace MyPlace.Controllers
{
    [ApiController]
    [Route("v1")]
    public class FornecedorController : ControllerBase{

        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;
        public FornecedorController(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [Route("fornecedores")]
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> GetFornecedores(){

            var fornecedores = mapper.Map<IEnumerable<FornecedorViewModel>>(await fornecedorRepository.ObterTodos());
            return Ok(fornecedores);

        }

        
        [HttpGet]
        [Route("fornecedores/{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> GetFornecedorId(Guid id){

             var fornecedor = mapper.Map<FornecedorViewModel>(await fornecedorRepository.ObterFornecedorProdutosEndereco(id));
            if(fornecedor == null) return NotFound();
            return Ok(fornecedor);
        }

        [HttpPost]
        [Route("fornecedores")]
        public async Task<ActionResult<FornecedorViewModel>> PostFornecedor(FornecedorViewModel fornecedorViewModel){

            if(!ModelState.IsValid) return BadRequest();
            
            var fornecedor = mapper.Map<Fornecedor>(fornecedorViewModel);
            await fornecedorRepository.Adicionar(fornecedor);
            return Ok(fornecedor);
        }

        [HttpPut]
        [Route("fornecedores/{id}")]
        public async Task<ActionResult<FornecedorViewModel>> PutFornecedor(Guid id, FornecedorViewModel fornecedorViewModel){

            if(id.GetType() != fornecedorViewModel.id.GetType()) return BadRequest("Valor inválido");
            
            var fornecedor = await fornecedorRepository.ObterPorId(id);
            
            if(fornecedor == null){
                Console.WriteLine(fornecedor.id);
                return NotFound();
            } 
            if(!ModelState.IsValid) return BadRequest();

            try
            {
                 
                 fornecedor.nome = fornecedorViewModel.nome;
                 fornecedor.documento = fornecedorViewModel.documento;
                 fornecedor.ativo = fornecedorViewModel.ativo;

                 await fornecedorRepository.Atualizar(fornecedor);

                 return Created("v1/fornecedores/{fornecedor.id}", fornecedor);
            }
            catch (Exception e)
            {
                
               return BadRequest(e.ToString());
            }


        }

        [HttpDelete]
        [Route("fornecedores/{id}")]
        public async Task<ActionResult<FornecedorViewModel>> DeleteFornecedor(Guid id){

            var fornecedor = await GetFornecedorId(id);
            
            try
            {
                 if(fornecedor == null) return NotFound();
                 await fornecedorRepository.Remover(id);

                 return Ok();
            }
            catch (Exception e)
            {
                
                return BadRequest(e.ToString());
            }

        }

    }
}