using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuanVanTotNghiep.Common;
using LuanVanTotNghiep.Models;
using LuanVanTotNghiep.ViewModel;
using PagedList;

namespace LuanVanTotNghiep.Controllers
{
    public class HomeController : Controller
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public ActionResult Index(int? page)
        {
           
            var model = db.MONANs.Where(x => x.MAMON > 0).ToList();
            int PageSize = 8;
            int PageNumber = page ?? 1;
            var pagemodel = model.OrderBy(n => n.NGAYTAOMOI).ToPagedList(PageNumber, PageSize);
            //this.AddToastMessage("Thông báo ", "Chào mừng bạn đến với website của Thành Công", ToastType.Success);
            return View(pagemodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public PartialViewResult _nhahang()
        {
            var model = db.NHAHANGs.Where(x => x.MANHAHANG > 0).ToList();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult _shoppingcart()
        {
            var cart = Session[CommonConstantClient.CartSession];
            var list = new List<DatBan>();
            if (cart != null)
            {
                list = (List<DatBan>)cart;
            }

            return PartialView(list);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}