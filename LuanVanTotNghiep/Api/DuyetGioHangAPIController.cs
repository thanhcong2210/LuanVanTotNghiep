using LuanVanTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LuanVanTotNghiep.Api
{
    [RoutePrefix("api/DuyetGioHangAPI")]
    public class DuyetGioHangAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public DuyetGioHangAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // Get All
        [HttpGet]
        [Route("")]
        [AcceptVerbs("GET", "HEAD")]
        public List<DUYETGIOHANG> Get()
        {
            List<DUYETGIOHANG> list = new List<DUYETGIOHANG>();
            var results = db.sp_InsUpdDelDuyetGioHang(0, new int(), new int(), new DateTime(1990,01,01), new bool(), "Get").ToList();
            foreach (var result in results)
            {
                var b = new DUYETGIOHANG()
                {
                    MADUYET = result.MADUYET,
                    MATAIKHOAN = result.MATAIKHOAN,
                    MAGH = result.MAGH,
                    NGAYDUYET = result.NGAYDUYET ?? DateTime.Now,
                    TRANGTHAIDUYET = result.TRANGTHAIDUYET
                };
                list.Add(b);
            }
            return list;
        }

        // Get by Id
        public DUYETGIOHANG Get(int id)
        {

            DUYETGIOHANG b = db.DUYETGIOHANGs.Find(id);
            if (b == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return b;
        }

        [HttpPost]
        [Route("")]
        [AcceptVerbs("POST", "HEAD")]
        // Insert 
        public HttpResponseMessage Post(DUYETGIOHANG b)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelDuyetGioHang(0, b.MATAIKHOAN, b.MAGH, b.NGAYDUYET, b.TRANGTHAIDUYET, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [Route("")]
        [AcceptVerbs("PUT", "HEAD")]
        // Update 
        public HttpResponseMessage Put(DUYETGIOHANG b)
        {
            List<sp_InsUpdDelDuyetGioHang_Result> list = new List<sp_InsUpdDelDuyetGioHang_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelDuyetGioHang(b.MADUYET, b.MATAIKHOAN, b.MAGH, b.NGAYDUYET, b.TRANGTHAIDUYET, "Upd").ToList();
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
            List<sp_InsUpdDelDuyetGioHang_Result> list = new List<sp_InsUpdDelDuyetGioHang_Result>();
            var results = db.sp_InsUpdDelDuyetGioHang(id, id, id, new DateTime(), new bool(), "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelDuyetGioHang(id, id, id, new DateTime(), new bool(), "Del").ToList();
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
