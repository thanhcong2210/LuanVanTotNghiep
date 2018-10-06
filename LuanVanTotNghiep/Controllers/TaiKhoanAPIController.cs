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
    public class TaiKhoanAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        public List<TAIKHOAN> Get()
        {
            List<TAIKHOAN> list = new List<TAIKHOAN>();
            var results = db.sp_InsUpdDelTaiKhoan(0, 0 ,"", "", "" , false,"Get").ToList();
            foreach (var result in results)
            {
                var tk = new TAIKHOAN()
                {
                    MATAIKHOAN = result.MATAIKHOAN,
                    MANV = result.MANV,
                    TENDANGNHAP = result.TENDANGNHAP,
                    MATKHAU = result.MATKHAU,
                    QUYENSD  = result.QUYENSD,
                    TRANGTHAIKICHHOAT = result.TRANGTHAIKICHHOAT
                };
                list.Add(tk);
            }
            return list;
        }

        // Get by Id
        public TAIKHOAN Get(int id)
        {

            TAIKHOAN tk = db.TAIKHOANs.Find(id);
            if (tk == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return tk;
        }
        // Insert 
        public HttpResponseMessage Post(TAIKHOAN tk)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelTaiKhoan(0, tk.MANV, tk.TENDANGNHAP, tk.MATKHAU, tk.QUYENSD ,tk.TRANGTHAIKICHHOAT, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        public HttpResponseMessage Put(TAIKHOAN tk)
        {
            List<sp_InsUpdDelTaiKhoan_Result> list = new List<sp_InsUpdDelTaiKhoan_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelTaiKhoan(tk.MATAIKHOAN, tk.MANV, tk.TENDANGNHAP, tk.MATKHAU, tk.QUYENSD, tk.TRANGTHAIKICHHOAT, "Upd").ToList();
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
            List<sp_InsUpdDelTaiKhoan_Result> list = new List<sp_InsUpdDelTaiKhoan_Result>();
            var results = db.sp_InsUpdDelTaiKhoan(id, id ,"","","",false, "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelTaiKhoan(id, id, "", "", "", false, "Del").ToList();
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
