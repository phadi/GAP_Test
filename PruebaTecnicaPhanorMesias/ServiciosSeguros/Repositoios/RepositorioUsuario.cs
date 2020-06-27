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

        public async Task<ModeloSeguros.Usuario.TbUsuario> GetUsuario(string login, string psw)
        {
            try
            {                               
                return await (from u in db.TbUsuario
                              join r in db.TbRol on u.RolId equals r.RolId
                              where u.Contrasena == psw
                                 && u.Login == login
                              select new ModeloSeguros.Usuario.TbUsuario
                              {
                                  Login = u.Login,
                                  Nombres = u.Nombres,
                                  Contrasena = u.Contrasena,
                                  RolId = r.RolId,
                                  RolName = r.Rol,
                                  UsuarioId = u.UsuarioId
                              }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ModeloSeguros.Usuario.TbUsuario>> GetUsuarios()
        {
            try
            {
                return await (from u in db.TbUsuario
                              join r in db.TbRol on u.RolId equals r.RolId
                              select new ModeloSeguros.Usuario.TbUsuario
                              {
                                  Login = u.Login,
                                  Nombres = u.Nombres,
                                  Contrasena = u.Contrasena,
                                  RolId = r.RolId,
                                  RolName = r.Rol,
                                  UsuarioId = u.UsuarioId
                              }).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
