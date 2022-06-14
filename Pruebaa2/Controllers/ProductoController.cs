using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pruebaa2.Models;
using Pruebaa2.Models.ViewModels;

namespace Pruebaa2.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()

        {
            List<ViewProducto> lst;
            using (fabricaEntities db = new fabricaEntities())

            {
                lst = (from d in db.Producto
                       select new ViewProducto
                       {
                           idProducto = d.idProducto,
                           nombre = d.nombre,
                           descripcion = d.descripcion,
                           precio = (int)d.precio,
                           stock = (int)d.stock,
                           idCategoria = (int)d.idCategoria,
                           estado = (bool)d.estado

                       }).ToList();

            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Nuevo(ViewProducto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (fabricaEntities db = new fabricaEntities())
                    {
                        var oProducto = new Producto();

                        oProducto.nombre = model.nombre;
                        oProducto.descripcion = model.descripcion;
                        oProducto.precio = model.precio;
                        oProducto.stock = model.stock;
                        oProducto.idCategoria = model.idCategoria;
                        oProducto.estado = model.estado;

                        db.Producto.Add(oProducto);
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/");
                }
                return View(model);
            }
            catch (Exception ex) {

                throw new Exception(ex.Message);

            }
        }
        public ActionResult Editar(int? id)
        {
            ViewProducto model = new ViewProducto();

            using (fabricaEntities db = new fabricaEntities())
            {
                var oProducto = db.Producto.Find(id);
                model.idProducto = oProducto.idProducto;
                model.nombre = oProducto.nombre;
                model.descripcion = oProducto.descripcion;
                model.precio = (int)oProducto.precio;
                model.stock = (int)oProducto.stock;
                model.idCategoria = (int)oProducto.idCategoria;
                model.estado =(bool)oProducto.estado;

            }
            return View(model);

        }
        [HttpPost]
        public ActionResult Editar(ViewProducto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (fabricaEntities db = new fabricaEntities())
                    {
                        var oProducto = db.Producto.Find(model.idProducto);
                        oProducto.idProducto = model.idProducto;
                        oProducto.nombre = model.nombre;
                        oProducto.descripcion = model.descripcion;
                        oProducto.precio = model.precio;
                        oProducto.stock = model.stock;
                        oProducto.idCategoria = model.idCategoria;
                        oProducto.estado = model.estado;

                        db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (fabricaEntities db = new fabricaEntities())
            {
                var oProducto = db.Producto.Find(id);
                db.Producto.Remove(oProducto);
                db.SaveChanges();
            }
            return Redirect("~/Producto/");
        }
    }
}

