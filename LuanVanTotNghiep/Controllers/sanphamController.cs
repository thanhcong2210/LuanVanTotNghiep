using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuanVanTotNghiep.Models;
using LuanVanTotNghiep.Models.DAO;
using PagedList;
using LuanVanTotNghiep.ViewModel;

namespace LuanVanTotNghiep.Controllers
{
    public class sanphamController : Controller
    {
        // GET: Product
        QLNhaHangEntities db = new QLNhaHangEntities();
        public ActionResult Index(int? page)
        {
            var model = db.MONANs.Where(x => x.MAMON > 0).ToList();
            int PageSize = 3;
            int PageNumber = page ?? 1;
            var pagemodel =  model.OrderBy(n => n.MAMON).ToPagedList(PageNumber, PageSize);
            return View(pagemodel);
        }

        public ActionResult chitiet(int id)
        {
            var sp = db.MONANs.Find(id);
            ViewBag.Name = db.MONANs.Find(id);
            var idCategory = sp.MALOAI;
            ViewBag.Category = db.LOAIMONANs.Find(idCategory);
            ViewBag.cateProduct = db.MONANs.Find(idCategory);
            return View(sp);
        }

        //public ActionResult loaimon(int id, int page = 1, int pageSize = 1)
        //{
        //    var category = new CategoryDAO().ViewDetail(id);
        //    ViewBag.Category = category;
        //    int totalRecord = 0;
        //    var model = new ProductDAO().ListByCategoryId(id, ref totalRecord, page, pageSize);

        //    ViewBag.Total = totalRecord;
        //    ViewBag.Page = page;

        //    int maxPage = 5;
        //    int totalPage = 0;

        //    totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
        //    ViewBag.TotalPage = totalPage;
        //    ViewBag.MaxPage = maxPage;
        //    ViewBag.First = 1;
        //    ViewBag.Last = totalPage;
        //    ViewBag.Next = page + 1;
        //    ViewBag.Prev = page - 1;

        //    return View(model);
        //}
        public ActionResult loaimon(int? page, int id)
        {
            var category = new CategoryDAO().ViewDetail(id);
            ViewBag.Category = category;
            var listSP = db.MONANs.Where(n => n.MALOAI == id).ToList();
            int PageSize = 3;
            int PageNumber = page ?? 1;
            return View(listSP.OrderBy(n => n.MALOAI).ToPagedList(PageNumber, PageSize));
        }






        [ChildActionOnly]
        public PartialViewResult _loaimonan()
        {
            var model = db.LOAIMONANs.Where(x => x.MALOAI > 0).ToList();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult _categories()
        {
            var model = db.LOAIMONANs.Where(x => x.MALOAI > 0).ToList();
            return PartialView(model);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}