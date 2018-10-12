using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuanVanTotNghiep.Models;

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
    }
}