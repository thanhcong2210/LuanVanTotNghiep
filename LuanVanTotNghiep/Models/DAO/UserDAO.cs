using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using LuanVanTotNghiep.Models;

namespace LuanVanTotNghiep.Models.DAO
{
    public class UserDAO
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public bool CheckUserName(string userName)
        {
            return db.KHACHHANGs.Count(x => x.TENDANGNHAP_KH == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.KHACHHANGs.Count(x => x.EMAIL_KH == email) > 0;
        }

        public int Inser(KHACHHANG entity)
        {
            db.KHACHHANGs.Add(entity);
            db.SaveChanges();
            return entity.MAKH;
        }

        public int Login(string tenDangNhap, string matKhau)
        {
            var result = db.KHACHHANGs.SingleOrDefault(t => t.TENDANGNHAP_KH == tenDangNhap);
            if (result == null)
            {
                return -1;
            }
            else
            {
                if (result.MATKHAU_KH == matKhau)
                    return 1;
                else
                    return 0;
            }
        }

        public int InsertForFacebook(KHACHHANG entity)
        {
            //try
            //{
            //    //var user = db.KHACHHANGs.Find(entity.MAKH);
            //    //var user = db.KHACHHANGs.SingleOrDefault(x => x.TENDANGNHAP_KH == entity.TENDANGNHAP_KH);
            //    //user.HOTEN_KH = entity.HOTEN_KH;
            //    ////if (!string.IsNullOrEmpty(entity.Password))
            //    ////{
            //    ////    user.Password = entity.Password;
            //    ////}
            //    ////user.Address = entity.Address;
            //    ////user.EMAIL_KH = entity.EMAIL_KH;
            //    //user.ModifiedBy = entity.ModifiedBy;
            //    //user.ModifiedDate = DateTime.Now;
            //    db.KHACHHANGs.Add(entity);
            //    db.SaveChanges();
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    //logging
            //    return false;
            //}

            ////some code here
            var user = db.KHACHHANGs.SingleOrDefault(x => x.TENDANGNHAP_KH == entity.TENDANGNHAP_KH);
            if (user == null)
            {
                db.KHACHHANGs.Add(entity);
                db.SaveChanges();
                return entity.MAKH;
            }
            else
            {
                return user.MAKH;
            }

        }
    }
}