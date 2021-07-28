using LapTrinhWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LapTrinhWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        QLBHEntities5 db = new QLBHEntities5();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(int id)
        {
            var pro = db.Products.SingleOrDefault(s => s.ProductId == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }
        public ActionResult ShowtoCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowtoCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult UpdateQuantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int idP = int.Parse(form["ID_Pro"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.UpdateQuantity(idP, quantity);
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_Cart(id);
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }
        public PartialViewResult Bagcart()
        {
            int _t_tem = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                _t_tem = cart.Total_Quantity();
            }
            ViewBag.infoCart = _t_tem;
            return PartialView("Bagcart");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order order = new Order();
                order.CreateDate = DateTime.Now;
                db.Orders.Add(order);
                foreach (var item in cart.Items)
                {
                    Orderdetail orderdetail = new Orderdetail();
                    orderdetail.OrderId = order.OrderId;
                    orderdetail.ProductId = item._ShoppingProduct.ProductId;
                    orderdetail.Quantity = item._ShopppingQuantity;
                    orderdetail.Total = (item._ShoppingProduct.Price * item._ShopppingQuantity);
                    db.Orderdetails.Add(orderdetail);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("Success", "ShoppingCart");
            }
            catch
            {
                return Content("Error Checkout. Pleace");
            }
        }

    }


}
