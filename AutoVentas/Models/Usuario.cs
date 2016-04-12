using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutoVentas.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public String nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo apellido es obligatorio.")]
        public String apellido { get; set; }
        [Display(Name = "Correo"),DataType (DataType.EmailAddress)]
        [Required(ErrorMessage = "El campo correo es obligatorio.")]
        public String correo { get; set; }
        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "El campo direccion es obligatorio.")]
        public String direccion { get; set; }
        [Display(Name = "Nick")]
        [Required(ErrorMessage = "El campo nick es obligatorio.")]
        public String nick { get; set; }
        [Display(Name = "Contraseña"), DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
        public String contraseña { get; set; }
        [Display(Name = "Comparar Contraseña"), DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
        [Compare("contraseña", ErrorMessage = "Las contraseñas no coinciden")]
        public String compararContraseña { get; set; }
        public int idRol { get; set; }
        public virtual Rol rol { get; set; }

    }
}