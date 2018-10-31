using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuanVanTotNghiep.Common;
using LuanVanTotNghiep.Models;
using LuanVanTotNghiep.ViewModel;

namespace LuanVanTotNghiep.Controllers
{
    public class HomeController : Controller
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public ActionResult Index()
        {
           
            var model = db.MONANs.Where(x => x.MAMON > 0).ToList();
            return View(model);
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
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
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