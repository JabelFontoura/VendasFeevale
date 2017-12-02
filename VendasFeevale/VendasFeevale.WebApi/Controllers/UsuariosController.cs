﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VendasFeevale.Infrastructure.Entity;
using VendasFeevale.Infrastructure.Repository.Interfaces;

namespace VendasFeevale_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize("Bearer", Roles = "Admin")]
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
            return Ok(_usuarioRepository.Save(usuario));
        }

        [HttpDelete]
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

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_usuarioRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            return Ok(_usuarioRepository.FindById(id));
        }

        [HttpPut]
        public IActionResult Update(Usuario entity)
        {
            return Ok(_usuarioRepository.Update(entity));
        }
    }
}