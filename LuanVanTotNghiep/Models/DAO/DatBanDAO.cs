using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuanVanTotNghiep.Models;
namespace LuanVanTotNghiep.Models.DAO
{
    public class DatBanDAO
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public int Inser(DONDATBAN entity)
        {
            db.DONDATBANs.Add(entity);
            db.SaveChanges();
            return entity.MADATBAN;
        }
    }
}