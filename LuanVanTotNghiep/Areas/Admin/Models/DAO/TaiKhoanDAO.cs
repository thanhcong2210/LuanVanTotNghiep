using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuanVanTotNghiep.Models;

namespace LuanVanTotNghiep.Areas.Admin.Models.DAO
{
    public class TaiKhoanDAO
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        public TAIKHOAN GetByMATAIKHOAN(string tenDangNhap)
        {
            return db.TAIKHOANs.SingleOrDefault(t => t.TENDANGNHAP == tenDangNhap);
        }
        public int Login(string tenDangNhap, string matKhau)
        {
            var result = db.TAIKHOANs.SingleOrDefault(t => t.TENDANGNHAP == tenDangNhap);
            if (result == null)
            {
                return -1;
            }
            else
            {
                if (result.MATKHAU == matKhau)
                    return 1;
                else
                    return 0;
            }
        }
    }
    
}