using LuanVanTotNghiep.Areas.Admin.Common;
using LuanVanTotNghiep.Areas.Admin.Models;
using LuanVanTotNghiep.Areas.Admin.Models.DAO;
using LuanVanTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuanVanTotNghiep.Areas.Admin.Controllers
{
    
    public class LoginController : Controller
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                var result = dao.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = dao.GetByMATAIKHOAN(model.UserName);
                    var tkSession = new TaiKhoanLogin();
                    tkSession.Username = user.TENDANGNHAP;
                    tkSession.TKID = user.MATAIKHOAN;
                    Session.Add(CommonConstants.TAIKHOAN_SESSION, tkSession);
                    return RedirectToAction("Index", "Home");

                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại ! ");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Mật khẩu sai! Vui lòng nhập lại ");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.TAIKHOAN_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}