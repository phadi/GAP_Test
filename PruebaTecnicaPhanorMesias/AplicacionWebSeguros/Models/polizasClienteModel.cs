using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionWebSeguros.Models
{
    public class polizasClienteModel
    {
        public int PolizaId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaInicio { get; set; }
        //public List<tbCliente> lstClientes { get; set; }
        public int ClienteId { get; set; }
    }
}