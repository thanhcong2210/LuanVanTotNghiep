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
    public class LoaiKhachHangAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<LOAIKHACHHANG> Get()
        {
            List<LOAIKHACHHANG> lmalist = new List<LOAIKHACHHANG>();
            var results = db.sp_InsUpdDelLoaiKhachHang(0,"","", "Get").ToList();
            foreach (var result in results)
            {
                var lkh = new LOAIKHACHHANG()
                {
                    MALOAI_KH = result.MALOAI_KH,
                    TENLOAI_KH = result.TENLOAI_KH,
                    MOTALOAI_KH = result.MOTALOAI_KH
                };
                lmalist.Add(lkh);
            }
            return lmalist;
        }

        // Get by Id
        public LOAIKHACHHANG Get(int id)
        {

            LOAIKHACHHANG lkh = db.LOAIKHACHHANGs.Find(id);
            if (lkh == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return lkh;
        }

        // Insert 
        public HttpResponseMessage Post(LOAIKHACHHANG lkh)
        {
            if (ModelState.IsValid)
            {
                var lmalist = db.sp_InsUpdDelLoaiKhachHang(0, lkh.TENLOAI_KH, lkh.MOTALOAI_KH, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, lmalist);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(LOAIKHACHHANG lkh)
        {
            List<sp_InsUpdDelLoaiKhachHang_Result> lmalist = new List<sp_InsUpdDelLoaiKhachHang_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                lmalist = db.sp_InsUpdDelLoaiKhachHang(lkh.MALOAI_KH, lkh.TENLOAI_KH, lkh.MOTALOAI_KH, "Upd").ToList();
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
            List<sp_InsUpdDelLoaiKhachHang_Result> emplist = new List<sp_InsUpdDelLoaiKhachHang_Result>();
            var results = db.sp_InsUpdDelLoaiKhachHang(id, "","", "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                emplist = db.sp_InsUpdDelLoaiKhachHang(id, "","", "Del").ToList();
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
