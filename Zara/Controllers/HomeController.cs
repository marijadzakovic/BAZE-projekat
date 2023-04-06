using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zara.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //url home/customviewname
        public ActionResult Contact()
        {
            return View("CustomView");
        }

        public ActionResult RedirectResult()
        {
            return RedirectToAction("Index", "Employee");
        }
    }
}