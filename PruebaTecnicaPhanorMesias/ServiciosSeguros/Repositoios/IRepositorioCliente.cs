using ServiciosSeguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosSeguros.Repositoios
{
    public interface IRepositorioCliente
    {
        Task<List<TbTipoDoc>> GetTipoDoc();
        Task<List<ModeloSeguros.Cliente.TbCliente>> GetClientes();
        Task<ModeloSeguros.Cliente.TbCliente> GetCliente(int clienteId);
        Task<int> AddCliente(TbCliente cliente);
        Task UpdateCliente(TbCliente cliente);
        Task<int> DeleteCliente(int? clienteId);
    }
}
