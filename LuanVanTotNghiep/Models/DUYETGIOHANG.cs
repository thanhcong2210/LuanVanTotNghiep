//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LuanVanTotNghiep.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DUYETGIOHANG
    {
        public int MADUYET { get; set; }
        public int MATAIKHOAN { get; set; }
        public int MAGH { get; set; }
        public Nullable<System.DateTime> NGAYDUYET { get; set; }
        public Nullable<bool> TRANGTHAIDUYET { get; set; }
    
        public virtual GIOHANG GIOHANG { get; set; }
        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}