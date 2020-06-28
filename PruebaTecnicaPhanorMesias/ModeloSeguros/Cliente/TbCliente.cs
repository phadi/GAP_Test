using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloSeguros.Cliente
{
    public class TbCliente
    {
        public int ClienteId { get; set; }
        public string NombreCompleto { get; set; }
        public string Documento { get; set; }
        public int? TipoDoc { get; set; }
        public string TipoDocDesc { get; set; }
        public string Direccrion { get; set; }
        public string Telefono { get; set; }
    }
}
