using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.Areas.Admin.ViewModelAdmin
{
    public class BillViewModel
    {
        public int MAHD { get; set; }
        public int MABAN { get; set; }
        public int MATAIKHOAN { get; set; }
        public Nullable<int> MAKH { get; set; }
        public Nullable<System.DateTime> THOIGIANDEN { get; set; }
        public Nullable<System.DateTime> THOIGIANDI { get; set; }
        public Nullable<System.DateTime> NGAYTHANHTOAN { get; set; }
        public Nullable<bool> TRANGTHAIHD { get; set; }
        public string GHICHU { get; set; }
        public Nullable<double> GIAMGIA { get; set; }
    }
}