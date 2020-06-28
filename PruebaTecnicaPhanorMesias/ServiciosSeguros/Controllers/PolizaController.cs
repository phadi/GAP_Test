using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}