using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloSeguros.Usuario
{
    public class TbUsuario
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Nombres { get; set; }
        public string Contrasena { get; set; }
        public int? RolId { get; set; }
        public string RolName { get; set; }
        public List<TbPermisoPorRol> permisos { get; set; }

        public virtual TbRol Rol { get; set; }
    }
}
