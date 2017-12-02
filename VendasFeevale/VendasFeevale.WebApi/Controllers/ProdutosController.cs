using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendasFeevale.Infrastructure.Entity;
using VendasFeevale.Infrastructure.Repository.Interfaces;

namespace VendasFeevale_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Produtos")]
    [Authorize("Bearer", Roles = "Admin")]
    public class ProdutosController : Controller, IController<Produto>
    {
        private readonly IProdutoRepository _produtoRepository;
        
        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet("[action]")]
        public IActionResult FindAll()
        {
            return Ok(_produtoRepository.FindAll());
        }

        [HttpGet("[action]/{id}")]
        public IActionResult FindById(string id)
        {
            return Ok(_produtoRepository.FindById(id));
        }

        [HttpPost("[action]")]
        public IActionResult Add(Produto produto)
        {
            return Ok(_produtoRepository.Save(produto));
        }

        [HttpPut("[action]")]
        public IActionResult Update(Produto produto)
        {
            return Ok(_produtoRepository.Update(produto));
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(string id)
        {
            _produtoRepository.Delete(id);
            return Ok();
        }
    }
}