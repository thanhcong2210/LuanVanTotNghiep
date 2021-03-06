﻿using LuanVanTotNghiep.Areas.Admin.Common;
using LuanVanTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using LuanVanTotNghiep.Areas.Admin.ViewModelAdmin;

namespace LuanVanTotNghiep.Api
{
    [RoutePrefix("api/GioHangAPI")]
    public class GioHangAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public GioHangAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // Get All
        [HttpGet]
        [Route("")]
        [AcceptVerbs("GET", "HEAD")]
        public IEnumerable<GioHangViewModel> Get()
        {
            var query = from gh in db.GIOHANGs
                        join kh in db.KHACHHANGs
                        on gh.MAKH equals kh.MAKH
                        select new GioHangViewModel()
                        {
                            MAGH = gh.MAGH,
                            MAKH = kh.MAKH,
                            TEN_KH = kh.HOTEN_KH,
                            NGAYDAT = gh.NGAYDAT,
                            DIACHINHAN = gh.DIACHINHAN,
                            TRANGTHAI = gh.TRANGTHAI
                        };
            return query.ToList();
        }

        // Get by Id
        public GIOHANG Get(int id)
        {

            GIOHANG b = db.GIOHANGs.Find(id);
            if (b == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return b;
        }


        [HttpPost]
        [Route("")]
        [AcceptVerbs("POST", "HEAD")]
        // Insert 
        public HttpResponseMessage Post(GIOHANG b)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelGioHang(0, b.MAKH, b.NGAYDAT, b.TRANGTHAI, b.DIACHINHAN, "Ins").ToList();
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
        public HttpResponseMessage Put(GIOHANG b)
        {
            List<sp_InsUpdDelGioHang_Result> list = new List<sp_InsUpdDelGioHang_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            var session = (TaiKhoanLogin)HttpContext.Current.Session[CommonConstants.TAIKHOAN_SESSION];
            b.MAKH = session.TKID;
            try
            {
                list = db.sp_InsUpdDelGioHang(b.MAGH, b.MAKH, b.NGAYDAT, b.TRANGTHAI, b.DIACHINHAN, "Upd").ToList();
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
            List<sp_InsUpdDelGioHang_Result> list = new List<sp_InsUpdDelGioHang_Result>();
            var results = db.sp_InsUpdDelGioHang(id, id, new DateTime(), new bool(), "", "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelGioHang(id, id, new DateTime(), new bool(), "", "Del").ToList();
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
