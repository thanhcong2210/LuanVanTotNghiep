using LuanVanTotNghiep.Models.DAO;
using LuanVanTotNghiep.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LuanVanTotNghiep.Models;
using LuanVanTotNghiep.Common;

namespace LuanVanTotNghiep.Controllers
{
    public class giohangController : Controller
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        #region Giỏ hàng
        //Lấy giỏ hàng 
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int productID, int quantity, string strURL)
        {
            MONAN product = db.MONANs.SingleOrDefault(n => n.MAMON == productID);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sách này đã tồn tại trong session[giohang] chưa
            GioHang sanpham = lstGioHang.Find(n => n.iMa == productID);
            if (sanpham == null)
            {
                sanpham = new GioHang(productID);
                //Add sản phẩm mới thêm vào list
                sanpham.iSoLuong = quantity;
                lstGioHang.Add(sanpham);
                this.AddToastMessage("Thông báo", "Đặt món thành công! Vui lòng kiểm tra giỏ hàng ", ToastType.Info);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏ hàng 
        public ActionResult CapNhatGioHang(int iproductID, FormCollection f)
        {
            //Kiểm tra masp
            MONAN product = db.MONANs.SingleOrDefault(n => n.MAMON == iproductID);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMa == iproductID);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            this.AddToastMessage("Thông báo", "Cập nhật giỏ hàng thành công", ToastType.Info);
            return RedirectToAction("GioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iproductID)
        {
            //Kiểm tra masp
            MONAN product = db.MONANs.SingleOrDefault(n => n.MAMON == iproductID);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMa == iproductID);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMa == iproductID);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            this.AddToastMessage("Thông báo", "Xóa bỏ giỏ hàng thành công", ToastType.Warning);
            return RedirectToAction("GioHang");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            else
            {
                iTongSoLuong = 0;
            }
            return iTongSoLuong;
        }
        //Tính tổng số lượng
        private int TongSoMon()
        {
            int iTongSoMon = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;

            if (lstGioHang != null)
            {
                iTongSoMon = lstGioHang.Sum(n => n.iMa);
            }
            else
            {
                iTongSoMon = 0;
            }
            return iTongSoMon;
        }
        //Tính tổng thành tiền
        private double? TongTien()
        {
            double? dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            else
            {
                dTongTien = 0;
            }
            return dTongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);

        }

        public ActionResult XoaTatCa()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            lstGioHang.Clear();
            return RedirectToAction("GioHang");
        }
        #endregion

        #region Đặt hàng
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang(string address)
        {
            //Kiểm tra đăng đăng nhập
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            GIOHANG ddh = new GIOHANG();
            var session = (getInfoKhachHang)Session[CommonConstantClient.TaiKhoan];
            List<GioHang> gh = LayGioHang();
            ddh.MAKH = session.ID;
            ddh.NGAYDAT = DateTime.Now;
            ddh.DIACHINHAN = address;
            ddh.TRANGTHAI = false;
            db.GIOHANGs.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                CHITIETGIOHANG ctDH = new CHITIETGIOHANG();
                ctDH.MAGH = ddh.MAGH;
                ctDH.MAMON = item.iMa;
                ctDH.SLUONG = item.iSoLuong;
                db.CHITIETGIOHANGs.Add(ctDH);
            }
            db.SaveChanges();
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            lstGioHang.Clear();
            this.AddToastMessage("Thông báo", "Đặt hàng thành công", ToastType.Info);
            return RedirectToAction("Index", "Home");
        }
        #endregion
        //public ActionResult Index()
        //{
        //    var cart = ShoppingCart.Cart;
        //    return View(cart.Items);
        //}
        //public ActionResult Add(int id)
        //{
        //    var cart = ShoppingCart.Cart;
        //    cart.Add(id);

        //    var info = new { cart.Count, cart.Total };
        //    return Json(info, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult Remove(int id)
        //{
        //    var cart = ShoppingCart.Cart;
        //    cart.Remove(id);

        //    var info = new { cart.Count, cart.Total };
        //    return Json(info, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult Update(int id, int quantity)
        //{
        //    var cart = ShoppingCart.Cart;
        //    cart.Update(id, quantity);

        //    var p = cart.Items.Single(i => i.MAMON == id);
        //    var info = new
        //    {
        //        cart.Count,
        //        cart.Total                
        //    };
        //    return Json(info, JsonRequestBehavior.AllowGet);
        //}


        //// GET: giohang
        //private const string CartSession = "CartSession";

        //// GET: Cart
        //public ActionResult Index()
        //{            
        //    var cart = Session[CartSession];
        //    var list = new List<CartItem>();
        //    if (cart != null)
        //    {
        //        list = (List<CartItem>)cart;
        //    }
        //    return View(list);
        //}
        //public JsonResult Update(string cartModel)
        //{
        //    var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
        //    var sessionCart = (List<CartItem>)Session[CartSession];

        //    foreach (var item in sessionCart)
        //    {
        //        var jsonItem = jsonCart.SingleOrDefault(x => x.product.MAMON == item.product.MAMON);
        //        if (jsonItem != null)
        //        {
        //            item.Quantity = jsonItem.Quantity;
        //        }
        //    }
        //    Session[CartSession] = sessionCart;
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}

        //public JsonResult Delete(int id)
        //{
        //    var sessionCart = (List<CartItem>)Session[CartSession];
        //    sessionCart.RemoveAll(x => x.product.MAMON == id);
        //    Session[CartSession] = sessionCart;
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}

        //public JsonResult DeleteAll()
        //{
        //    Session[CartSession] = null;
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}

        //public double? tongtien()
        //{
        //    List<CartItem> giohang = Session["CartSession"] as List<CartItem>;
        //    if (Session["CartSession"] == null)
        //    {
        //        return 0;
        //    }
        //    return giohang.Sum(i => i.Total);
        //}
        ////public double tongsl()
        ////{
        ////    List<CartItem> giohang = Session["CartSession"] as List<CartItem>;
        ////    return giohang.Sum(i => i.Quantity);
        ////}
        //public RedirectToRouteResult SuaSoLuong(int MonAnID, int soluongmoi)
        //{
        //    // tìm carditem muon sua
        //    List<CartItem> giohang = Session["CartSession"] as List<CartItem>;
        //    CartItem itemSua = giohang.FirstOrDefault(m => m.product.MAMON == MonAnID);
        //    if (itemSua != null)
        //    {
        //        itemSua.Quantity = soluongmoi;
        //    }
        //    return RedirectToAction("Index");

        //}

        //public RedirectToRouteResult XoaKhoiGio(int MonAnID)
        //{
        //    List<CartItem> giohang = Session["CartSession"] as List<CartItem>;
        //    CartItem itemXoa = giohang.FirstOrDefault(m => m.product.MAMON == MonAnID);
        //    if (itemXoa != null)
        //    {
        //        giohang.Remove(itemXoa);
        //    }
        //    return RedirectToAction("Index");
        //}
        //[ChildActionOnly]
        //public PartialViewResult _shoppingcart()
        //{
        //    //ViewBag.TongSoLuong = tongsl();
        //    ViewBag.TongTien = tongtien();
        //    return PartialView();
        //}
        //public ActionResult AddItem(int productId, int quantity, string strURL)
        //{
        //    var product = new ProductDAO().ViewDetail(productId);
        //    var cart = Session[CartSession];
        //    if (cart != null)
        //    {
        //        var list = (List<CartItem>)cart;
        //        if (list.Exists(x => x.product.MAMON == productId))
        //        {
        //            foreach (var item in list)
        //            {
        //                if (item.product.MAMON == productId)
        //                {
        //                    item.Quantity += quantity;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            // tạo mới cart item 
        //            var item = new CartItem();
        //            item.product = product;
        //            item.Quantity = quantity;

        //            list.Add(item);
        //        }
        //        Session[CartSession] = list;

        //    }
        //    else
        //    {
        //        // tạo mới cart item 
        //        var item = new CartItem();
        //        item.product = product;
        //        item.Quantity = quantity;

        //        var list = new List<CartItem>();
        //        list.Add(item);
        //        // Gán vào session
        //        Session[CartSession] = list;

        //    }
        //    return PartialView("_shoppingcart");
        //}
    }
}