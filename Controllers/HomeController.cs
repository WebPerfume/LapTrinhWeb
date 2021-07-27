using LapTrinhWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LapTrinhWeb.Controllers
{
    public class HomeController : Controller
    {
        private QLBHEntities db = new QLBHEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
        public ActionResult Address()
        {
            return View();
        }

        public ActionResult OnlineShopping()
        {
            return View();
        }
        public ActionResult Group()
        {
            return View();
        }
        public ActionResult Return()
        {
            return View();
        }
    }
}