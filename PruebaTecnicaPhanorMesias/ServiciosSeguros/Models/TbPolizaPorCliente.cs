using System;
using System.Collections.Generic;

namespace ServiciosSeguros.Models
{
    public partial class TbPolizaPorCliente
    {
        public int PolizaPorClienteId { get; set; }
        public int? ClientreId { get; set; }
        public int? PolizaId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaIfinal { get; set; }

        public virtual TbCliente Clientre { get; set; }
        public virtual TbPoliza Poliza { get; set; }
    }
}
