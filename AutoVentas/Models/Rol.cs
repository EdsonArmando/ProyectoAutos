using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutoVentas.Models
{
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public String nombre { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        public String descripcion { get; set; }
        public virtual List<Usuario> usuarios { get; set; }

    }
}