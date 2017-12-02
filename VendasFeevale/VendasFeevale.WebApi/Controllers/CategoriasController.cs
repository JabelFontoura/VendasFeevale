using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasFeevale_WebApi.Controllers;
using VendasFeevale.Infrastructure.Entity;
using VendasFeevale.Infrastructure.Repository.Interfaces;

namespace VendasFeevale.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Categorias")]
    public class CategoriasController : Controller, IController<Categoria>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost]
        public IActionResult Add(Categoria entity)
        {
            return Ok(_categoriaRepository.Save(entity));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _categoriaRepository.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_categoriaRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            return Ok(_categoriaRepository.FindById(id));
        }

        [HttpPut]
        public IActionResult Update(Categoria entity)
        {
            return Ok(_categoriaRepository.Update(entity));
        }
    }
}