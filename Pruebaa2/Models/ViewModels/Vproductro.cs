using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pruebaa2.Models.ViewModels
{
    public class Vproductro
    {
        [Required]
        [Display(Name = "ID del producto")]
        public int idProducto { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]

        [StringLength(200)]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public int precio { get; set; }
        [Required]
        [Display(Name = "Stock")]
        public int stock { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public int idCategoria { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}