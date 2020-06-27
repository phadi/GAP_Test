using System;
using System.Collections.Generic;

namespace ServiciosSeguros.Models
{
    public partial class TbRol
    {
        public TbRol()
        {
            TbUsuario = new HashSet<TbUsuario>();
        }

        public int RolId { get; set; }
        public string Rol { get; set; }

        public virtual ICollection<TbUsuario> TbUsuario { get; set; }
    }
}
