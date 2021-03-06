using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TecnicoDevJr.Models
{
    public partial class Usuario
    {
        [Range(0, int.MaxValue)]
        [DisplayName("Id")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El campo Nombre de Usuario es requerido.")]
        [DisplayName("Nombre de Usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Email es requerido.")]
        [RegularExpression(@"^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$", ErrorMessage = "Debe ingresar un Email válido.")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Telefono")]
        public int? Telefono { get; set; }
    }
}