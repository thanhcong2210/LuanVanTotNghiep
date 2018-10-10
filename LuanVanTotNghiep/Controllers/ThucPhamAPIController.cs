using LuanVanTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LuanVanTotNghiep.Controllers
{
    public class ThucPhamAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<THUCPHAM> Get()
        {
            List<THUCPHAM> list = new List<THUCPHAM>();
            var results = db.sp_InsUpdDelThucPham(0, "", "" , "Get").ToList();
            foreach (var result in results)
            {
                var tp = new THUCPHAM()
                {
                    MATHUCPHAM = result.MATHUCPHAM,
                    TENTHUCPHAM = result.TENTHUCPHAM,
                    DVTINH = result.DVTINH
                };
                list.Add(tp);
            }
            return list;
        }

        // Get by Id
        public THUCPHAM Get(int id)
        {

            THUCPHAM tp = db.THUCPHAMs.Find(id);
            if (tp == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return tp;
        }
        // Insert 
        public HttpResponseMessage Post(THUCPHAM tp)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelThucPham(0, tp.TENTHUCPHAM, tp.DVTINH, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(THUCPHAM tp)
        {
            List<sp_InsUpdDelThucPham_Result> list = new List<sp_InsUpdDelThucPham_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelThucPham(tp.MATHUCPHAM, tp.TENTHUCPHAM, tp.DVTINH, "Upd").ToList();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // Delete employee By Id
        public HttpResponseMessage Delete(int id)
        {
            List<sp_InsUpdDelThucPham_Result> list = new List<sp_InsUpdDelThucPham_Result>();
            var results = db.sp_InsUpdDelThucPham(id, "", "" , "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelThucPham(id, "", "", "Del").ToList();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // Prevent Memory Leak
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
