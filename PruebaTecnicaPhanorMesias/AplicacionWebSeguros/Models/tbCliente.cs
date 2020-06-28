using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionWebSeguros.Models
{
    public class tbCliente
    {
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El campo Nombre del cliente es obligatorio")]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "El campo Nro. documento es obligatorio")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "El campo tipo de documento es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione tipo de documento")]
        public int? TipoDoc { get; set; }
        public string TipoDocDesc { get; set; }
        public string Direccrion { get; set; }
        [RegularExpression(@"^(\d{10})$", ErrorMessage ="Formato de teléfono inválido")]
        public string Telefono { get; set; }
    }
}