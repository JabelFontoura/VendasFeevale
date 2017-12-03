using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasFeevale_WebApi.Controllers;
using VendasFeevale.Infrastructure.Entity;
using Microsoft.AspNetCore.Authorization;
using VendasFeevale.Infrastructure.Repository.Interfaces;

namespace VendasFeevale.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/cabecalhoVendas")]
    [Authorize("Bearer")]
    public class CabecalhoVendasController : Controller, IController<CabecalhoVenda>
    {
        private readonly ICabecalhoVendaRepository _cabecalhoVendaRepository;

        public CabecalhoVendasController(ICabecalhoVendaRepository cabecalhoVendaRepository)
        {
            _cabecalhoVendaRepository = cabecalhoVendaRepository;
        }

        [HttpPost]
        public IActionResult Add(CabecalhoVenda entity)
        {
            return Ok(_cabecalhoVendaRepository.Save(entity));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _cabecalhoVendaRepository.Delete(id);
            return Ok("Deletado com sucesso");
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_cabecalhoVendaRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            return Ok(_cabecalhoVendaRepository.FindById(id));
        }

        [HttpPut]
        public IActionResult Update(CabecalhoVenda entity)
        {
            return Ok(_cabecalhoVendaRepository.Update(entity));
        }
    }
}