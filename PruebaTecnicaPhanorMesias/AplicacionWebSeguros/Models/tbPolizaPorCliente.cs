using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWebSeguros.Models
{
    public class tbPolizaPorCliente
    {
        public int PolizaPorClienteId { get; set; }
        public int? ClientreId { get; set; }
        public string Clientre { get; set; }
        public int? PolizaId { get; set; }
        public string Poliza { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaIfinal { get; set; }
    }
}