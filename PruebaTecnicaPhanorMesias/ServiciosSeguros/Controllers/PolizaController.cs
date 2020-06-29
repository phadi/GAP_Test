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
        [Route("GetPoliza")]
        public async Task<IActionResult> GetPoliza(int polizaId)
        {
            try
            {
                var poliza = await repositorioPoliza.GetPoliza(polizaId);
                return Ok(poliza);
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
                var polizas = await repositorioPoliza.GetPolizas();
                if (polizas == null)
                {
                    return NotFound();
                }

                return Ok(polizas);
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
                    var polizaId = await repositorioPoliza.AddPoliza(model);
                    if (polizaId > 0)
                    {
                        return Ok(polizaId);
                    }
                    else
                    {
                        return Ok(0);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("Reglas Invalidas: "))
                    {
                        return BadRequest();
                    }
                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("UpdatePoliza")]
        public async Task<IActionResult> UpdatePoliza(TbPoliza model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repositorioPoliza.UpdatePoliza(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("Reglas Invalidas: "))
                    {
                        throw ex;
                    }

                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("DeletePoliza")]
        public async Task<IActionResult> DeletePoliza(TbPoliza model)
        {
            int result = 0;

            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                result = await repositorioPoliza.DeletePoliza(model.PolizaId);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}