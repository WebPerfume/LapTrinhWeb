using LapTrinhWeb.Helper;
using LapTrinhWeb.Models;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LapTrinhWeb.Controllers
{
    public class PaypalController : Controller
    {
        // GET: Paypal
        public ActionResult Index()
        {
            return View();
        }
        private PayPal.Api.Payment payment;




        public ActionResult PaymentWithPaypal()
        {
            APIContext apiContext = Configuration.GetAPIContext();
            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority
                    +
                    "/Paypal/PaymentWithPayPal?";

                    //link trả về khi người dùng hủy thanh toán
                    string failedURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/ShoppingCart/CheckOut";
                    
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid, failedURI);
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Error" + ex.Message);
                return View("FailureView");
            }
            return RedirectToAction("Success", "ShoppingCart");
        }

       /* private Payment CreatePayment(APIContext apiContext, string redirectUrl, string failedUrl)
        {
            var itemList = new ItemList() { items = new List<Item>() };
            //recipient_name: tên người đặt hàng
            //country_code: code quốc gia, tham khảo thêm tại: https://developer.paypal.com/docs/api/reference/country-codes/
            //city: thành phố shipping
            //line1: địa chỉ giao hàng
            //postal_code: code postal (ví dụ code ở Việt Nam: https://www.google.com/search?q=postal+code+vietnam)

            itemList.items.Add(new Item()
            {
                //Thông tin đơn hàng
                name = "Item Name",
                currency = "USD",
                price = "5",
                quantity = "1",
                sku = "sku"
            });
            var payer = new Payer() { payment_method = "paypal" };
            var redirUrls = new RedirectUrls()
            {
                cancel_url = failedUrl, //url cancel
                return_url = redirectUrl //url return
            };

            var details = new Details()
            {
                tax = "1",
                shipping = "2",
                subtotal = "5"
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = "8",
                details = details
            };
            var transactionList = new List<Transaction>();

            transactionList.Add(new Transaction()
            {
                description = "Transaction description.", //nội dung thanh toán
                invoice_number = DateTime.Now.ToString(), //mã hóa đơn
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            return this.payment.Create(apiContext);
        }
*/

        
        ShoppingCartController.OrderView Order = new ShoppingCartController.OrderView();
        private Payment CreatePayment(APIContext apiContext, string redirectUrl, string failedUrl)
        {
            var rate = 23000;
            var totalPrice = 0.0;
            var itemList = new ItemList()
            {
                items = new List<Item>(),
            };

            Cart lstCart = Session["Cart"] as Cart;

            foreach (var cart in lstCart.Items)
            {
                var item = new Item();
                item.name = cart._ShoppingProduct.ProductName;
                item.quantity = cart._ShopppingQuantity.ToString();
                item.currency = "USD";
                double price = Math.Round((double)(cart._ShoppingProduct.Price/rate));
                item.price = price.ToString().Replace(",", ".");
                itemList.items.Add(item);
                item.sku = cart._ShoppingProduct.ProductId.ToString();
                totalPrice += (double)(price * cart._ShopppingQuantity);
            }

            var payer = new Payer() { payment_method = "paypal" };
            var redirUrls = new RedirectUrls()
            {
                cancel_url = failedUrl,
                return_url = redirectUrl
            };

            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = totalPrice.ToString().Replace(",", ".")
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = totalPrice.ToString().Replace(",", "."),
                details = details
            };
            var transactionList = new List<Transaction>();

            transactionList.Add(new Transaction()
            {
                description = "Thanh toán hoá đơn ", //nội dung thanh toán
                invoice_number =DateTime.Now.ToString("yyyyMMddmmss"), //mã hóa đơn
                amount = amount,
                item_list = itemList,

            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            return this.payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        public ActionResult SuccessView()
        {
            return View();
        }

        public ActionResult FailureView()
        {
            return View();
        }
    }
}