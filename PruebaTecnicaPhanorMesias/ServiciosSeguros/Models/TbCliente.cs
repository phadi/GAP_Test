using System;
using System.Collections.Generic;

namespace ServiciosSeguros.Models
{
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbPolizaPorCliente = new HashSet<TbPolizaPorCliente>();
        }

        public int ClienteId { get; set; }
        public string NombreCompleto { get; set; }
        public string Documento { get; set; }
        public int? TipoDoc { get; set; }
        public string Direccrion { get; set; }
        public string Telefono { get; set; }

        public virtual TbTipoDoc TipoDocNavigation { get; set; }
        public virtual ICollection<TbPolizaPorCliente> TbPolizaPorCliente { get; set; }
    }
}
