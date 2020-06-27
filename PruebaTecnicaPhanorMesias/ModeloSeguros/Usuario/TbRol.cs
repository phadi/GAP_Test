using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloSeguros.Usuario
{
    public class TbRol
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
