using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuanVanTotNghiep.Models;

namespace LuanVanTotNghiep.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}