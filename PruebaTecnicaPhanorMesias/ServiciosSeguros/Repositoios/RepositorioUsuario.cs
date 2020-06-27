using Microsoft.EntityFrameworkCore;
using ServiciosSeguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosSeguros.Repositoios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        dbSegurosContext db;
        public RepositorioUsuario(dbSegurosContext _db)
        {
            db = _db;
        }

        public async Task<int> AddUser(TbUsuario user)
        {
            try
            {
                await db.TbUsuario.AddAsync(user);
                await db.SaveChangesAsync();

                return user.UsuarioId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TbUsuario> GetUsuario(string login, string psw)
        {
            try
            {
                return await (from u in db.TbUsuario
                              where u.Contrasena == psw
                                 && u.Login == login
                              select u).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TbUsuario>> GetUsuarios()
        {
            try
            {
                return await db.TbUsuario.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
