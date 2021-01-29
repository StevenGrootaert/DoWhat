using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoWhat.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Getting Started and Application Description";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Developer contact page.";

            return View();
        }
    }
}