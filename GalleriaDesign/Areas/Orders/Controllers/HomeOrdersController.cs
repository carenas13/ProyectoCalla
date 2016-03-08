using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalleriaDesign.Areas.Orders.Controllers
{
    public class HomeOrdersController : Controller
    {
        // GET: Orders/HomeOrders
        public ActionResult Index()
        {
            return View();
        }
    }
}