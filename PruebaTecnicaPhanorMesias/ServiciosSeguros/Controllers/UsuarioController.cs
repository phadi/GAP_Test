using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiciosSeguros.Models;
using ServiciosSeguros.Repositoios;
using ServiciosSeguros.Seguridad;

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
                Encripta enc = new Encripta();                
                string desc = enc.EncriptaStr(psw);
                var usuario = await repositorioUsuario.GetUsuario(login, desc);
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

        [HttpGet]
        [Route("GetPermisos")]
        public async Task<IActionResult> GetPermisos(int rolId)
        {
            try
            {
                var permisos = await repositorioUsuario.GetPermisos(rolId);                

                return Ok(permisos);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}