using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.Common
{
    [Serializable]
    public class getInfoKhachHang
    {
        public int ID { set; get; }
        public string Username { set; get; }
        public string Name { set; get; }
    }
}