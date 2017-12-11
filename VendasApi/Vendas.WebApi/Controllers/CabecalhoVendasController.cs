using Microsoft.AspNetCore.Mvc;
using Vendas.Infrastructure.Entity;
using Microsoft.AspNetCore.Authorization;
using Vendas.Infrastructure.Repository.Interfaces;
using Vendas.Infrastructure.Entities.Enums;

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
            if (ModelState.IsValid)
                return Ok(_cabecalhoVendaRepository.Save(entity));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                _cabecalhoVendaRepository.Delete(id);
                return Ok(new { data = "Deletado" });
            }
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_cabecalhoVendaRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            if (ModelState.IsValid)
                return Ok(_cabecalhoVendaRepository.FindById(id));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpGet("usuario/{id}")]
        public IActionResult FindByIdUsuario(string id)
        {
            if (ModelState.IsValid)
                return Ok(_cabecalhoVendaRepository.FindByIdUsuario(id));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpGet("usuario/{id}/pendente")]
        public IActionResult FindByIdUsuarioAndPendente(string id)
        {
            if (ModelState.IsValid)
                return Ok(_cabecalhoVendaRepository.FindByIdUsuarioAndStatus(id, Situacao.Pendente));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpGet("usuario/{id}/aprovado")]
        public IActionResult FindByIdUsuarioAndAprovado(string id)
        {
            if (ModelState.IsValid)
                return Ok(_cabecalhoVendaRepository.FindByIdUsuarioAndStatus(id, Situacao.Aprovado));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpGet("usuario/{id}/reprovado")]
        public IActionResult FindByIdUsuarioAndReprovado(string id)
        {
            if (ModelState.IsValid)
                return Ok(_cabecalhoVendaRepository.FindByIdUsuarioAndStatus(id, Situacao.Reprovado));
            else
                return BadRequest(new { error = "Request inválido" });
        }

        [HttpPut]
        public IActionResult Update([FromBody]CabecalhoVenda entity)
        {
            if (ModelState.IsValid)
                return Ok(_cabecalhoVendaRepository.Update(entity));
            else
                return BadRequest(new { error = "Request inválido" });
        }
    }
}