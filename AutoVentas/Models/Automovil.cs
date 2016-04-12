using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVentas.Models
{
    public class Automovil
    {
        [Key]
        public int idAutomovil { get; set; }
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El campo modelo es obligatorio.")]
        public String modelo { get; set; }
        [Display(Name = "Color")]
        [Required(ErrorMessage = "El campo color es obligatorio.")]
        public String color { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "El campo precio es obligatorio.")]
        public decimal precio { get; set; }
        [Display(Name = "Imagen")]
        [Required(ErrorMessage = "El campo Imagen es obligatorio.")]
        public int idMarca { get; set; }
        public virtual Marca marca { get; set; }
        public virtual List<Archivo> archivos { get; set; }
        public virtual List<Compra> compra { get; set; }
        public virtual List<Venta> venta { get; set; }
        

    }
}