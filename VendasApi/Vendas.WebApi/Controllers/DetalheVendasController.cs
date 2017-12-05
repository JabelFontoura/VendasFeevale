using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.WebApi.Controllers;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace VendasFeevale.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/DetalheVendas")]
    public class DetalheVendasController : Controller, IController<DetalheVenda>
    {
        private readonly IDetalheVendaRespository _detalheVendaRespository;

        public DetalheVendasController(IDetalheVendaRespository detalheVendaRespository)
        {
            _detalheVendaRespository = detalheVendaRespository;
        }

        [HttpPost]
        public IActionResult Add(DetalheVenda entity)
        {
            return Ok(_detalheVendaRespository.Save(entity));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _detalheVendaRespository.Delete(id);
            return Ok("Deletado com sucesso");
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_detalheVendaRespository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            return Ok(_detalheVendaRespository.FindById(id));
        }

        [HttpPut]
        public IActionResult Update(DetalheVenda entity)
        {
            return Ok(_detalheVendaRespository.Update(entity));
        }
    }
}