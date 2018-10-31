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
    [RoutePrefix("api/KhachHangAPI")]
    public class KhachHangAPIController : ApiController
    {

        
        QLNhaHangEntities db = new QLNhaHangEntities();
        public KhachHangAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // Get All
        [HttpGet]
        [Route("")]
        [AcceptVerbs("GET", "HEAD")]
        public List<KHACHHANG> Get()
        {
            List<KHACHHANG> list = new List<KHACHHANG>();
            var results = db.sp_InsUpdDelKhachHang(0, new int(), new int(), "", "", "", "", new DateTime(1492, 10, 12), new bool(),"","", "Get").ToList();
            foreach (var result in results)
            {
                var nv = new KHACHHANG()
                {
                    MAKH = result.MAKH,
                    MALOAI_KH = result.MALOAI_KH,
                    MADATBAN = result.MADATBAN,
                    HOTEN_KH = result.HOTEN_KH,
                    DIACHI_KH = result.DIACHI_KH,
                    EMAIL_KH = result.EMAIL_KH,
                    SDT_KH = result.SDT_KH,
                    NGAYSINH_KH = result.NGAYSINH_KH ?? DateTime.Now,
                    GIOITINH_KH = result.GIOITINH_KH,
                    TENDANGNHAP_KH = result.TENDANGNHAP_KH,
                    MATKHAU_KH = result.MATKHAU_KH
                 };
                list.Add(nv);
            }
            return list;
        }

        // Get by Id
        public KHACHHANG Get(int id)
        {

            KHACHHANG kh = db.KHACHHANGs.Find(id);
            if (kh == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return kh;
        }
        [HttpGet]
        [Route("getloaikh")]
        [AcceptVerbs("GET", "HEAD")]
        public List<LOAIKHACHHANG> GetLoaiKH()
        {
            List<LOAIKHACHHANG> lkhlist = new List<LOAIKHACHHANG>();
            var results = db.sp_InsUpdDelLoaiKhachHang(0, "", "", "Get").ToList();
            foreach (var result in results)
            {
                var lkh = new LOAIKHACHHANG()
                {
                    MALOAI_KH = result.MALOAI_KH,
                    TENLOAI_KH = result.TENLOAI_KH,
                    MOTALOAI_KH = result.MOTALOAI_KH
                };
                lkhlist.Add(lkh);
            }
            return lkhlist;
        }

        [HttpPost]
        [Route("")]
        [AcceptVerbs("POST", "HEAD")]
        // Insert 
        public HttpResponseMessage Post(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelKhachHang(0, kh.MALOAI_KH, kh.MADATBAN, kh.HOTEN_KH, kh.DIACHI_KH, kh.EMAIL_KH, kh.SDT_KH, kh.NGAYSINH_KH, kh.GIOITINH_KH, kh.TENDANGNHAP_KH, kh.MATKHAU_KH, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        [HttpPut]
        [Route("")]
        [AcceptVerbs("PUT", "HEAD")]
        // Update 
        public HttpResponseMessage Put(KHACHHANG kh)
        {
            List<sp_InsUpdDelKhachHang_Result> list = new List<sp_InsUpdDelKhachHang_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelKhachHang(kh.MAKH, kh.MALOAI_KH, kh.MADATBAN, kh.HOTEN_KH, kh.DIACHI_KH, kh.EMAIL_KH, kh.SDT_KH, kh.NGAYSINH_KH, kh.GIOITINH_KH, kh.TENDANGNHAP_KH, kh.MATKHAU_KH, "Upd").ToList();
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
            List<sp_InsUpdDelKhachHang_Result> list = new List<sp_InsUpdDelKhachHang_Result>();
            var results = db.sp_InsUpdDelKhachHang(id, id, id, "", "", "", "", new DateTime(), new bool(),"","", "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelKhachHang(id, id, id, "", "", "", "", new DateTime(), new bool(),"","", "Del").ToList();
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
