using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutoVentas.Models
{
    public class Compra
    {
        [Key]
        public int idCompra { get; set; }
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo fecha es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }
        public int idUsuario { get; set; }
        public int idAutomovil { get; set; }
       
        public virtual Usuario usuario { get; set; }
        public virtual Automovil automovil { get; set; }
        
    }
}