using ServiciosSeguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosSeguros.Repositoios
{
    public interface IRepositorioUsuario
    {
        Task<List<ModeloSeguros.Usuario.TbUsuario>> GetUsuarios();
        Task<ModeloSeguros.Usuario.TbUsuario> GetUsuario(string login, string psw);
        Task<int> AddUser(TbUsuario user);
        Task<List<TbPermisoPorRol>> GetPermisos(int rolId);
        
    }
}
