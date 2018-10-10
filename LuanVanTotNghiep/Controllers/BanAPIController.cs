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
    public class BanAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<BAN> Get()
        {
            List<BAN> list = new List<BAN>();
            var results = db.sp_InsUpdDelBan(0 , 0, "", new bool(), "Get").ToList();
            foreach (var result in results)
            {
                var b = new BAN()
                {
                    MABAN = result.MABAN,
                    MATANG = result.MATANG,
                    TENBAN = result.TENBAN,
                    TRANGTHAIBAN = result.TRANGTHAIBAN
                };
                list.Add(b);
            }
            return list;
        }

        // Get by Id
        public BAN Get(int id)
        {

            BAN b = db.BANs.Find(id);
            if (b == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return b;
        }
        // Insert 
        public HttpResponseMessage Post(BAN b)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelBan(0, b.MATANG, b.TENBAN, b.TRANGTHAIBAN, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(BAN b)
        {
            List<sp_InsUpdDelBan_Result> list = new List<sp_InsUpdDelBan_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelBan(b.MABAN, b.MATANG, b.TENBAN, b.TRANGTHAIBAN, "Upd").ToList();
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
            List<sp_InsUpdDelBan_Result> list = new List<sp_InsUpdDelBan_Result>();
            var results = db.sp_InsUpdDelBan(id, id,"", new bool(), "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelBan(id, id, "", new bool(), "Del").ToList();
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
