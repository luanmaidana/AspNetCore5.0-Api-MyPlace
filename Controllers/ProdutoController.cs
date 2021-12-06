using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Myplace.Data;
using MyPlace.Negocios;
using MyPlace.ViewModels;

namespace MyPlace.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProdutoController : ControllerBase{

        private readonly IProdutoRepository produtoRepository;
        private readonly IMapper mapper;
        public ProdutoController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            this.produtoRepository = produtoRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("produtos")]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> GetProdutos(){

            var produtos = mapper.Map<IEnumerable<ProdutoViewModel>>(await produtoRepository.ObterProdutosFornecedores());
            return Ok(produtos);

        }

        [HttpGet]
        [Route("produtos/{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> GetProdutoId(Guid id){

            var produto = mapper.Map<ProdutoViewModel>(await produtoRepository.ObterPorId(id));
            if(produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        [Route("produtos")]
        public async Task<ActionResult<ProdutoViewModel>> PostProduto(ProdutoViewModel produtoViewModel)
        {

            if(!ModelState.IsValid) return BadRequest();
            
            try
            {

                var imagemNome = Guid.NewGuid() + "_" + produtoViewModel.img;

                if(!UploadArquivo(produtoViewModel.imgUpload, imagemNome)){

                    return BadRequest();

                }

                produtoViewModel.img = imagemNome;
                var produto = mapper.Map<Produto>(produtoViewModel);
                await produtoRepository.Adicionar(produto);
                return Ok(produto);
            }
            catch (Exception e)
            {
                
                return BadRequest(e.ToString());
            }
        }

        private bool UploadArquivo(string arquivo, string imgNome){

            var imgDataByteArray = Convert.FromBase64String(arquivo);

            if(string.IsNullOrEmpty(arquivo)){

                ModelState.AddModelError(string.Empty, "Forneça uma imagem para este produto!");

                return false;
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgNome);

            if(System.IO.File.Exists(filePath)){

                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");

                return false;

            }

            System.IO.File.WriteAllBytes(filePath, imgDataByteArray);

            return true;
        }

        [HttpPut]
        [Route("produtos/{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> PutProduto(Guid id, ProdutoViewModel produtoViewModel){

            if(id.GetType() != produtoViewModel.id.GetType()) return BadRequest("Valor inválido");

            var produto = await produtoRepository.ObterPorId(id);
            
            if(produto == null) return NotFound();
            if(!ModelState.IsValid) return BadRequest();

            try
            {
                 produto.nome = produtoViewModel.nome;
                 produto.descricao = produtoViewModel.descricao;
                 produto.img = produtoViewModel.img;
                 produto.ativo = produtoViewModel.ativo;
                 produto.valor = produtoViewModel.valor;

                 await produtoRepository.Atualizar(produto);

                 return Created("v1/produtos/{produto.id}", produto);
            }
            catch (Exception e)
            {
                
               return BadRequest(e.ToString());
            }


        }

        [HttpDelete]
        [Route("produtos/{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> DeleteProduto(Guid id){

            var produto = await GetProdutoId(id);
            
            try
            {
                 if(produto == null) return NotFound();
                 await produtoRepository.Remover(id);

                 return Ok();
            }
            catch (Exception e)
            {
                
                return BadRequest(e.ToString());
            }

            

        }

    }
}