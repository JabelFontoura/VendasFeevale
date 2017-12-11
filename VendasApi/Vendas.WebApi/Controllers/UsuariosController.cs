using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class UsuariosController : Controller, IController<Usuario>
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Add([FromBody]Usuario usuario)
        {
            if (ModelState.IsValid)
                return Ok(_usuarioRepository.Save(usuario));
            else
                return BadRequest(new { error = "Request Inválido" });
        }

        [Authorize("Bearer", Roles = "Admin, Comum")]
        [HttpGet("[action]/{login}")]
        public IActionResult Verify(string login)
        {
            if (ModelState.IsValid)
                return Ok(_usuarioRepository.FindByLogin(login));
            else
                return BadRequest(new { error = "Request Inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepository.Delete(id);
                return Ok(new { data = "Deletado" });
            }
            else
            {
                return BadRequest(new { error = "Request Inválido" });
            }
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_usuarioRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            if (ModelState.IsValid)
                return Ok(_usuarioRepository.FindById(id));
            else
                return BadRequest(new { error = "Request Inválido" });
        }

        [Authorize("Bearer", Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody]Usuario entity)
        {
            if (ModelState.IsValid)
                return Ok(_usuarioRepository.Update(entity));
            else
                return BadRequest(new { error = "Request Inválido" });
        }
    }
}