using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiciosSeguros.Models;

namespace ServiciosSeguros.Repositoios
{
    public interface IRepositorioPoliza
    {
        Task<List<ModeloSeguros.Poliza.TbPoliza>> GetPolizas();
        Task<int> AddUser(TbPoliza poliza);
    }
}
