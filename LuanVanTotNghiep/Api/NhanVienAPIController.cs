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
    [RoutePrefix("api/NhanVienAPI")]
    public class NhanVienAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public NhanVienAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // Get All
        [HttpGet]
        [Route("")]
        [AcceptVerbs("GET", "HEAD")]
        public List<NHANVIEN> Get()
        {
            List<NHANVIEN> list = new List<NHANVIEN>();
            var results = db.sp_InsUpdDelNhanVien(0, new int(), new int(), "", "", "", "", new DateTime(1990, 10, 20),new bool(), "Get").ToList();
            foreach (var result in results)
            {
                var nv = new NHANVIEN()
                {
                    MANV =result.MANV,
                    MANHAHANG = result.MANHAHANG,
                    MACV = result.MACV,
                    HOTEN_NV = result.HOTEN_NV,
                    SDT_NV = result.SDT_NV, 
                    DIACHI_NV = result.DIACHI_NV,
                    EMAIL_NV = result.EMAIL_NV,
                    NGAYSINH_NV = result.NGAYSINH_NV ?? DateTime.Now,
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
        //chuc vu 
        [HttpGet]
        [Route("getchucvu")]
        [AcceptVerbs("GET", "HEAD")]
        public List<CHUCVU> GetChucVu()
        {
            List<CHUCVU> list = new List<CHUCVU>();
            var results = db.sp_InsUpdDelChucVu(0, "", "", "Get").ToList();
            foreach (var result in results)
            {
                var cv = new CHUCVU()
                {
                    MACV = result.MACV,
                    TENCV = result.TENCV,
                    MOTACV = result.MOTACV
                };
                list.Add(cv);
            }
            return list;
        }
        //GET NHA HANG
        [HttpGet]
        [Route("getnhahang")]
        [AcceptVerbs("GET", "HEAD")]
        public List<NHAHANG> GetnhaHang()
        {
            List<NHAHANG> list = new List<NHAHANG>();
            var results = db.sp_InsUpdDelNhaHang(0,"","", "", "", "", "Get").ToList();
            foreach (var result in results)
            {
                var t = new NHAHANG()
                {
                    MANHAHANG = result.MANHAHANG,
                    TENNHAHANG = result.TENNHAHANG,
                    SDT = result.SDT,
                    FAX = result.FAX,
                    DIACHI = result.DIACHI,
                    GIOITHIEU = result.GIOITHIEU
                };
                list.Add(t);
            }
            return list;
        }


        [HttpPost]
        [Route("")]
        [AcceptVerbs("POST", "HEAD")]
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
        [HttpPut]
        [Route("")]
        [AcceptVerbs("PUT", "HEAD")]
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
            var results = db.sp_InsUpdDelNhanVien(id, id, id,"", "", "", "", new DateTime(), new bool(), "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelNhanVien(id, id, id, "", "", "", "", new DateTime(), new bool(), "Del").ToList();
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
