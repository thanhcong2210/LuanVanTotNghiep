using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using LuanVanTotNghiep.Models;
using LuanVanTotNghiep.Models.DAO;
using LuanVanTotNghiep.ViewModel;
using LuanVanTotNghiep.Common;
using PagedList;
using Facebook;
using System.Configuration;

namespace LuanVanTotNghiep.Controllers
{
    public class NguoiDungController : Controller
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }

        [HttpPost]
        //[CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        public ActionResult DangKy(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.CheckUserName(model.UserName))
                {
                    this.AddToastMessage("Lỗi", "Tên đăng nhập đã tồn tại! Vui lòng thử lại.", ToastType.Error);
                    //ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    this.AddToastMessage("Lỗi", "Email đã tồn tại! Vui lòng thử lại.", ToastType.Error);
                    //ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new KHACHHANG();
                    user.HOTEN_KH = model.Name;
                    user.MALOAI_KH = 2;
                    user.TENDANGNHAP_KH = model.UserName;
                    user.MATKHAU_KH = model.Password;
                    user.SDT_KH = model.Phone;
                    user.EMAIL_KH = model.Email;
                    user.DIACHI_KH = model.Address;
                    user.NGAYSINH_KH = model.Birthday;
                    user.GIOITINH_KH = model.Sex;

                    var result = dao.Inser(user);
                    if (result > 0)
                    {
                        //ViewBag.Success = "Đăng ký thành công";
                        this.AddToastMessage("Thông báo", "Đăng ký thành viên mới thành công!", ToastType.Success);
                        model = new RegisterModel();
                        return Redirect("/");
                    }
                    else
                    {
                        //ModelState.AddModelError("", "Đăng ký không thành công.");
                        this.AddToastMessage("Thông báo", "Đăng ký thành viên mới không thành công!", ToastType.Error);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DangNhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TENDANGNHAP_KH == sTaiKhoan && n.MATKHAU_KH == sMatKhau);
            var dao = new UserDAO();
            var kq = dao.Login(sTaiKhoan, sMatKhau);
            if (kq == 1)
            {
                var tkSession = new getInfoKhachHang();
                tkSession.Name = kh.HOTEN_KH;
                tkSession.Username = kh.TENDANGNHAP_KH;
                tkSession.ID = kh.MAKH;
                Session.Add(CommonConstantClient.TaiKhoan, tkSession);
                this.AddToastMessage("Thông báo ", "Đăng nhập thành công", ToastType.Success);
                //Session["TaiKhoan"] = kh;
                return Redirect("/");
            }
            else if (kq == -1)
            {
                this.AddToastMessage("Lỗi ", "Tên đăng nhập sai!", ToastType.Warning);
            }
            else if (kq == 0)
            {
                this.AddToastMessage("Lỗi ", "Mật khẩu không đúng! Vui lòng nhập lại", ToastType.Error);
                ViewBag.ThongBao = "Mật khẩu không đúng! Vui lòng nhập lại";
            }
            return View();
        }

        //Hiển thị chi tiết
        public ActionResult thongtinchitiet(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            //Bao gồm tất cả danh sách chapter của book theo id chỉ định
            var viewModel = db.KHACHHANGs.SingleOrDefault(s => s.MAKH == id);
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
        //chỉnh sửa thông tin
        public ActionResult chinhsuathongtin(int? id)
        {
            return View();
        }
        //danh sách giỏ hàng
        public ActionResult thongtingiohang(int? id, int? page)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            //Bao gồm tất cả danh sách chapter của book theo id chỉ định
            var viewModel = db.GIOHANGs.Where(s => s.MAKH == id).ToList();
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            int PageSize = 3;
            int PageNumber = page ?? 1;
            var pageviewModel = viewModel.OrderBy(n => n.MAGH).ToPagedList(PageNumber, PageSize);
            return View(pageviewModel);
        }
        //danh sách đặt bàn
        public ActionResult thongtindondatban(int? id, int? page)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            //Bao gồm tất cả danh sách chapter của book theo id chỉ định
            var viewModel = db.DONDATBANs.Where(s => s.MAKH == id).ToList();
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            int PageSize = 3;
            int PageNumber = page ?? 1;
            var pageviewModel = viewModel.OrderBy(n => n.MADATBAN).ToPagedList(PageNumber, PageSize);
            return View(pageviewModel);
        }

        public ActionResult DangXuat()
        {
            Session[CommonConstantClient.TaiKhoan] = null;
            this.AddToastMessage("Thông báo ", "Đăng xuất thành công", ToastType.Info);
            return Redirect("/");
        }

        //dang nhap facebook
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        [AllowAnonymous]
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });


            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=id,email,first_name,middle_name,last_name");
                string email = me.email;
                string userName = me.email;
                //string hotenfb = me.hoten;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;
                var user = new KHACHHANG();
                user.EMAIL_KH = email;
                user.TENDANGNHAP_KH = email;
                user.MALOAI_KH = 2;
                //user.Status = true;
                user.HOTEN_KH = firstname + " " + middlename + " " + lastname;
                //user.CreatedDate = DateTime.Now;
                var resultInsert = new UserDAO().InsertForFacebook(user);
                if (resultInsert = true)
                {
                    var userSession = new getInfoKhachHang();
                    userSession.Username = user.TENDANGNHAP_KH;
                    userSession.ID = user.MAKH;
                    Session.Add(CommonConstantClient.TaiKhoan, userSession);
                }
            }
            return Redirect("/");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}