using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionWebSeguros.Models
{
    public class tbPoliza
    {
        public int PolizaId { get; set; }
        [Required(ErrorMessage = "El campo Nombre de Poliza es obligatorio")]
        public string Nombre { get; set; }
        
        public string Descriocion { get; set; }
        [Required(ErrorMessage = "El campo tipo de cubrimiento es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione tipo de cubrimiento")]
        public int? TipoCubrimiento { get; set; }
        public string TipoCubrimientoDesc { get; set; }
        public decimal? Cubrimiento { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? InicioVigencia { get; set; }
        public int? PeriodoCobertura { get; set; }
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "El campo tipo de riesgo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione tipo de riesgo")]
        public int? TipoRiesgo { get; set; }
        public string TipoRiesgoDesc { get; set; }
    }
}