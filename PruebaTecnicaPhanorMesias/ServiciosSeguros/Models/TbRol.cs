using System;
using System.Collections.Generic;

namespace ServiciosSeguros.Models
{
    public partial class TbRol
    {
        public TbRol()
        {
            TbPermisoPorRol = new HashSet<TbPermisoPorRol>();
            TbUsuario = new HashSet<TbUsuario>();
        }

        public int RolId { get; set; }
        public string Rol { get; set; }

        public virtual ICollection<TbPermisoPorRol> TbPermisoPorRol { get; set; }
        public virtual ICollection<TbUsuario> TbUsuario { get; set; }
    }
}
