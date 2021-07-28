using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTrinhWeb.Models
{
    public class CartItem
    {
        public Product _ShoppingProduct { get; set; }
        public int _ShopppingQuantity { get; set; }
    }

    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Product pro, int quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._ShoppingProduct.ProductId == pro.ProductId);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _ShoppingProduct = pro,
                    _ShopppingQuantity = quantity
                });

            }
            else
            {
                item._ShopppingQuantity += quantity;
            }
        }
        public void UpdateQuantity(int id, int quantity)
        {
            var item = items.Find(s => s._ShoppingProduct.ProductId == id);
            if (item != null)
            {
                item._ShopppingQuantity = quantity;
            }

        }
        public double TotalMoney()
        {
            var total = items.Sum(s => s._ShoppingProduct.Price * s._ShopppingQuantity);
            return (double)total;
        }
        public void Remove_Cart(int id)
        {
            items.RemoveAll(s => s._ShoppingProduct.ProductId == id);
        }
        public int Total_Quantity()
        {
            return items.Sum(s => s._ShopppingQuantity);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}