using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionWebSeguros.Models
{
    public class tbUsuario
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage ="El campo Login es obligatorio")]
        public string Login { get; set; }
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo contraseña es obligatorio")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        public int? RolId { get; set; }
        public string RolName { get; set; }
        public List<tbPermisoPorRol> permisos { get; set; }
    }
}