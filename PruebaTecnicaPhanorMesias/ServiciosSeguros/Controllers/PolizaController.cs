using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiciosSeguros.Models;
using ServiciosSeguros.Repositoios;

namespace ServiciosSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaController : ControllerBase
    {
        IRepositorioPoliza repositorioPoliza;

        public PolizaController(IRepositorioPoliza _repositorioPoliza)
        {
            repositorioPoliza = _repositorioPoliza;
        }

        [HttpGet]
        [Route("GetTipoCubrimiento")]
        public async Task<IActionResult> GetTipoCubrimiento()
        {
            try
            {
                var cubrimiento = await repositorioPoliza.GetTipoCubrimiento();
                if (cubrimiento == null)
                {
                    return NotFound();
                }

                return Ok(cubrimiento);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetTipoRiesgo")]
        public async Task<IActionResult> GetTipoRiesgo()
        {
            try
            {
                var riesgos = await repositorioPoliza.GetTipoRiesgo();
                if (riesgos == null)
                {
                    return NotFound();
                }

                return Ok(riesgos);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetPolizas")]
        public async Task<IActionResult> GetPolizas()
        {
            try
            {
                var usuarios = await repositorioPoliza.GetPolizas();
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

        [HttpPost]
        [Route("AddPoliza")]
        public async Task<IActionResult> AddPoliza(TbPoliza model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioId = await repositorioPoliza.AddUser(model);
                    if (usuarioId > 0)
                    {
                        return Ok(usuarioId);
                    }
                    else
                    {
                        return Ok(0);
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