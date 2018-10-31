using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.Areas.Admin.Common
{
    [Serializable]
    public class TaiKhoanLogin
    {
        public int TKID { set; get; }
        public string Username { set; get; }
        public string Name { set; get; }
        public string QuyenSD { set; get; }
    }
}