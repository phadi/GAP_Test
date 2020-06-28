using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloSeguros.Usuario
{
    public class TbPermisoPorRol
    {
        public int PermisoPorRolId { get; set; }
        public int? RolId { get; set; }
        public string Titulo { get; set; }
        public string Accion { get; set; }
        public string Controlador { get; set; }
        public int nivel { get; set; }
    }
}
