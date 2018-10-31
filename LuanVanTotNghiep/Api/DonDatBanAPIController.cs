﻿using LuanVanTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LuanVanTotNghiep.Api
{
    [RoutePrefix("api/DonDatBanAPI")]
    public class DonDatBanAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        // Get All
        [HttpGet]
        [Route("")]
        [AcceptVerbs("GET", "HEAD")]
        public List<DONDATBAN> Get()
        {
            List<DONDATBAN> list = new List<DONDATBAN>();
            var results = db.sp_InsUpdDelDonDatBan(0, 0, 0 , 0 , new DateTime(1990,01,01), new DateTime(1990, 01, 01), new bool(), "Get").ToList();
            foreach (var result in results)
            {
                var b = new DONDATBAN()
                {
                    MADATBAN = result.MADATBAN,
                    MATAIKHOAN = result.MATAIKHOAN,
                    MAKH = result.MAKH,
                    SOLUONGNGUOI = result.SOLUONGNGUOI,
                    NGAYDEN  = result.NGAYDEN ?? DateTime.Today,
                    GIODEN = result.GIODEN ?? DateTime.Now,
                    TRANGTHAIDATBAN = result.TRANGTHAIDATBAN
                };
                list.Add(b);
            }
            return list;
        }

        // Get by Id
        public DONDATBAN Get(int id)
        {

            DONDATBAN b = db.DONDATBANs.Find(id);
            if (b == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return b;
        }

        //[HttpGet]
        //[Route("getban")]
        //[AcceptVerbs("GET", "HEAD")]
        //public List<TANG> GetTang()
        //{
        //    List<TANG> list = new List<TANG>();
        //    var results = db.sp_InsUpdDelTang(0, 0, "", "Get").ToList();
        //    foreach (var result in results)
        //    {
        //        var t = new TANG()
        //        {
        //            MATANG = result.MATANG,
        //            MANHAHANG = result.MANHAHANG,
        //            TENTANG = result.TENTANG
        //        };
        //        list.Add(t);
        //    }
        //    return list;
        //}


        [HttpPost]
        [Route("")]
        [AcceptVerbs("POST", "HEAD")]
        // Insert 
        public HttpResponseMessage Post(DONDATBAN b)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelDonDatBan(0, b.MATAIKHOAN, b.MAKH, b.SOLUONGNGUOI,b.NGAYDEN, b.GIODEN,b.TRANGTHAIDATBAN, "Ins").ToList();
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
        public HttpResponseMessage Put(DONDATBAN b)
        {
            List<sp_InsUpdDelDonDatBan_Result> list = new List<sp_InsUpdDelDonDatBan_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                list = db.sp_InsUpdDelDonDatBan(b.MADATBAN, b.MATAIKHOAN, b.MAKH, b.SOLUONGNGUOI, b.NGAYDEN, b.GIODEN, b.TRANGTHAIDATBAN, "Upd").ToList();
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
            List<sp_InsUpdDelDonDatBan_Result> list = new List<sp_InsUpdDelDonDatBan_Result>();
            var results = db.sp_InsUpdDelDonDatBan(id, id, id, id, new DateTime(1990, 01, 01), new DateTime(1990, 01, 01), new bool(), "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelDonDatBan(id, id , id , id, new DateTime(1990, 01, 01), new DateTime(1990, 01, 01), new bool(), "Del").ToList();
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
