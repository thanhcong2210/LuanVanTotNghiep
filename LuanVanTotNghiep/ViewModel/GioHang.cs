using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuanVanTotNghiep.Models;

namespace LuanVanTotNghiep.ViewModel
{
    public class GioHang
    {
        QLNhaHangEntities db = new QLNhaHangEntities();
        //public MONAN product { get; set; }
        public int iMa { get; set; }
        public string sTen{ get; set; }
        public string sAnh { get; set; }
        public double? dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double? ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        //Hàm tạo cho giỏ hàng
        public GioHang(int MaMon)
        {
            iMa = MaMon;
            MONAN monan = db.MONANs.Single(n => n.MAMON == iMa);
            sTen = monan.TENGOI;
            sAnh = monan.HINHANH.DUONGDAN1;
            dDonGia = double.Parse(monan.DONGIA.ToString());
            iSoLuong = 1;
        }
    }
}