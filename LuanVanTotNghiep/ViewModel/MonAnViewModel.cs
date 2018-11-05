using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.ViewModel
{
    [Serializable]
    public class MonAnViewModel
    {
        public int MAMON { get; set; }
        public string DUONGDAN { get; set; }
        public string TENGOI { get; set; }
        public double? DONGIA { get; set; }
        public string DVTINH { get; set; }
    }
}