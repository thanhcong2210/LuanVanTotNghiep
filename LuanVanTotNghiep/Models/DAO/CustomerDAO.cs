using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuanVanTotNghiep.Models;

namespace LuanVanTotNghiep.Models.DAO
{
    public class CustomerDAO
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public int Insert(KHACHHANG entity)
        {
            db.KHACHHANGs.Add(entity);
            db.SaveChanges();
            return entity.MAKH;
        }
        public int Update_DatBan(KHACHHANG entity)
        {
            try
            {
                var user = db.KHACHHANGs.Find(entity.MAKH);
                user.MADATBAN = entity.MADATBAN;
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                //logging
                return 0;
            }

        }
    }
}