using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Produtos")]
    public class ProdutosController : Controller, IController<Produto>
    {
        private readonly IProdutoRepository _produtoRepository;
        
        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [Authorize("Bearer", Roles = "Admin, Comum")]
        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_produtoRepository.FindAll());
        }

        [Authorize("Bearer", Roles = "Admin, Comum")]
        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            if (ModelState.IsValid)
                return Ok(_produtoRepository.FindById(id));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [Authorize("Bearer", Roles = "Admin, Comum")]
        [HttpGet("categoria/{id}")]
        public IActionResult FindByIdCategoria(string id)
        {
            if (ModelState.IsValid)
                return Ok(_produtoRepository.FindByIdCategoria(id));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody]Produto produto)
        {
            if (ModelState.IsValid)
                return Ok(_produtoRepository.Save(produto));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody]Produto produto)
        {
            if (ModelState.IsValid)
                return Ok(_produtoRepository.Update(produto));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                _produtoRepository.Delete(id);
                return Ok(new { data = "Deletado" });
            }
            else
                return BadRequest(new { error = "Request inválido" });
        }
    }
}