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
    public class ChucVuAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<CHUCVU> Get()
        {
            List<CHUCVU> list = new List<CHUCVU>();
            var results = db.sp_InsUpdDelChucVu(0,"", "", "Get").ToList();
            foreach (var result in results)
            {
                var cv = new CHUCVU()
                {
                    MACV = result.MACV,
                    TENCV = result.TENCV,
                    MOTACV = result.MOTACV
                };
                list.Add(cv);
            }
            return list;
        }

        // Get by Id
        public CHUCVU Get(int id)
        {

            CHUCVU cv = db.CHUCVUs.Find(id);
            if (cv == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return cv;
        }
        // Insert 
        public HttpResponseMessage Post(CHUCVU cv)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelChucVu(0, cv.TENCV, cv.MOTACV , "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(CHUCVU cv)
        {
            List<sp_InsUpdDelChucVu_Result> list = new List<sp_InsUpdDelChucVu_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelChucVu(cv.MACV, cv.TENCV, cv.MOTACV, "Upd").ToList();
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
            List<sp_InsUpdDelChucVu_Result> list = new List<sp_InsUpdDelChucVu_Result>();
            var results = db.sp_InsUpdDelChucVu(id, "", "", "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelChucVu(id, "", "", "Del").ToList();
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
