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
    public class NhaHangAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<NHAHANG> Get()
        {
            List<NHAHANG> list = new List<NHAHANG>();
            var results = db.sp_InsUpdDelNhaHang(0, "","", "", "Get").ToList();
            foreach (var result in results)
            {
                var t = new NHAHANG()
                {
                    MANHAHANG = result.MANHAHANG,
                    TENNHAHANG = result.TENNHAHANG,
                    SDT = result.SDT,
                    GIOITHIEU = result.GIOITHIEU
                };
                list.Add(t);
            }
            return list;
        }

        // Get by Id
        public NHAHANG Get(int id)
        {

            NHAHANG t = db.NHAHANGs.Find(id);
            if (t == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return t;
        }
        // Insert 
        public HttpResponseMessage Post(NHAHANG t)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelNhaHang(0, t.TENNHAHANG,t.SDT, t.GIOITHIEU, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(NHAHANG t)
        {
            List<sp_InsUpdDelNhaHang_Result> list = new List<sp_InsUpdDelNhaHang_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelNhaHang(t.MANHAHANG, t.TENNHAHANG, t.SDT, t.GIOITHIEU, "Upd").ToList();
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
            List<sp_InsUpdDelNhaHang_Result> list = new List<sp_InsUpdDelNhaHang_Result>();
            var results = db.sp_InsUpdDelNhaHang(id, "","", "", "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelNhaHang(id, "","", "", "Del").ToList();
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
