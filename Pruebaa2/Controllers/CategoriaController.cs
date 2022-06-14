using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pruebaa2.Models;
using Pruebaa2.Models.ViewModels;

namespace Pruebaa2.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult Index()

        {
            List<ViewCategoria> lst;
            using (fabricaEntities db = new fabricaEntities())

            {
                lst = (from c in db.Categoria
                       select new ViewCategoria
                       {
                           idCategoria = c.idCategoria,
                           nombre = c.nombre,

                       }).ToList();

            }
            return View(lst);
        }

        public ActionResult Edit(int id)
        {
            ViewCategoria model = new ViewCategoria();

            using (fabricaEntities db = new fabricaEntities())
            {
                var oProduc = db.Categoria.Find(id);
                model.idCategoria = oProduc.idCategoria;
                model.nombre = oProduc.nombre;

            }
            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(ViewCategoria model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (fabricaEntities db = new fabricaEntities())
                    {
                        var oProduc = db.Categoria.Find(model.idCategoria);
                        oProduc.idCategoria = model.idCategoria;
                        oProduc.nombre = model.nombre;

                        db.Entry(oProduc).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Categoria/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(ViewCategoria model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (fabricaEntities db = new fabricaEntities())
                    {
                        var oProduc = new Categoria();
                        oProduc.idCategoria = model.idCategoria;
                        oProduc.nombre = model.nombre;

                        db.Categoria.Add(oProduc);
                        db.SaveChanges();
                    }
                    return Redirect("~/Categoria/");
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
                var oProduc = db.Categoria.Find(id);
                db.Categoria.Remove(oProduc);
                db.SaveChanges();
            }
            return Redirect("~/Categoria/");
        }
    }
}
