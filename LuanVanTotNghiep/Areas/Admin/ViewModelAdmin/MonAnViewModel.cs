using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.Areas.Admin.ViewModelAdmin
{
    public class MonAnViewModel
    {
        public int MAMON { get; set; }
        public int MADVTINH { get; set; }
        public string TENDVTINH { get; set; }
        public int MALOAI { get; set; }
        public string TENLOAI { get; set; }
        public int MAHINHANH { get; set; }
        public string DUONGDANHINHANH { get; set; }
        public string TENGOI { get; set; }
        public Nullable<double> DONGIA { get; set; }
        public string MOTA { get; set; }
        public string CACHLAM { get; set; }
        public Nullable<System.DateTime> NGAYTAOMOI { get; set; }
    }
}