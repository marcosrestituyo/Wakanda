using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wakanda.Models;

namespace Wakanda.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            CProductos cp = new CProductos();
            ModelState.Clear();
            ViewData.Model = cp.GetProducts();
            return View();
        }

        public ActionResult Insertar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insertar(ProductosModel p)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    CProductos cp = new CProductos();

                    if (cp.Insertar(p))
                    {
                        ViewBag.Message = "Producuto insertado correctamente";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return View();
            }
            
        }


        public ActionResult Actualizar(int id)
        {
            CProductos cp = new CProductos();
            ViewData.Model = cp.GetProducts().Find(t => t.ID == id);
            return View();
        }
        [HttpPost]
        public ActionResult Actualizar(int id, ProductosModel p)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    CProductos cp = new CProductos();


                    if (cp.Actualizar(p))
                    {
                        ModelState.Clear();

                    }
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return View();
            }

        }


        //public ActionResult Eliminar(int id)
        //{
        //    CProductos cp = new CProductos();
        //    ViewData.Model = cp.GetProducts().Find(t => t.ID == id);
        //    return View();
        //}

        
        public ActionResult Eliminar(int id)
        {

            try
            {
                
                CProductos cp = new CProductos();
               
                if (cp.Eliminar(id))
                    {
                    ViewBag.AlertMsg = "Deseas eliminar este producto?";
                        ModelState.Clear();

                    }
               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }

        }
    }
}