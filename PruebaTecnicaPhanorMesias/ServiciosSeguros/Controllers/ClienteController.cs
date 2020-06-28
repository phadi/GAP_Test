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
    public class ClienteController : ControllerBase
    {
        IRepositorioCliente repositorioCLiente;

        public ClienteController(IRepositorioCliente _repositorioCLiente)
        {
            repositorioCLiente = _repositorioCLiente;
        }

        [HttpPost]
        [Route("AddCliente")]
        public async Task<IActionResult> AddCliente(TbCliente model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var clienteId = await repositorioCLiente.AddCliente(model);
                    if (clienteId > 0)
                    {
                        return Ok(clienteId);
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

        [HttpPost]
        [Route("DeleteCliente")]
        public async Task<IActionResult> DeleteCliente(TbCliente model)
        {
            int result = 0;

            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                result = await repositorioCLiente.DeleteCliente(model.ClienteId);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetCliente")]
        public async Task<IActionResult> GetCliente(int clienteId)
        {
            try
            {
                var cliente = await repositorioCLiente.GetCliente(clienteId);
                return Ok(cliente);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetClientes")]
        public async Task<IActionResult> GetClientes()
        {
            try
            {
                var clientes = await repositorioCLiente.GetClientes();
                if (clientes == null)
                {
                    return NotFound();
                }

                return Ok(clientes);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetTipoDoc")]
        public async Task<IActionResult> GetTipoDoc()
        {
            try
            {
                var tipos = await repositorioCLiente.GetTipoDoc();
                if (tipos == null)
                {
                    return NotFound();
                }

                return Ok(tipos);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("UpdateCliente")]
        public async Task<IActionResult> UpdateCliente(TbCliente model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repositorioCLiente.UpdateCliente(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}