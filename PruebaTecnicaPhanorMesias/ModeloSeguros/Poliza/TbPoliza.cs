using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloSeguros.Poliza
{
    public class TbPoliza
    {
        public int PolizaId { get; set; }
        public string Nombre { get; set; }
        public string Descriocion { get; set; }
        public int? TipoCubrimiento { get; set; }
        public string TipoCubrimientoDesc { get; set; }
        public decimal? Cubrimiento { get; set; }
        public DateTime? InicioVigencia { get; set; }
        public int? PeriodoCobertura { get; set; }
        public decimal? Precio { get; set; }
        public int? TipoRiesgo { get; set; }
        public string TipoRiesgoDesc { get; set; }
    }
}
