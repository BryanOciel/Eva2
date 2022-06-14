using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pruebaa2.Models.ViewModels
{
    public class Vcategoria
    {
        [Required]
        [Display(Name = "ID de la Categoria")]
        public int idCategoria { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
    }
}