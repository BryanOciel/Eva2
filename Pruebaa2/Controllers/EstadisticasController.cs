using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pruebaa2.Models;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Pruebaa2.Controllers
{
    public class EstadisticasController : Controller
    {
        // GET: Estadisticas
        public ActionResult Index()
        {
            fabricaEntities db = new fabricaEntities();

            IEnumerable<Categoria> categoriaQuery = from categoria in db.Categoria select categoria;
            IEnumerable<Producto> productoQuery = from producto in db.Producto select producto;

            List<int> listaidCategorias = new List<int>();
            foreach (Categoria categoria in categoriaQuery) listaidCategorias.Add(categoria.idCategoria);

            List<int> listaidProductos = new List<int>();
            List<int> listaPrecioProducto = new List<int>();
            foreach (Producto producto in productoQuery)
            {
                listaidProductos.Add((int)producto.idCategoria);
                listaPrecioProducto.Add((int)producto.precio);
            }

            List<double> listCantidad = new List<double>();
            List<double> listPreciosxCantidad = new List<double>();
            foreach ( int categoria in listaidCategorias)
            {
                int i = 0;
                int sumaCategoria= 0;
                int sumaPrecio = 0;
                foreach(int producto in listaidProductos)
                {
                    if (producto == categoria) 
                    {
                        sumaPrecio += listaPrecioProducto[i];
                        sumaCategoria += 1;
                    }
                    i++;
                }
                double porcentaje = sumaCategoria * 100 / listaidProductos.Count();
                listCantidad.Add(porcentaje);
                double promedio = 0;
                if (sumaCategoria != 0){ promedio = sumaPrecio / sumaCategoria; }
                listPreciosxCantidad.Add(promedio);
            }
            // Asignar lista a un ViewBag
            ViewBag.idCategoria = listaidCategorias;
            ViewBag.cantCategorias = listCantidad;
            ViewBag.preciosCategorias = listPreciosxCantidad;
            return View();
        }
    }
}