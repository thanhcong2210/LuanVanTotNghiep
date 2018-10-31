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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Serialization;

    [Table("DUYETGIOHANG")]
    public partial class DUYETGIOHANG
    {
        public int MADUYET { get; set; }
        public int MATAIKHOAN { get; set; }
        public int MAGH { get; set; }
        [Column(TypeName = "datetime2")]
        [XmlAttribute]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date Modified")]
        public DateTime NGAYDUYET
        {
            get { return nGAYDUYET; }
            set { nGAYDUYET = value; }
        }
        private DateTime nGAYDUYET = DateTime.Now.ToLocalTime();        
        public Nullable<bool> TRANGTHAIDUYET { get; set; }
    
        public virtual GIOHANG GIOHANG { get; set; }
        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
