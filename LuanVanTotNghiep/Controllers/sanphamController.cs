using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuanVanTotNghiep.Models;

namespace LuanVanTotNghiep.Controllers
{
    public class sanphamController : Controller
    {
        // GET: Product
        QLNhaHangEntities db = new QLNhaHangEntities();
        public ActionResult Index(int id)
        {
            return View();
        }

        public ActionResult chitiet(int id)
        {
            var sp = db.MONANs.Find(id);
            var idCategory = sp.MALOAI;
            ViewBag.Category = db.LOAIMONANs.Find(idCategory);
            return View(sp);
        }

        [ChildActionOnly]
        public PartialViewResult _loaimonan()
        {
            var model = db.LOAIMONANs.Where(x => x.MALOAI > 0).ToList();
            return PartialView(model);
        }
    }
}