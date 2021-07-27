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
    public class ProductController : Controller
    {
        private QLBHEntities db = new QLBHEntities();
        // GET: Product
        private List<Product> ListP()
        {
            return db.Products.ToList();
        }
        // GET: Products
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
    }
}