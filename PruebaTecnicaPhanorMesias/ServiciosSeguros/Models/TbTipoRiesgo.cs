using System;
using System.Collections.Generic;

namespace ServiciosSeguros.Models
{
    public partial class TbTipoRiesgo
    {
        public TbTipoRiesgo()
        {
            TbPoliza = new HashSet<TbPoliza>();
        }

        public int TipoRiesgoId { get; set; }
        public string TipoRiesgo { get; set; }

        public virtual ICollection<TbPoliza> TbPoliza { get; set; }
    }
}
