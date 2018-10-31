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
    public class PhieuNhapAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<PHIEUNHAP> Get()
        {
            List<PHIEUNHAP> list = new List<PHIEUNHAP>();
            var results = db.sp_InsUpdDelPhieuNhap(0, 0 , new DateTime(1990,10,20), "Get").ToList();
            foreach (var result in results)
            {
                var pn = new PHIEUNHAP()
                {
                    MAPHIEUNHAP = result.MAPHIEUNHAP,
                    MANCC = result.MANCC,
                    NGAYNHAP = result.NGAYNHAP ?? DateTime.Now
                };
                list.Add(pn);
            }
            return list;
        }

        // Get by Id
        public PHIEUNHAP Get(int id)
        {

            PHIEUNHAP pn = db.PHIEUNHAPs.Find(id);
            if (pn == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return pn;
        }
        // Insert 
        public HttpResponseMessage Post(PHIEUNHAP pn)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelPhieuNhap(0, pn.MANCC, pn.NGAYNHAP, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(PHIEUNHAP pn)
        {
            List<sp_InsUpdDelPhieuNhap_Result> list = new List<sp_InsUpdDelPhieuNhap_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelPhieuNhap(pn.MAPHIEUNHAP, pn.MANCC, pn.NGAYNHAP, "Upd").ToList();
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
            List<sp_InsUpdDelPhieuNhap_Result> list = new List<sp_InsUpdDelPhieuNhap_Result>();
            var results = db.sp_InsUpdDelPhieuNhap(id, id, new DateTime(), "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelPhieuNhap(id, id, new DateTime(), "Del").ToList();
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
