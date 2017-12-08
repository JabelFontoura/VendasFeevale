using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.WebApi.Controllers;
using Vendas.Infrastructure.Entity;
using Microsoft.AspNetCore.Authorization;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.WebApi.Controllers
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
        public IActionResult Add([FromBody]CabecalhoVenda entity)
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
        public IActionResult Update([FromBody]CabecalhoVenda entity)
        {
            return Ok(_cabecalhoVendaRepository.Update(entity));
        }
    }
}