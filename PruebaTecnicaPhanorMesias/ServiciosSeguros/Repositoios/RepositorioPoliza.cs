using Microsoft.EntityFrameworkCore;
using ModeloSeguros.Poliza;
using ServiciosSeguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosSeguros.Repositoios
{
    public class RepositorioPoliza : IRepositorioPoliza
    {
        dbSegurosContext db;
        public RepositorioPoliza(dbSegurosContext _db)
        {
            db = _db;
        }

        public async Task<int> AddUser(Models.TbPoliza poliza)
        {
            try
            {
                await db.TbPoliza.AddAsync(poliza);
                await db.SaveChangesAsync();

                return poliza.PolizaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ModeloSeguros.Poliza.TbPoliza>> GetPolizas()
        {
            try
            {
                return await (from p in db.TbPoliza
                              join c in db.TbTipoCubrimiento on p.TipoCubrimiento equals c.TipoCubrimientoId
                              join r in db.TbTipoRiesgo on p.TipoRiesgo equals r.TipoRiesgoId
                              select new ModeloSeguros.Poliza.TbPoliza
                              {
                                  PolizaId = p.PolizaId,
                                  Nombre = p.Nombre,
                                  Descriocion = p.Descriocion,
                                  TipoCubrimiento = c.TipoCubrimientoId,
                                  TipoCubrimientoDesc = c.TipoCubrimiento,
                                  Cubrimiento = p.Cubrimiento,
                                  InicioVigencia = p.InicioVigencia,
                                  PeriodoCobertura = p.PeriodoCobertura,
                                  Precio = p.Precio,
                                  TipoRiesgo = r.TipoRiesgoId,
                                  TipoRiesgoDesc = r.TipoRiesgo
                              }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
