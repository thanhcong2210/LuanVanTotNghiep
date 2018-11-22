using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.Areas.Admin.ViewModelAdmin
{
    public class DonDatBanViewModel
    {
        public int MADATBAN { get; set; }
        public Nullable<int> MATAIKHOAN { get; set; }
        public string TENTAIKHOAN { get; set; }
        public int MAKH { get; set; }
        public string TENKH { get; set; }
        public Nullable<int> SOLUONGNGUOI { get; set; }
        public Nullable<System.DateTime> NGAYDEN { get; set; }
        public Nullable<System.DateTime> GIODEN { get; set; }
        public Nullable<bool> TRANGTHAIDATBAN { get; set; }
    }

}