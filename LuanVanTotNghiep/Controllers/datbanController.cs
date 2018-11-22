using System;
using System.Collections.Generic;
using System.Configuration;
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
            var dao_kh = new CustomerDAO();
            if (ModelState.IsValid)
            {
                var session = (getInfoKhachHang)Session[CommonConstantClient.TaiKhoan];
                var dat = new DONDATBAN();
                var kh = new KHACHHANG();
                if (session == null)
                {
                    kh.MALOAI_KH = 2;
                    kh.HOTEN_KH = datBan.hoten;
                    kh.SDT_KH = datBan.sdt;
                    kh.EMAIL_KH = datBan.email;
                    var result_kh = dao_kh.Insert(kh);
                    if ( result_kh > 0 )
                    {
                        dat.MAKH = kh.MAKH;
                        dat.SOLUONGNGUOI = datBan.SoLuong;
                        dat.NGAYDEN = datBan.ngayden;
                        dat.GIODEN = datBan.gioden;
                        dat.TRANGTHAIDATBAN = false;
                        var result_datban = dao.Inser(dat);
                        
                        if (result_datban > 0)
                        {
                            kh.MADATBAN = dat.MADATBAN;
                            var update_data = dao_kh.Update_DatBan(kh);
                            if (update_data > 0)
                            {
                                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/template/datban.html"));
                                content = content.Replace("{{CustomerName}}", datBan.hoten);
                                content = content.Replace("{{Phone}}", datBan.sdt);
                                content = content.Replace("{{Email}}", datBan.email);
                                content = content.Replace("{{SoLuong}}", datBan.SoLuong.ToString());
                                content = content.Replace("{{NgayDen}}", datBan.ngayden.Value.ToString("dd/MM/yyyy"));
                                content = content.Replace("{{GioDen}}", datBan.gioden.Value.ToString("hh:mm:ss"));
                                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                                new MailHelper().SendMail(datBan.email, "Đơn hàng mới từ Nhà Hàng Thành Công", content);
                                //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ Nhà Hàng Thành Công", content);

                                this.AddToastMessage("Thông báo", "Đặt bàn thành công", ToastType.Info);
                                //ViewBag.Success = "Đặt bàn thành công";
                                datBan = new DatBan();
                                return Redirect("/");
                            }
                            else
                            {
                                this.AddToastMessage("Lỗi", "Đặt bàn thành công", ToastType.Error);
                            }
                        }
                        else
                        {
                            this.AddToastMessage("Lỗi", "Đặt bàn thành công", ToastType.Error);
                            //ModelState.AddModelError("", "Đặt bàn không thành công.");
                        }
                    }
                }
                else
                {
                    dat.MAKH = session.ID;
                    dat.SOLUONGNGUOI = datBan.SoLuong;
                    dat.NGAYDEN = datBan.ngayden;
                    dat.GIODEN = datBan.gioden;
                    dat.TRANGTHAIDATBAN = false;
                }
                var result = dao.Inser(dat);
                if (result > 0)
                {
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/template/datban.html"));
                    content = content.Replace("{{CustomerName}}", session.Name);
                    content = content.Replace("{{Phone}}", session.Mobile);
                    content = content.Replace("{{Email}}", session.Email);
                    content = content.Replace("{{SoLuong}}", datBan.SoLuong.ToString());
                    content = content.Replace("{{NgayDen}}", datBan.ngayden.Value.ToString("dd/MM/yyyy"));
                    content = content.Replace("{{GioDen}}", datBan.gioden.Value.ToString("hh:mm:ss"));
                    var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                    new MailHelper().SendMail(session.Email, "Đơn hàng mới từ Nhà Hàng Thành Công", content);
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