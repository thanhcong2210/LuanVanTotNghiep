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
    public class DonViTinhAPIController : ApiController
    {

        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<DONVITINH> Get()
        {
            List<DONVITINH> list = new List<DONVITINH>();
            var results = db.sp_InsUpdDelDonViTinh(0, "", "Get").ToList();
            foreach (var result in results)
            {
                var dvtinh = new DONVITINH()
                {
                    MADVTINH = result.MADVTINH,
                    TENDVTINH = result.TENDVTINH
                };
                list.Add(dvtinh);
            }
            return list;
        }

        // Get by Id
        public DONVITINH Get(int id)
        {

            DONVITINH dvtinh = db.DONVITINHs.Find(id);
            if (dvtinh == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return dvtinh;
        }

        // Insert 
        public HttpResponseMessage Post(DONVITINH dvtinh)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelDonViTinh(0, dvtinh.TENDVTINH, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(DONVITINH dvtinh)
        {
            List<sp_InsUpdDelDonViTinh_Result> list = new List<sp_InsUpdDelDonViTinh_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelDonViTinh(dvtinh.MADVTINH, dvtinh.TENDVTINH, "Upd").ToList();
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
            List<sp_InsUpdDelDonViTinh_Result> list = new List<sp_InsUpdDelDonViTinh_Result>();
            var results = db.sp_InsUpdDelDonViTinh(id, "", "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelDonViTinh(id, "", "Del").ToList();
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
