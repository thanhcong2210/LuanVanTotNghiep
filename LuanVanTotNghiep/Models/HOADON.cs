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
    
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            this.CHITIETHOADONs = new HashSet<CHITIETHOADON>();
        }
    
        public int MAHD { get; set; }
        public int MABAN { get; set; }
        public int MATAIKHOAN { get; set; }
        public int MAKH { get; set; }
        public Nullable<System.DateTime> THOIGIANDEN { get; set; }
        public Nullable<System.DateTime> THOIGIANDI { get; set; }
        public Nullable<System.DateTime> NGAYTHANHTOAN { get; set; }
        public Nullable<bool> TRANGTHAIHD { get; set; }
        public string GHICHU { get; set; }
        public Nullable<decimal> GIAMGIA { get; set; }
    
        public virtual BAN BAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual TAIKHOAN TAIKHOAN { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
