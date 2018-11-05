using LuanVanTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.ViewModel
{
    [Serializable]
    public class DatBan
    {
        public int id { get; set; }
        public int idTK { get; set; }
        public int idKH { get; set; }
        public int SoLuong { get; set; }
        public DateTime? ngayden {get; set;}
        public DateTime? gioden { get; set; }
        public bool trangthai { get; set; }
    }
}