using BotDetect.Web.Mvc;
using LapTrinhWeb.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LapTrinhWeb.Controllers
{
    public class HomeController : Controller
    {
        private QLBHEntities5 db = new QLBHEntities5();

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
        public ActionResult Intro()
        {
            return View();
        }

        public ActionResult Register ()
        {
            return View();
        }
        //GET: Register

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "registerCapcha", "mã xác nhận không đúng")]
        public ActionResult Register(User _user)
        {

            /*ModelState.Remove("CaptchaCode");*/
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Email","Email already exists");
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();
        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().UserID;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}