using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LapTrinhWeb.Models;
using PagedList;

namespace LapTrinhWeb.Areas.Admin.Controllers
{
    public class TypePsController : Controller
    {
        private QLBHEntities2 db = new QLBHEntities2();

        // GET: Admin/TypePs
        private List<TypeP> ListT()
        {
            return db.TypePs.ToList();
        }
        // GET: Admin/TypePs
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var List = ListT();
            int pagesize = 5;
            int pagenumber = (page ?? 1);
            return View(List.ToPagedList(pagenumber, pagesize));
        }

        // GET: Admin/TypePs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeP typeP = db.TypePs.Find(id);
            if (typeP == null)
            {
                return HttpNotFound();
            }
            return View(typeP);
        }

        // GET: Admin/TypePs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TypePs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,TypeName")] TypeP typeP)
        {
            if (ModelState.IsValid)
            {
                db.TypePs.Add(typeP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeP);
        }

        // GET: Admin/TypePs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeP typeP = db.TypePs.Find(id);
            if (typeP == null)
            {
                return HttpNotFound();
            }
            return View(typeP);
        }

        // POST: Admin/TypePs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,TypeName")] TypeP typeP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeP);
        }

        // GET: Admin/TypePs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeP typeP = db.TypePs.Find(id);
            if (typeP == null)
            {
                return HttpNotFound();
            }
            return View(typeP);
        }

        // POST: Admin/TypePs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeP typeP = db.TypePs.Find(id);
            db.TypePs.Remove(typeP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
