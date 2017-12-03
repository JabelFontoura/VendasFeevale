using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendasFeevale.Infrastructure.Entity;
using VendasFeevale.Infrastructure.Repository.Interfaces;

namespace VendasFeevale_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Produtos")]
    [Authorize("Bearer")]
    public class ProdutosController : Controller, IController<Produto>
    {
        private readonly IProdutoRepository _produtoRepository;
        
        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_produtoRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            return Ok(_produtoRepository.FindById(id));
        }

        [HttpGet("categoria/{id}")]
        public IActionResult Find(string id)
        {
            return Ok(_produtoRepository.FindByIdCategoria(id));
        }

        [HttpPost]
        public IActionResult Add(Produto produto)
        {
            return Ok(_produtoRepository.Save(produto));
        }

        [HttpPut]
        public IActionResult Update(Produto produto)
        {
            return Ok(_produtoRepository.Update(produto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _produtoRepository.Delete(id);
            return Ok();
        }
    }
}