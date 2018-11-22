using LuanVanTotNghiep.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LuanVanTotNghiep.Api
{
    public class HinhAnhAPIController : ApiController
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public IHttpActionResult Post()
        {
            string path = HttpContext.Current.Server.MapPath("~/upload/");

            var model = HttpContext.Current.Request.Form["DealModel"];

            var deal = JsonConvert.DeserializeObject<HINHANH>(model);

            if (deal == null)
            {
                return BadRequest();
            }
            // This is for demo. So I want to make this simple.
            //deal.Id = Guid.NewGuid();

            var retval = db.HINHANHs.Add(deal);


            var files = HttpContext.Current.Request.Files;

            if (retval != null)
            {
                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        string fileName = UploadFile(file, path);
                        db.HINHANHs.Add(new HINHANH { TENHINHANH = fileName , DUONGDAN1 = "/upload/" + fileName });
                    }
                }
                db.SaveChanges();

            }
            return Ok();

        }
        private string UploadFile(HttpPostedFile file, string mapPath)
        {

            string fileName = new FileInfo(file.FileName).Name;

            if (file.ContentLength > 0)
            {
                //Guid id = Guid.NewGuid();

                var filePath = Path.GetFileName(fileName);

                if (!File.Exists(mapPath + filePath))
                {

                    file.SaveAs(mapPath + filePath);
                    return filePath;
                }
                return null;
            }
            return null;

        }




        //QLNhaHangEntities db = new QLNhaHangEntities();
        //// Get All
        //[HttpGet]
        //public List<HINHANH> Get()
        //{
        //    List<HINHANH> list = new List<HINHANH>();
        //    var results = db.sp_InsUpdDelHinhAnh(0,"", "", "", "", "Get").ToList();
        //    foreach (var result in results)
        //    {
        //        var ha = new HINHANH()
        //        {
        //            MAHINHANH = result.MAHINHANH,
        //            TENHINHANH = result.TENHINHANH,
        //            DUONGDAN1 = result.DUONGDAN1,
        //            DUONGDAN2 = result.DUONGDAN2,
        //            DUONGDAN3 = result.DUONGDAN3,
        //        };
        //        list.Add(ha);
        //    }
        //    return list;
        //}

        ////// Get by Id
        //public HINHANH Get(int id)
        //{

        //    HINHANH ha = db.HINHANHs.Find(id);
        //    if (ha == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }
        //    return ha;
        //}
        //// Insert 
        //public HttpResponseMessage Post(HINHANH ha)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var list = db.sp_InsUpdDelHinhAnh(0,ha.TENHINHANH, ha.DUONGDAN1, ha.DUONGDAN2, ha.DUONGDAN3, "Ins").ToList();
        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, list);
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //}


        //// Update 
        //public HttpResponseMessage Put(HINHANH ha)
        //{
        //    List<sp_InsUpdDelHinhAnh_Result> list = new List<sp_InsUpdDelHinhAnh_Result>();
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    try
        //    {
        //        list = db.sp_InsUpdDelHinhAnh(ha.MAHINHANH, ha.TENHINHANH, ha.DUONGDAN1, ha.DUONGDAN2, ha.DUONGDAN3, "Upd").ToList();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, list);
        //}

        //// Delete employee By Id
        //public HttpResponseMessage Delete(int id)
        //{
        //    List<sp_InsUpdDelHinhAnh_Result> list = new List<sp_InsUpdDelHinhAnh_Result>();
        //    var results = db.sp_InsUpdDelHinhAnh(id,"", "", "", "" , "GetById").ToList();
        //    if (results.Count == 0)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }
        //    try
        //    {
        //        list = db.sp_InsUpdDelHinhAnh(id,"", "","","", "Del").ToList();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, list);
        //}

        // Prevent Memory Leak
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
