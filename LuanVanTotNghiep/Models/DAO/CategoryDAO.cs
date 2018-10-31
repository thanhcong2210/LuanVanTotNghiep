using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuanVanTotNghiep.Models;
namespace LuanVanTotNghiep.Models.DAO
{
    public class CategoryDAO
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public LOAIMONAN ViewDetail(int id)
        {
            return db.LOAIMONANs.Find(id);
        }
    }
}