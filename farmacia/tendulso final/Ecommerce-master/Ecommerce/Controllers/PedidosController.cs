using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class PedidosController : Controller
    {
        private EcommerceEntities2 db = new EcommerceEntities2();
        // GET: Pedidos
        public ActionResult Index()
        {
            var pedido = db.Ventas.Where(d=>d.Clientes.Id==6);
            return View(pedido);
        }
        public ActionResult Detalle(int id)
        {
            var pedido = db.Ventas.Find(id);
            return View(pedido);
        }

    }
}