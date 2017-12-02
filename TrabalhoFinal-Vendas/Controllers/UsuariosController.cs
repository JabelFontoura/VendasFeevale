using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TrabalhoFinal_Vendas.Infrastructure.Entity;
using TrabalhoFinal_Vendas.Infrastructure.Repository.Interfaces;
using TrabalhoFinal_Vendas.Auth;
using TrabalhoFinal_Vendas.Token;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace TrabalhoFinal_Vendas.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuarios")]
    [Authorize("Bearer", Roles = "Admin")]
    public class UsuariosController : Controller, IController<Usuario>
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult Add([FromBody]Usuario usuario)
        {
            return Ok(_usuarioRepository.Save(usuario));
        }

        public IActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                _usuarioRepository.Delete(id);
                return Ok($"{id} detelado.");
            }
            else
            {
                return NotFound($"{id} não encontrado.");
            }
        }

        [HttpGet("[action]")]
        public IActionResult FindAll()
        {
            return Ok(_usuarioRepository.FindAll());
        }

        [HttpGet("[action]")]
        public IActionResult FindById(string id)
        {
            return Ok(_usuarioRepository.FindById(id));
        }

        [HttpGet("[action]")]
        public IActionResult Update(Usuario entity)
        {
            return Ok(_usuarioRepository.Update(entity));
        }
    }
}