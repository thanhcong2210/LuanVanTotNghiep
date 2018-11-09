using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.Areas.Admin.ViewModelAdmin
{
    public class PhieuNhapViewModel
    {
        public int MAPHIEUNHAP { get; set; }
        public int MANCC { get; set; }
        public string TENNCC { get; set; }
        public Nullable<System.DateTime> NGAYNHAP { get; set; }
    }
}