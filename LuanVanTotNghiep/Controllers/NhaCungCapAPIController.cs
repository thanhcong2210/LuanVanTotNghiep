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
    public class NhaCungCapAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<NHACUNGCAP> Get()
        {
            List<NHACUNGCAP> list = new List<NHACUNGCAP>();
            var results = db.sp_InsUpdDelNhaCungCap(0, "","","", "", "Get").ToList();
            foreach (var result in results)
            {
                var ncc = new NHACUNGCAP()
                {
                    MANCC = result.MANCC,
                    TEN_NCC  = result.TEN_NCC,
                    DIACHI_NCC = result.DIACHI_NCC,
                    SDT_NCC = result.SDT_NCC,
                    GHICHUTHEM = result.GHICHUTHEM
                };
                list.Add(ncc);
            }
            return list;
        }

        // Get by Id
        public NHACUNGCAP Get(int id)
        {

            NHACUNGCAP ncc = db.NHACUNGCAPs.Find(id);
            if (ncc == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return ncc;
        }
        // Insert 
        public HttpResponseMessage Post(NHACUNGCAP ncc)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelNhaCungCap(0, ncc.TEN_NCC, ncc.DIACHI_NCC, ncc.SDT_NCC, ncc.GHICHUTHEM, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(NHACUNGCAP ncc)
        {
            List<sp_InsUpdDelNhaCungCap_Result> list = new List<sp_InsUpdDelNhaCungCap_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelNhaCungCap(ncc.MANCC, ncc.TEN_NCC, ncc.DIACHI_NCC, ncc.SDT_NCC, ncc.GHICHUTHEM, "Upd").ToList();
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
            List<sp_InsUpdDelNhaCungCap_Result> list = new List<sp_InsUpdDelNhaCungCap_Result>();
            var results = db.sp_InsUpdDelNhaCungCap(id,"","", "", "", "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelNhaCungCap(id, "","","", "", "Del").ToList();
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
