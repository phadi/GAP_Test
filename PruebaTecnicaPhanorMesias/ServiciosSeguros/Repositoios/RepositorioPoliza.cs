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

        public RepositorioPoliza()
        {
            db = new dbSegurosContext();
        }

        public async Task<int> AddPoliza(Models.TbPoliza poliza)
        {
            List<string> valida = reglasNegocio(poliza);
            if (valida.Count == 0)
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
            else
            {
                string msm = "Reglas Invalidas: ";
                foreach (string st in valida)
                {
                    msm += Environment.NewLine + st;
                }
                throw new Exception(msm);
            }

        }

        public async Task<ModeloSeguros.Poliza.TbPoliza> GetPoliza(int polizaId)
        {
            try
            {
                return await (from p in db.TbPoliza
                              join c in db.TbTipoCubrimiento on p.TipoCubrimiento equals c.TipoCubrimientoId
                              join r in db.TbTipoRiesgo on p.TipoRiesgo equals r.TipoRiesgoId
                              where p.PolizaId == polizaId
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
                              }).FirstOrDefaultAsync();
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

        public async Task<List<TbTipoCubrimiento>> GetTipoCubrimiento()
        {
            try
            {
                return await(from p in db.TbTipoCubrimiento
                             select p).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TbTipoRiesgo>> GetTipoRiesgo()
        {
            try
            {
                return await(from p in db.TbTipoRiesgo
                             select p).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdatePoliza(Models.TbPoliza poliza)
        {
            if (db != null)
            {
                List<string> valida = reglasNegocio(poliza);
                if (valida.Count == 0)
                {
                    try
                    {
                        db.TbPoliza.Update(poliza);
                        await db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    string msm = "Reglas Invalidas: ";
                    foreach (string st in valida)
                    {
                        msm += Environment.NewLine + st;
                    }
                    throw new Exception(msm);
                }
            }
        }

        public async Task<int> DeletePoliza(int? polizaId)
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Encuentra la poliza a eliminar
                    var poliza = await db.TbPoliza.FirstOrDefaultAsync(x => x.PolizaId == polizaId);

                    if (poliza != null)
                    {
                        db.TbPoliza.Remove(poliza);
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

        public List<string> reglasNegocio(Models.TbPoliza poliza)
        {
            List<string> resp = new List<string>();

            if (poliza.TipoRiesgo == 4 && poliza.Cubrimiento > 50)
            {
                resp.Add("El porcentaje de cubrimiento no puede superar el 50% para riesgos altos");
            }



            return resp;
        }
    }
}
