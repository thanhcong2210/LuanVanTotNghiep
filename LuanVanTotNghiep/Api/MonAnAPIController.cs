﻿using LuanVanTotNghiep.Areas.Admin.ViewModelAdmin;
using LuanVanTotNghiep.Models;
using LuanVanTotNghiep.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LuanVanTotNghiep.Api
{
    [RoutePrefix("api/MonAnAPI")]
    public class MonAnAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public MonAnAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // Get All
        [HttpGet]
        [Route("")]
        [AcceptVerbs("GET","HEAD")]
        public IEnumerable<MonAnViewModel> Get()
        {
     
            List<MONAN> list = new List<MONAN>();
            var query = from m in db.MONANs
                        join dv in db.DONVITINHs
                        on m.MADVTINH equals dv.MADVTINH
                        join l in db.LOAIMONANs
                        on m.MALOAI equals l.MALOAI
                        join ha in db.HINHANHs
                        on m.MAHINHANH equals ha.MAHINHANH
                        select new MonAnViewModel()
                        {
                            MAMON = m.MAMON,
                            MADVTINH = m.MADVTINH,
                            TENDVTINH = dv.TENDVTINH,
                            MALOAI = m.MALOAI,
                            TENLOAI = l.TENLOAI,
                            MAHINHANH = m.MAHINHANH,
                            DUONGDANHINHANH = ha.DUONGDAN1,
                            TENGOI = m.TENGOI,
                            DONGIA = m.DONGIA,
                            MOTA = m.MOTA,
                            CACHLAM = m.CACHLAM,
                            NGAYTAOMOI = m.NGAYTAOMOI
                        };
            
            
            return query.OrderByDescending(x=>x.NGAYTAOMOI);

            
        }

        // Get by Id
        public MONAN Get(int id)
        {

            MONAN m = db.MONANs.Find(id);
            if (m == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return m;
        }

        //LOAI MON AN
        [HttpGet]
        [Route("loaimonan")]
        [AcceptVerbs("GET", "HEAD")]
        public List<LOAIMONAN> GetLoaiMonAn()
        {
            List<LOAIMONAN> lmalist = new List<LOAIMONAN>();
            var results = db.sp_InsUpdDelLoaiMonAn(0, "", "Get").ToList();
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
        //HINH ANH
        [HttpGet]
        [Route("hinhanh")]
        [AcceptVerbs("GET", "HEAD")]
        public List<HINHANH> GetHinhAnh()
        {
            List<HINHANH> list = new List<HINHANH>();
            var results = db.sp_InsUpdDelHinhAnh(0,"", "", "", "", "Get").ToList();
            foreach (var result in results)
            {
                var ha = new HINHANH()
                {
                    MAHINHANH = result.MAHINHANH,
                    DUONGDAN1 = result.DUONGDAN1,
                    DUONGDAN2 = result.DUONGDAN2,
                    DUONGDAN3 = result.DUONGDAN3,
                };
                list.Add(ha);
            }
            return list;
        }
        //DON VI TINH
        [HttpGet]
        [Route("donvitinh")]
        [AcceptVerbs("GET","HEAD")]
        public List<DONVITINH> GetDonViTinh()
        {
            List<DONVITINH> list = new List<DONVITINH>();
            var results = db.sp_InsUpdDelDonViTinh(0, "", "Get").ToList();
            foreach (var result in results)
            {
                var dvtinh = new DONVITINH()
                {
                    MADVTINH = result.MADVTINH,
                    TENDVTINH = result.TENDVTINH
                };
                list.Add(dvtinh);
            }
            return list;
        }

        // Insert 
        [Route("")]
        [AcceptVerbs("POST", "HEAD")]
        [HttpPost]
        public HttpResponseMessage Post(MONAN m)
        {
            if (ModelState.IsValid)
            {
                var list = db.sp_InsUpdDelMonAn(0, m.MADVTINH, m.MALOAI, m.MAHINHANH, m.TENGOI, m.DONGIA, m.MOTA, m.CACHLAM, m.NGAYTAOMOI , "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update 
        [Route("")]
        [AcceptVerbs("PUT", "HEAD")]
        [HttpPut]
        public HttpResponseMessage Put(MONAN m)
        {
            List<sp_InsUpdDelMonAn_Result> list = new List<sp_InsUpdDelMonAn_Result>();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            try
            {
                list = db.sp_InsUpdDelMonAn(m.MAMON, m.MADVTINH, m.MALOAI, m.MAHINHANH, m.TENGOI, m.DONGIA, m.MOTA, m.CACHLAM, m.NGAYTAOMOI, "Upd").ToList();
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
            List<sp_InsUpdDelMonAn_Result> list = new List<sp_InsUpdDelMonAn_Result>();
            var results = db.sp_InsUpdDelMonAn(id, 0, 0, 0, "", new float(), "", "", new DateTime(1990,01,01), "GetById").ToList();
            if (results.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                list = db.sp_InsUpdDelMonAn(id, 0, 0, 0, "", new float(), "", "", new DateTime(1990, 01, 01), "Del").ToList();
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
