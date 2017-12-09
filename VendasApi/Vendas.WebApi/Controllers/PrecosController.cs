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

        [HttpPost]
        public IActionResult Add([FromBody]Preco entity)
        {
            return Ok(_precoRepository.Save(entity));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _precoRepository.Delete(id);
            return Ok(new { data = "Deletado" });
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_precoRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            return Ok(_precoRepository.FindById(id));
        }

        [HttpPut]
        public IActionResult Update([FromBody]Preco entity)
        {
            return Ok(_precoRepository.Update(entity));
        }
    }
}
