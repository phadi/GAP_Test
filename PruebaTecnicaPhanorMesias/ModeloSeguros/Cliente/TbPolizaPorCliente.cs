using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloSeguros.Cliente
{
    public class TbPolizaPorCliente
    {
        public int PolizaPorClienteId { get; set; }
        public int? ClientreId { get; set; }
        public int? PolizaId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaIfinal { get; set; }
    }
}
