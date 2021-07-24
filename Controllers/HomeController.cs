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
        private webEntities db = new webEntities();
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
        public ActionResult Feedback()
        {
            Feedback fb = new Feedback();
            fb.Name = Request["Name"];
           
            fb.Phone = Request["Phone"];
            fb.Email = Request["Email"];
            
            return View();
        }
        public ActionResult Address()
        {
            return View();
        }
    }
}