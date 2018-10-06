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
    public class NhanVienAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<NHANVIEN> Get()
        {
            List<NHANVIEN> list = new List<NHANVIEN>();
            var results = db.sp_InsUpdDelNhanVien(0,0,0,"","","","",new DateTime(1492, 10, 12), false, "Get").ToList();
            foreach (var result in results)
            {
                var nv = new NHANVIEN()
                {
                    MANV = result.MANV,
                    MANHAHANG = result.MANHAHANG,
                    MACV = result.MACV,
                    HOTEN_NV = result.HOTEN_NV,
                    SDT_NV = result.SDT_NV,
                    DIACHI_NV = result.DIACHI_NV,
                    EMAIL_NV = result.EMAIL_NV,
                    NGAYSINH_NV = result.NGAYSINH_NV,
                    GIOITINH_NV = result.GIOITINH_NV
                };
                list.Add(nv);
            }
            return list;
        }

        // Get by Id
        public NHANVIEN Get(int id)
        {

            NHANVIEN nv = db.NHANVIENs.Find(id);
            if (nv == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return nv;
        }
        // Insert 
        public HttpResponseMessage Post(NHANVIEN nv)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelNhanVien(0, nv.MANHAHANG, nv.MACV, nv.HOTEN_NV, nv.SDT_NV, nv.DIACHI_NV, nv.EMAIL_NV, nv.NGAYSINH_NV, nv.GIOITINH_NV, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(NHANVIEN nv)
        {
            List<sp_InsUpdDelNhanVien_Result> list = new List<sp_InsUpdDelNhanVien_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelNhanVien(nv.MANV, nv.MANHAHANG, nv.MACV, nv.HOTEN_NV, nv.SDT_NV, nv.DIACHI_NV, nv.EMAIL_NV, nv.NGAYSINH_NV, nv.GIOITINH_NV, "Upd").ToList();
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
            List<sp_InsUpdDelNhanVien_Result> list = new List<sp_InsUpdDelNhanVien_Result>();
            var results = db.sp_InsUpdDelNhanVien(id, id, id, "" , "" , "" , "" , new DateTime() , false, "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelNhanVien(id, id, id, "", "", "", "", new DateTime(), false, "Del").ToList();
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
