using System;
using System.Collections.Generic;

namespace ServiciosSeguros.Models
{
    public partial class TbPoliza
    {
        public TbPoliza()
        {
            TbPolizaPorCliente = new HashSet<TbPolizaPorCliente>();
        }

        public int PolizaId { get; set; }
        public string Nombre { get; set; }
        public string Descriocion { get; set; }
        public int? TipoCubrimiento { get; set; }
        public decimal? Cubrimiento { get; set; }
        public DateTime? InicioVigencia { get; set; }
        public int? PeriodoCobertura { get; set; }
        public decimal? Precio { get; set; }
        public int? TipoRiesgo { get; set; }

        public virtual TbTipoCubrimiento TipoCubrimientoNavigation { get; set; }
        public virtual TbTipoRiesgo TipoRiesgoNavigation { get; set; }
        public virtual ICollection<TbPolizaPorCliente> TbPolizaPorCliente { get; set; }
    }
}
