using System;
using System.Collections.Generic;

namespace ServiciosSeguros.Models
{
    public partial class TbUsuario
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Nombres { get; set; }
        public string Contrasena { get; set; }
        public int? RolId { get; set; }

        public virtual TbRol Rol { get; set; }
    }
}
