using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiciosSeguros.Models;
using ServiciosSeguros.Repositoios;

namespace ServiciosSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IRepositorioUsuario repositorioUsuario;

        public UsuarioController(IRepositorioUsuario _repositorioUsuario)
        {
            repositorioUsuario = _repositorioUsuario;
        }

        [HttpGet]
        [Route("GetUsuarios")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                var usuarios = await repositorioUsuario.GetUsuarios();
                if (usuarios == null)
                {
                    return NotFound();
                }

                return Ok(usuarios);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetUsuario")]
        public async Task<IActionResult> GetUsuario(string login, string psw)
        {
            try
            {
                var usuario = await repositorioUsuario.GetUsuario(login,psw);
                //if (usuario == null)
                //{
                //   return NotFound();
                //}

                return Ok(usuario);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("AddUsuario")]
        public async Task<IActionResult> AddUsuario(TbUsuario model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioId = await repositorioUsuario.AddUser(model);
                    if (usuarioId > 0)
                    {
                        return Ok(usuarioId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }
    }
}