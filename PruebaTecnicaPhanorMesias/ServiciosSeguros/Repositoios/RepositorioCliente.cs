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
        public Task<int> AddCliente(Models.TbCliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteCliente(int? clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<ModeloSeguros.Cliente.TbCliente> GetCliente(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ModeloSeguros.Cliente.TbCliente>> GetClientes()
        {
            throw new NotImplementedException();
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

        public Task UpdateCliente(Models.TbCliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
