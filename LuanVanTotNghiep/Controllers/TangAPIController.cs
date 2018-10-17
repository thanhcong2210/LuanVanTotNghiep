using LuanVanTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;


namespace LuanVanTotNghiep.Controllers
{
    [RoutePrefix("api/TangAPI")]
    public class TangAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        [Route("")]
        [AcceptVerbs("GET", "HEAD")]
        public List<TANG> Get()
        {
            List<TANG> list = new List<TANG>();
            var results = db.sp_InsUpdDelTang(0, 0, "", "Get").ToList();
            foreach (var result in results)
            {
                var t = new TANG()
                {
                    MATANG = result.MATANG,
                    MANHAHANG = result.MANHAHANG,
                    TENTANG  =  result.TENTANG
                };
                list.Add(t);
            }
            return list;
        }

        // Get by Id
        public TANG Get(int id)
        {

            TANG t = db.TANGs.Find(id);
            if (t == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return t;
        }
        [HttpGet]
        [Route("getnhahang")]
        [AcceptVerbs("GET", "HEAD")]
        public List<NHAHANG> GetNhaHang()
        {
            List<NHAHANG> list = new List<NHAHANG>();
            var results = db.sp_InsUpdDelNhaHang(0, "", "", "", "Get").ToList();
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
        // Insert 
        [HttpPost]
        [Route("")]
        [AcceptVerbs("POST", "HEAD")]
        public HttpResponseMessage Post(TANG t)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelTang(0, t.MANHAHANG ,t.TENTANG, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [AcceptVerbs("PUT", "HEAD")]
        // Update 
        public HttpResponseMessage Put(TANG t)
        {
            List<sp_InsUpdDelTang_Result> list = new List<sp_InsUpdDelTang_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelTang(t.MATANG, t.MANHAHANG, t.TENTANG, "Upd").ToList();
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
            List<sp_InsUpdDelTang_Result> list = new List<sp_InsUpdDelTang_Result>();
            var results = db.sp_InsUpdDelTang(id, id, "", "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelTang(id, id, "", "Del").ToList();
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
