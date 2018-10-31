using LuanVanTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace LuanVanTotNghiep.Api
{
    public class HinhAnhAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<HINHANH> Get()
        {
            List<HINHANH> list = new List<HINHANH>();
            var results = db.sp_InsUpdDelHinhAnh(0,"", "", "", "", "Get").ToList();
            foreach (var result in results)
            {
                var ha = new HINHANH()
                {
                    MAHINHANH = result.MAHINHANH,
                    TENHINHANH = result.TENHINHANH,
                    DUONGDAN1 = result.DUONGDAN1,
                    DUONGDAN2 = result.DUONGDAN2,
                    DUONGDAN3 = result.DUONGDAN3,
                };
                list.Add(ha);
            }
            return list;
        }

        //// Get by Id
        public HINHANH Get(int id)
        {

            HINHANH ha = db.HINHANHs.Find(id);
            if (ha == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return ha;
        }
        // Insert 
        public HttpResponseMessage Post(HINHANH ha)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelHinhAnh(0,ha.TENHINHANH, ha.DUONGDAN1, ha.DUONGDAN2, ha.DUONGDAN3, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }
        

        // Update 
        public HttpResponseMessage Put(HINHANH ha)
        {
            List<sp_InsUpdDelHinhAnh_Result> list = new List<sp_InsUpdDelHinhAnh_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelHinhAnh(ha.MAHINHANH, ha.TENHINHANH, ha.DUONGDAN1, ha.DUONGDAN2, ha.DUONGDAN3, "Upd").ToList();
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
            List<sp_InsUpdDelHinhAnh_Result> list = new List<sp_InsUpdDelHinhAnh_Result>();
            var results = db.sp_InsUpdDelHinhAnh(id,"", "", "", "" , "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelHinhAnh(id,"", "","","", "Del").ToList();
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
