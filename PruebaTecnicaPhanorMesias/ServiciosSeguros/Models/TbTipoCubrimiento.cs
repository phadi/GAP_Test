using System;
using System.Collections.Generic;

namespace ServiciosSeguros.Models
{
    public partial class TbTipoCubrimiento
    {
        public TbTipoCubrimiento()
        {
            TbPoliza = new HashSet<TbPoliza>();
        }

        public int TipoCubrimientoId { get; set; }
        public string TipoCubrimiento { get; set; }

        public virtual ICollection<TbPoliza> TbPoliza { get; set; }
    }
}
