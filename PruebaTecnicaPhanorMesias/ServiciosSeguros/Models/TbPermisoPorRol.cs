using System;
using System.Collections.Generic;

namespace ServiciosSeguros.Models
{
    public partial class TbPermisoPorRol
    {
        public int PermisoPorRolId { get; set; }
        public int? RolId { get; set; }
        public string Titulo { get; set; }
        public string Accion { get; set; }
        public string Controlador { get; set; }
        public int? Nivel { get; set; }

        public virtual TbRol Rol { get; set; }
    }
}
