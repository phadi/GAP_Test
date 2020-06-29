using Microsoft.EntityFrameworkCore;
using ServiciosSeguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosSeguros.Repositoios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        dbSegurosContext db;
        public RepositorioCliente(dbSegurosContext _db)
        {
            db = _db;
        }
        public async Task<int> AddCliente(Models.TbCliente cliente)
        {
            try
            {
                await db.TbCliente.AddAsync(cliente);
                await db.SaveChangesAsync();

                return cliente.ClienteId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddClientePoliza(TbPolizaPorCliente clientePoliza)
        {
            try
            {
                string repe = string.Empty;
                TbPolizaPorCliente poliCLiRep = (from p in db.TbPolizaPorCliente
                                                 where p.FechaInicio == clientePoliza.FechaInicio
                                                    && p.ClientreId == clientePoliza.ClientreId
                                                    && p.PolizaId == clientePoliza.PolizaId
                                                 select p).FirstOrDefault();

                if (poliCLiRep == null)
                {
                    TbPoliza pol = db.TbPoliza.Find(clientePoliza.PolizaId);
                    DateTime fi = (DateTime)clientePoliza.FechaInicio;
                    DateTime ff = fi.AddMonths((int)pol.PeriodoCobertura);
                    clientePoliza.FechaIfinal = ff;

                    await db.TbPolizaPorCliente.AddAsync(clientePoliza);
                    await db.SaveChangesAsync();
                }               

                return clientePoliza.PolizaPorClienteId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteCliente(int? clienteId)
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Encuentra la poliza a eliminar
                    var cliente = await db.TbCliente.FirstOrDefaultAsync(x => x.ClienteId == clienteId);

                    if (cliente != null)
                    {
                        db.TbCliente.Remove(cliente);
                        result = await db.SaveChangesAsync();
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        public async Task<ModeloSeguros.Cliente.TbCliente> GetCliente(int clienteId)
        {
            try
            {
                return await(from p in db.TbCliente
                             join c in db.TbTipoDoc on p.TipoDoc equals c.TipoDocId
                             where p.ClienteId == clienteId
                             select new ModeloSeguros.Cliente.TbCliente
                             {
                                 ClienteId = p.ClienteId,
                                 NombreCompleto = p.NombreCompleto,
                                 Documento = p.Documento,
                                 TipoDoc = c.TipoDocId,
                                 TipoDocDesc = c.TipoDocumento,
                                 Direccrion = p.Direccrion,
                                 Telefono = p.Telefono
                             }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ModeloSeguros.Cliente.TbCliente>> GetClientes()
        {
            try
            {
                return await(from p in db.TbCliente
                             join c in db.TbTipoDoc on p.TipoDoc equals c.TipoDocId
                             select new ModeloSeguros.Cliente.TbCliente
                             {
                                 ClienteId = p.ClienteId,
                                 NombreCompleto = p.NombreCompleto,
                                 Documento = p.Documento,
                                 TipoDoc = c.TipoDocId,
                                 TipoDocDesc = c.TipoDocumento,
                                 Direccrion = p.Direccrion,
                                 Telefono = p.Telefono
                             }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ModeloSeguros.Cliente.TbPolizaPorCliente>> GetClientesPoliza()
        {
            try
            {
                return await (from pc in db.TbPolizaPorCliente
                              join p in db.TbPoliza on pc.PolizaId equals p.PolizaId
                              join c in db.TbCliente on pc.ClientreId equals c.ClienteId
                              select new ModeloSeguros.Cliente.TbPolizaPorCliente
                              {
                                  PolizaPorClienteId = pc.PolizaPorClienteId,
                                  ClientreId = c.ClienteId,
                                  Clientre = c.NombreCompleto,
                                  PolizaId = p.PolizaId,
                                  Poliza = p.Nombre,
                                  FechaInicio = pc.FechaInicio,
                                  FechaIfinal = pc.FechaIfinal
                              }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TbTipoDoc>> GetTipoDoc()
        {
            try
            {
                return await(from p in db.TbTipoDoc
                             select p).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateCliente(Models.TbCliente cliente)
        {
            if (db != null)
            {
                try
                {
                    db.TbCliente.Update(cliente);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
