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
    public class MonAnAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public MonAnAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // Get All
        [HttpGet]
        public List<MONAN> Get()
        {
            List<MONAN> list = new List<MONAN>();
            var results = db.sp_InsUpdDelMonAn(0, 0, 0, 0,"", new float() ,"","", new DateTime(1990, 10, 20), "Get").ToList();
            foreach (var result in results)
            {
                var m = new MONAN()
                {
                    MAMON = result.MAMON,
                    MADVTINH = result.MADVTINH,
                    MAHINHANH = result.MAHINHANH,
                    MALOAI = result.MALOAI,
                    TENGOI = result.TENGOI,
                    DONGIA =result.DONGIA,
                    MOTA = result.MOTA,
                    CACHLAM =result.CACHLAM,
                    NGAYTAOMOI = result.NGAYTAOMOI ?? DateTime.Now
                };
                list.Add(m);
            }
            return list;
        }

        // Get by Id
        public MONAN Get(int id)
        {

            MONAN m = db.MONANs.Find(id);
            if (m == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return m;
        }
        // Insert 
        public HttpResponseMessage Post(MONAN m)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelMonAn(0, m.MADVTINH,m.MALOAI, m.MAHINHANH, m.TENGOI, m.DONGIA, m.MOTA, m.CACHLAM, m.NGAYTAOMOI , "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(MONAN m)
        {
            List<sp_InsUpdDelMonAn_Result> list = new List<sp_InsUpdDelMonAn_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelMonAn(m.MAMON, m.MADVTINH, m.MALOAI, m.MAHINHANH, m.TENGOI, m.DONGIA, m.MOTA, m.CACHLAM, m.NGAYTAOMOI, "Upd").ToList();
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
            List<sp_InsUpdDelMonAn_Result> list = new List<sp_InsUpdDelMonAn_Result>();
            var results = db.sp_InsUpdDelMonAn(id, id, id, id, "", new float(), "", "", new DateTime(), "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelMonAn(id, id, id, id, "", new float(), "", "", new DateTime(), "Del").ToList();
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
