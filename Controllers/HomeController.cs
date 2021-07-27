using LapTrinhWeb.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LapTrinhWeb.Controllers
{
    public class HomeController : Controller
    {
        private QLBHEntities db = new QLBHEntities();
        private List<Product> ListP()
        {
            return db.Products.ToList();
        }
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var List = ListP();
            int pagesize = 20;
            int pagenumber = (page ?? 1);
            return View(List.ToPagedList(pagenumber, pagesize));
        }

        public ActionResult Preview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
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