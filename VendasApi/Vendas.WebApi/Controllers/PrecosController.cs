using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Precos")]
    [Authorize("Bearer")]
    public class PrecosController : ControllerBase, IController<Preco>
    {
        private readonly IPrecoRepository _precoRepository;

        public PrecosController(IPrecoRepository precoRepository)
        {
            _precoRepository = precoRepository;
        }
        [Authorize("Bearer", Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody]Preco entity)
        {
            if (ModelState.IsValid)
                return Ok(_precoRepository.Save(entity));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                _precoRepository.Delete(id);
                return Ok(new { data = "Deletado" });

            }
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_precoRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            if (ModelState.IsValid)
                return Ok(_precoRepository.FindById(id));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody]Preco entity)
        {
            if (ModelState.IsValid)
                return Ok(_precoRepository.Update(entity));
            else
                return BadRequest(new { error = "Request inválido" });
        }
    }
}
