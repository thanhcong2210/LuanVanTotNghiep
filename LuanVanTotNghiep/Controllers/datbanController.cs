using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuanVanTotNghiep.Common;
using LuanVanTotNghiep.Models;
using LuanVanTotNghiep.Models.DAO;
using LuanVanTotNghiep.ViewModel;

namespace LuanVanTotNghiep.Controllers
{
    public class datbanController : Controller
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // GET: datban
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DatBan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DatBan(DatBan datBan)
        {
            var dao = new DatBanDAO();
            if (ModelState.IsValid)
            {
                var session = (getInfoKhachHang)Session[CommonConstantClient.TaiKhoan];
                var dat = new DONDATBAN();
                dat.MAKH = session.ID;
                dat.SOLUONGNGUOI = datBan.SoLuong;
                dat.NGAYDEN = datBan.ngayden;
                dat.GIODEN = datBan.gioden;
                dat.TRANGTHAIDATBAN = false;

                var result = dao.Inser(dat);
                if (result > 0)
                {
                    this.AddToastMessage("Thông báo", "Đặt bàn thành công", ToastType.Info);
                    //ViewBag.Success = "Đặt bàn thành công";
                    datBan = new DatBan();
                    return Redirect("/");
                }
                else
                {
                    this.AddToastMessage("Lỗi", "Đặt bàn thành công", ToastType.Error);
                    //ModelState.AddModelError("", "Đặt bàn không thành công.");
                }
            }
            
            return View(datBan);
        }

    }
};