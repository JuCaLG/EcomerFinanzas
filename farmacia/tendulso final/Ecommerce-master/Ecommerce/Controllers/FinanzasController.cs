using Ecommerce.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class FinanzasController : Controller
    {
        private EcommerceEntities2 db = new EcommerceEntities2();


        public ActionResult autorizarCompra()
        {
            //ApplicationDbContext dbc = new ApplicationDbContext();
            if (User.Identity.IsAuthenticated)
            {
                var iduser = User.Identity.GetUserId();
                Empleados user = db.Empleados.Where(p => p.Id_users.Equals(iduser)).First();
                if (user.Active && (user.Puesto.Equals("Control Finanzas") || user.Puesto.Equals("Director Administrativo")))
                {
                    var suma = db.Pedidos_provedores.Where(d => d.autorizacion == 0).Sum(d => d.Total);
                    ViewBag.Presupuesto = 90000 - suma;
                    var pedidos = db.Pedidos_provedores.Where(d => d.autorizacion == 2);
                    return View(pedidos);
                }
                return RedirectToAction("Denegate", "Empleados", user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }



        public ActionResult detalleCompra(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var iduser = User.Identity.GetUserId();
                Empleados user = db.Empleados.Where(p => p.Id_users.Equals(iduser)).First();
                if (user.Active && (user.Puesto.Equals("Control Finanzas") || user.Puesto.Equals("Director Administrativo")))
                {

                    var detalle = db.Pedidos_provedores.Find(id);
                    var suma = db.Pedidos_provedores.Where(d => d.autorizacion == 0).Sum(d => d.Total);
                    ViewBag.Presupuesto = 90000 - suma - detalle.Total;
                    return View(detalle);
                }
                return RedirectToAction("Denegate", "Empleados", user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult editDetalleCompra(FormCollection formCollection)
        {
            string id = formCollection["id"];
            string estatus = formCollection["estatus"];
            string observaciones = formCollection["observaciones"];
            int esta;
            if (estatus.Equals("Autorizar"))
                esta = 0;
            else
                esta = 1;

            var detalle = db.Pedidos_provedores.Find(int.Parse(id));
            detalle.autorizacion = esta;
            detalle.observaciones = observaciones;
            detalle.fechaautoriza = DateTime.Now;
            db.Entry(detalle).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("autorizarCompra", "Finanzas");
        }

        public ActionResult autorizarPrecio()
        {
            // ApplicationDbContext db = new ApplicationDbContext();
            if (User.Identity.IsAuthenticated)
            {
                var iduser = User.Identity.GetUserId();
                Empleados user = db.Empleados.Where(p => p.Id_users.Equals(iduser)).First();
                if (user.Active && (user.Puesto.Equals("Control Finanzas") || user.Puesto.Equals("Director Administrativo")))
                {
                    var precio = db.Historial_prudcto.Where(d => d.Autorizacion == 2);
                    return View(precio);
                }
                return RedirectToAction("Denegate", "Empleados", user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult historialProductos(int id)
        {
            // ApplicationDbContext db = new ApplicationDbContext();
            if (User.Identity.IsAuthenticated)
            {
                var iduser = User.Identity.GetUserId();
                Empleados user = db.Empleados.Where(p => p.Id_users.Equals(iduser)).First();
                if (user.Active && (user.Puesto.Equals("Control Finanzas") || user.Puesto.Equals("Director Administrativo")))
                {
                    var historial = db.Historial_prudcto.Where(d => (d.Id_producto == id && (d.Autorizacion == 0 || d.Autorizacion == 1)));
                    return View(historial);
                }
                return RedirectToAction("Denegate", "Empleados", user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult editAutorizarPrecio(FormCollection formCollection)
        {

            string id = formCollection["id"];
            string estatus = formCollection["estatus"];
            string observaciones = formCollection["observaciones"];
            var precio = db.Historial_prudcto.Find(int.Parse(id));
            int esta;
            if (estatus.Equals("Autorizar"))
            {
                var producto = db.Productos.Find(precio.Productos.Id);
                producto.Precio_final = Double.Parse(precio.Nuevo_precio);
                db.Entry(producto).State = EntityState.Modified;
                esta = 0;
            }
            else
            {
                esta = 1;
            }

            precio.Autorizacion = esta;
            precio.Observaciones = observaciones;
            db.Entry(precio).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("autorizarPrecio", "Finanzas");

        }


        public ActionResult devoluciones()
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            if (User.Identity.IsAuthenticated)
            {
                var iduser = User.Identity.GetUserId();
                Empleados user = db.Empleados.Where(p => p.Id_users.Equals(iduser)).First();
                if (user.Active && (user.Puesto.Equals("Control Finanzas") || user.Puesto.Equals("Director Administrativo")))
                {
                    var devoluciones = db.Devoluciones.Where(d => d.status == 2);
                    return View(devoluciones);
                }
                return RedirectToAction("Denegate", "Empleados", user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult detalleDevolución(int id)
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            if (User.Identity.IsAuthenticated)
            {
                var iduser = User.Identity.GetUserId();
                Empleados user = db.Empleados.Where(p => p.Id_users.Equals(iduser)).First();
                if (user.Active && (user.Puesto.Equals("Control Finanzas") || user.Puesto.Equals("Director Administrativo")))
                {
                    var detalle = db.Devoluciones.Find(id);
                    return View(detalle);
                }
                return RedirectToAction("Denegate", "Empleados", user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult editDetalleDevolución(FormCollection formCollection)
        {

            string id = formCollection["id"];
            string estatus = formCollection["estatus"];
            string observaciones = formCollection["observaciones"];
            int e;

            var devolucion = db.Devoluciones.Find(int.Parse(id));

            if (estatus.Equals("Autorizar"))
                e = 0;
            else
                e = 1;

            devolucion.observaciones = observaciones;
            devolucion.status = e;
            db.Entry(devolucion).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("devoluciones", "Finanzas");
        }

    }
}