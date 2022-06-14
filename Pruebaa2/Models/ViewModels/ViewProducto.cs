using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pruebaa2.Models.ViewModels
{
    public class ViewProducto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int stock { get; set; }
        public int idCategoria { get; set; }
        public bool estado { get; set; }
                         
    }
}