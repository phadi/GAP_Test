using System;
using System.Collections.Generic;

namespace ServiciosSeguros.Models
{
    public partial class TbTipoDoc
    {
        public TbTipoDoc()
        {
            TbCliente = new HashSet<TbCliente>();
        }

        public int TipoDocId { get; set; }
        public string TipoDocumento { get; set; }

        public virtual ICollection<TbCliente> TbCliente { get; set; }
    }
}
