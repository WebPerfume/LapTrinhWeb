using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LapTrinhWeb.Areas.Admin.code;
using LapTrinhWeb.Areas.Admin.Models;

namespace LapTrinhWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new Account().Login(model.Email, model.Matkhau);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { Email = model.Email });
                return RedirectToAction("Index", "Products");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View(model);
        }
    }
}