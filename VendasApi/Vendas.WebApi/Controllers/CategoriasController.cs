using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.WebApi.Controllers;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace VendasFeevale.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Categorias")]
    [Authorize("Bearer")]
    public class CategoriasController : Controller, IController<Categoria>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody]Categoria entity)
        {
            if (ModelState.IsValid)
                return Ok(_categoriaRepository.Save(entity));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Delete(id);
                return Ok(new { data = "Deletado" });
            }
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_categoriaRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            if (ModelState.IsValid)
                return Ok(_categoriaRepository.FindById(id));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody]Categoria entity)
        {
            if (ModelState.IsValid)
                return Ok(_categoriaRepository.Update(entity));
            else
                return BadRequest(new { error = "Request inválido" });
        }
    }
}