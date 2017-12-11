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
    [Route("api/DetalheVendas")]
    [Authorize("Bearer")]
    public class DetalheVendasController : Controller, IController<DetalheVenda>
    {
        private readonly IDetalheVendaRespository _detalheVendaRespository;

        public DetalheVendasController(IDetalheVendaRespository detalheVendaRespository)
        {
            _detalheVendaRespository = detalheVendaRespository;
        }

        [HttpPost]
        public IActionResult Add([FromBody]DetalheVenda entity)
        {
            if (ModelState.IsValid)
                return Ok(_detalheVendaRespository.Save(entity));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                _detalheVendaRespository.Delete(id);
                return Ok(new { data = "Deletado" });
            }
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_detalheVendaRespository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            if (ModelState.IsValid)
                return Ok(_detalheVendaRespository.FindById(id));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpGet("cabecalhoVenda/{id}")]
        public IActionResult FindByIdCabecalhoVenda(string id)
        {
            var teste = _detalheVendaRespository.FindByIdCabecalhoVenda(id);
            if (ModelState.IsValid)
                return Ok(_detalheVendaRespository.FindByIdCabecalhoVenda(id));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpPut]
        public IActionResult Update([FromBody]DetalheVenda entity)
        {
            if (ModelState.IsValid)
                return Ok(_detalheVendaRespository.Update(entity));
            else
                return BadRequest(new { error = "Request inválido" });
        }
    }
}