using LuanVanTotNghiep.Models;
using LuanVanTotNghiep.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LuanVanTotNghiep.Areas.Admin.ViewModelAdmin;

namespace LuanVanTotNghiep.Api
{
    public class PhieuNhapAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public IEnumerable<PhieuNhapViewModel> Get()
        {

            List<PHIEUNHAP> ListpNhap = new List<PHIEUNHAP>();
            var query = from p in db.PHIEUNHAPs
                        join n in db.NHACUNGCAPs
                        on p.MANCC equals n.MANCC
                        select new PhieuNhapViewModel()
                        {
                            MANCC = p.MANCC,
                            MAPHIEUNHAP = p.MAPHIEUNHAP,
                            NGAYNHAP = p.NGAYNHAP,
                            TENNCC = n.TEN_NCC
                        };

            return query;
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
