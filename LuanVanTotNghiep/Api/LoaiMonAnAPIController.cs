using LuanVanTotNghiep.Models;
using LuanVanTotNghiep.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LuanVanTotNghiep.Api
{
    public class LoaiMonAnAPIController : ApiController

    {

        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<LOAIMONAN> Get()
        {
            List <LOAIMONAN> lmalist = new List<LOAIMONAN>();
                var results = db.sp_InsUpdDelLoaiMonAn(0, "","Get").ToList();
                foreach (var result in results)
                {
                    var loaimonan = new LOAIMONAN()
                    {
                        MALOAI = result.MALOAI,
                        TENLOAI = result.TENLOAI
                    };
                    lmalist.Add(loaimonan);
                }
                return lmalist;
        }

        // Get by Id
        public LOAIMONAN Get(int id)
        {

                LOAIMONAN loaimonan = db.LOAIMONANs.Find(id);
                if (loaimonan == null)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }
                return loaimonan;
        }

        // Insert 
        public HttpResponseMessage Post(LOAIMONAN loaimonan)
        {
            if (ModelState.IsValid)
            {
                    var lmalist = db.sp_InsUpdDelLoaiMonAn(0, loaimonan.TENLOAI , "Ins").ToList();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, lmalist);
                    return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(LOAIMONAN loaimonan)
        {
            List<sp_InsUpdDelLoaiMonAn_Result> lmalist = new List<sp_InsUpdDelLoaiMonAn_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

                try
                {
                    lmalist = db.sp_InsUpdDelLoaiMonAn(loaimonan.MALOAI, loaimonan.TENLOAI, "Upd").ToList();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
            return Request.CreateResponse(HttpStatusCode.OK, lmalist);
        }

        // Delete employee By Id
        public HttpResponseMessage Delete(int id)
        {
                List<sp_InsUpdDelLoaiMonAn_Result> emplist = new List<sp_InsUpdDelLoaiMonAn_Result>();
                var results = db.sp_InsUpdDelLoaiMonAn(id, "", "GetById").ToList();
                if (results.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                try
                {
                    emplist = db.sp_InsUpdDelLoaiMonAn(id, "", "Del").ToList();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
                return Request.CreateResponse(HttpStatusCode.OK, emplist);
        }

        // Prevent Memory Leak
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
