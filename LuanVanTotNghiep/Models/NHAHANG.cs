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
    
    public partial class NHAHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAHANG()
        {
            this.NHANVIENs = new HashSet<NHANVIEN>();
            this.TANGs = new HashSet<TANG>();
        }
    
        public int MANHAHANG { get; set; }
        public string TENNHAHANG { get; set; }
        public Nullable<decimal> SDT { get; set; }
        public string GIOITHIEU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN> NHANVIENs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TANG> TANGs { get; set; }
    }
}