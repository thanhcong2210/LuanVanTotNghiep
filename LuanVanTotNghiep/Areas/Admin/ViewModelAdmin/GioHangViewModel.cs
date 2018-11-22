using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.Areas.Admin.ViewModelAdmin
{
    public class GioHangViewModel
    {
        public int MAGH { get; set; }
        public int MAKH { get; set; }
        public string TEN_KH { get; set; }
        public Nullable<System.DateTime> NGAYDAT { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
        public string DIACHINHAN { get; set; }
    }
}