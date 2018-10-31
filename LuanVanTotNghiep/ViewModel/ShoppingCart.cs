using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuanVanTotNghiep.Models;

namespace LuanVanTotNghiep.ViewModel
{
    public class ShoppingCart
    {
        public double Quantity { get; set; }
        // Lấy giỏ hàng từ Session
        public static ShoppingCart Cart
        {
            get
            {
                var cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
                // Nếu chưa có giỏ hàng trong session -> tạo mới và lưu vào session
                if (cart == null)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session["Cart"] = cart;
                }
                return cart;
            }
        }

        // Chứa các mặt hàng đã chọn
        public List<MONAN> Items = new List<MONAN>();

        public void Add(int id)
        {
            try // tìm thấy trong giỏ -> tăng số lượng lên 1
            {
                var item = Items.Single(i => i.MAMON == id);
                Quantity++;
            }
            catch // chưa có trong giỏ -> truy vấn CSDL và bỏ vào giỏ
            {
                var db = new QLNhaHangEntities();
                var item = db.MONANs.Find(id);
                Quantity = 1;
                Items.Add(item);
            }
        }

        public void Remove(int id)
        {
            var item = Items.Single(i => i.MAMON == id);
            Items.Remove(item);
        }

        public void Update(int id, int newQuantity)
        {
            var item = Items.Single(i => i.MAMON == id);
            Quantity = newQuantity;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public int Count
        {
            get
            {
                return Items.Count;
            }
        }

        public double? Total
        {
            get
            {
                return Items.Sum(p =>p.DONGIA * Quantity);
            }
        }
    }
}