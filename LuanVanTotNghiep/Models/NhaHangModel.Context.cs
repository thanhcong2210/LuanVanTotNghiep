﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QLNhaHangEntities : DbContext
    {
        public QLNhaHangEntities()
            : base("name=QLNhaHangEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAN> BANs { get; set; }
        public virtual DbSet<CHITIETGIOHANG> CHITIETGIOHANGs { get; set; }
        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<DONDATBAN> DONDATBANs { get; set; }
        public virtual DbSet<DONVITINH> DONVITINHs { get; set; }
        public virtual DbSet<DUYETGIOHANG> DUYETGIOHANGs { get; set; }
        public virtual DbSet<GIOHANG> GIOHANGs { get; set; }
        public virtual DbSet<HINHANH> HINHANHs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIKHACHHANG> LOAIKHACHHANGs { get; set; }
        public virtual DbSet<LOAIMONAN> LOAIMONANs { get; set; }
        public virtual DbSet<MONAN> MONANs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHAHANG> NHAHANGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<TANG> TANGs { get; set; }
        public virtual DbSet<THUCPHAM> THUCPHAMs { get; set; }
    
        public virtual ObjectResult<sp_InsUpdDelBan_Result> sp_InsUpdDelBan(Nullable<int> maban, Nullable<int> matang, string tentang, Nullable<bool> trangthaiban, string type)
        {
            var mabanParameter = maban.HasValue ?
                new ObjectParameter("maban", maban) :
                new ObjectParameter("maban", typeof(int));
    
            var matangParameter = matang.HasValue ?
                new ObjectParameter("matang", matang) :
                new ObjectParameter("matang", typeof(int));
    
            var tentangParameter = tentang != null ?
                new ObjectParameter("tentang", tentang) :
                new ObjectParameter("tentang", typeof(string));
    
            var trangthaibanParameter = trangthaiban.HasValue ?
                new ObjectParameter("trangthaiban", trangthaiban) :
                new ObjectParameter("trangthaiban", typeof(bool));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelBan_Result>("sp_InsUpdDelBan", mabanParameter, matangParameter, tentangParameter, trangthaibanParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelChucVu_Result> sp_InsUpdDelChucVu(Nullable<int> macv, string tencv, string motacv, string type)
        {
            var macvParameter = macv.HasValue ?
                new ObjectParameter("macv", macv) :
                new ObjectParameter("macv", typeof(int));
    
            var tencvParameter = tencv != null ?
                new ObjectParameter("tencv", tencv) :
                new ObjectParameter("tencv", typeof(string));
    
            var motacvParameter = motacv != null ?
                new ObjectParameter("motacv", motacv) :
                new ObjectParameter("motacv", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelChucVu_Result>("sp_InsUpdDelChucVu", macvParameter, tencvParameter, motacvParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelDonDatBan_Result> sp_InsUpdDelDonDatBan(Nullable<int> madatban, Nullable<int> mataikhoan, Nullable<int> makh, Nullable<int> soluongnguoi, Nullable<System.DateTime> ngayden, Nullable<System.DateTime> gioden, Nullable<bool> trangthaidatban, string type)
        {
            var madatbanParameter = madatban.HasValue ?
                new ObjectParameter("madatban", madatban) :
                new ObjectParameter("madatban", typeof(int));
    
            var mataikhoanParameter = mataikhoan.HasValue ?
                new ObjectParameter("mataikhoan", mataikhoan) :
                new ObjectParameter("mataikhoan", typeof(int));
    
            var makhParameter = makh.HasValue ?
                new ObjectParameter("makh", makh) :
                new ObjectParameter("makh", typeof(int));
    
            var soluongnguoiParameter = soluongnguoi.HasValue ?
                new ObjectParameter("soluongnguoi", soluongnguoi) :
                new ObjectParameter("soluongnguoi", typeof(int));
    
            var ngaydenParameter = ngayden.HasValue ?
                new ObjectParameter("ngayden", ngayden) :
                new ObjectParameter("ngayden", typeof(System.DateTime));
    
            var giodenParameter = gioden.HasValue ?
                new ObjectParameter("gioden", gioden) :
                new ObjectParameter("gioden", typeof(System.DateTime));
    
            var trangthaidatbanParameter = trangthaidatban.HasValue ?
                new ObjectParameter("trangthaidatban", trangthaidatban) :
                new ObjectParameter("trangthaidatban", typeof(bool));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelDonDatBan_Result>("sp_InsUpdDelDonDatBan", madatbanParameter, mataikhoanParameter, makhParameter, soluongnguoiParameter, ngaydenParameter, giodenParameter, trangthaidatbanParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelDonViTinh_Result> sp_InsUpdDelDonViTinh(Nullable<int> madvtinh, string tendvtinh, string type)
        {
            var madvtinhParameter = madvtinh.HasValue ?
                new ObjectParameter("madvtinh", madvtinh) :
                new ObjectParameter("madvtinh", typeof(int));
    
            var tendvtinhParameter = tendvtinh != null ?
                new ObjectParameter("tendvtinh", tendvtinh) :
                new ObjectParameter("tendvtinh", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelDonViTinh_Result>("sp_InsUpdDelDonViTinh", madvtinhParameter, tendvtinhParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelDuyetGioHang_Result> sp_InsUpdDelDuyetGioHang(Nullable<int> maduyet, Nullable<int> mataikhoan, Nullable<int> magh, Nullable<System.DateTime> ngayduyet, Nullable<bool> trangthaiduyet, string type)
        {
            var maduyetParameter = maduyet.HasValue ?
                new ObjectParameter("maduyet", maduyet) :
                new ObjectParameter("maduyet", typeof(int));
    
            var mataikhoanParameter = mataikhoan.HasValue ?
                new ObjectParameter("mataikhoan", mataikhoan) :
                new ObjectParameter("mataikhoan", typeof(int));
    
            var maghParameter = magh.HasValue ?
                new ObjectParameter("magh", magh) :
                new ObjectParameter("magh", typeof(int));
    
            var ngayduyetParameter = ngayduyet.HasValue ?
                new ObjectParameter("ngayduyet", ngayduyet) :
                new ObjectParameter("ngayduyet", typeof(System.DateTime));
    
            var trangthaiduyetParameter = trangthaiduyet.HasValue ?
                new ObjectParameter("trangthaiduyet", trangthaiduyet) :
                new ObjectParameter("trangthaiduyet", typeof(bool));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelDuyetGioHang_Result>("sp_InsUpdDelDuyetGioHang", maduyetParameter, mataikhoanParameter, maghParameter, ngayduyetParameter, trangthaiduyetParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelGioHang_Result> sp_InsUpdDelGioHang(Nullable<int> magh, Nullable<int> makh, Nullable<System.DateTime> ngaydat, Nullable<bool> trangthai, string diachinhan, string type)
        {
            var maghParameter = magh.HasValue ?
                new ObjectParameter("magh", magh) :
                new ObjectParameter("magh", typeof(int));
    
            var makhParameter = makh.HasValue ?
                new ObjectParameter("makh", makh) :
                new ObjectParameter("makh", typeof(int));
    
            var ngaydatParameter = ngaydat.HasValue ?
                new ObjectParameter("ngaydat", ngaydat) :
                new ObjectParameter("ngaydat", typeof(System.DateTime));
    
            var trangthaiParameter = trangthai.HasValue ?
                new ObjectParameter("trangthai", trangthai) :
                new ObjectParameter("trangthai", typeof(bool));
    
            var diachinhanParameter = diachinhan != null ?
                new ObjectParameter("diachinhan", diachinhan) :
                new ObjectParameter("diachinhan", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelGioHang_Result>("sp_InsUpdDelGioHang", maghParameter, makhParameter, ngaydatParameter, trangthaiParameter, diachinhanParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelHinhAnh_Result> sp_InsUpdDelHinhAnh(Nullable<int> mahinhanh, string tenhinhanh, string duongdan1, string duongdan2, string duongdan3, string type)
        {
            var mahinhanhParameter = mahinhanh.HasValue ?
                new ObjectParameter("mahinhanh", mahinhanh) :
                new ObjectParameter("mahinhanh", typeof(int));
    
            var tenhinhanhParameter = tenhinhanh != null ?
                new ObjectParameter("tenhinhanh", tenhinhanh) :
                new ObjectParameter("tenhinhanh", typeof(string));
    
            var duongdan1Parameter = duongdan1 != null ?
                new ObjectParameter("duongdan1", duongdan1) :
                new ObjectParameter("duongdan1", typeof(string));
    
            var duongdan2Parameter = duongdan2 != null ?
                new ObjectParameter("duongdan2", duongdan2) :
                new ObjectParameter("duongdan2", typeof(string));
    
            var duongdan3Parameter = duongdan3 != null ?
                new ObjectParameter("duongdan3", duongdan3) :
                new ObjectParameter("duongdan3", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelHinhAnh_Result>("sp_InsUpdDelHinhAnh", mahinhanhParameter, tenhinhanhParameter, duongdan1Parameter, duongdan2Parameter, duongdan3Parameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelKhachHang_Result> sp_InsUpdDelKhachHang(Nullable<int> makh, Nullable<int> maloai_kh, Nullable<int> madatban, string hoten_kh, string diachi_kh, string email_kh, string sdt_kh, Nullable<System.DateTime> ngaysinh_kh, Nullable<bool> gioitinh_kh, string tendangnhap_kh, string matkhau_kh, string type)
        {
            var makhParameter = makh.HasValue ?
                new ObjectParameter("makh", makh) :
                new ObjectParameter("makh", typeof(int));
    
            var maloai_khParameter = maloai_kh.HasValue ?
                new ObjectParameter("maloai_kh", maloai_kh) :
                new ObjectParameter("maloai_kh", typeof(int));
    
            var madatbanParameter = madatban.HasValue ?
                new ObjectParameter("madatban", madatban) :
                new ObjectParameter("madatban", typeof(int));
    
            var hoten_khParameter = hoten_kh != null ?
                new ObjectParameter("hoten_kh", hoten_kh) :
                new ObjectParameter("hoten_kh", typeof(string));
    
            var diachi_khParameter = diachi_kh != null ?
                new ObjectParameter("diachi_kh", diachi_kh) :
                new ObjectParameter("diachi_kh", typeof(string));
    
            var email_khParameter = email_kh != null ?
                new ObjectParameter("email_kh", email_kh) :
                new ObjectParameter("email_kh", typeof(string));
    
            var sdt_khParameter = sdt_kh != null ?
                new ObjectParameter("sdt_kh", sdt_kh) :
                new ObjectParameter("sdt_kh", typeof(string));
    
            var ngaysinh_khParameter = ngaysinh_kh.HasValue ?
                new ObjectParameter("ngaysinh_kh", ngaysinh_kh) :
                new ObjectParameter("ngaysinh_kh", typeof(System.DateTime));
    
            var gioitinh_khParameter = gioitinh_kh.HasValue ?
                new ObjectParameter("gioitinh_kh", gioitinh_kh) :
                new ObjectParameter("gioitinh_kh", typeof(bool));
    
            var tendangnhap_khParameter = tendangnhap_kh != null ?
                new ObjectParameter("tendangnhap_kh", tendangnhap_kh) :
                new ObjectParameter("tendangnhap_kh", typeof(string));
    
            var matkhau_khParameter = matkhau_kh != null ?
                new ObjectParameter("matkhau_kh", matkhau_kh) :
                new ObjectParameter("matkhau_kh", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelKhachHang_Result>("sp_InsUpdDelKhachHang", makhParameter, maloai_khParameter, madatbanParameter, hoten_khParameter, diachi_khParameter, email_khParameter, sdt_khParameter, ngaysinh_khParameter, gioitinh_khParameter, tendangnhap_khParameter, matkhau_khParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelLoaiKhachHang_Result> sp_InsUpdDelLoaiKhachHang(Nullable<int> maloai_kh, string tenloai_kh, string motaloai_kh, string type)
        {
            var maloai_khParameter = maloai_kh.HasValue ?
                new ObjectParameter("maloai_kh", maloai_kh) :
                new ObjectParameter("maloai_kh", typeof(int));
    
            var tenloai_khParameter = tenloai_kh != null ?
                new ObjectParameter("tenloai_kh", tenloai_kh) :
                new ObjectParameter("tenloai_kh", typeof(string));
    
            var motaloai_khParameter = motaloai_kh != null ?
                new ObjectParameter("motaloai_kh", motaloai_kh) :
                new ObjectParameter("motaloai_kh", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelLoaiKhachHang_Result>("sp_InsUpdDelLoaiKhachHang", maloai_khParameter, tenloai_khParameter, motaloai_khParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelLoaiMonAn_Result> sp_InsUpdDelLoaiMonAn(Nullable<int> maloai, string tenloai, string type)
        {
            var maloaiParameter = maloai.HasValue ?
                new ObjectParameter("maloai", maloai) :
                new ObjectParameter("maloai", typeof(int));
    
            var tenloaiParameter = tenloai != null ?
                new ObjectParameter("tenloai", tenloai) :
                new ObjectParameter("tenloai", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelLoaiMonAn_Result>("sp_InsUpdDelLoaiMonAn", maloaiParameter, tenloaiParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelMonAn_Result> sp_InsUpdDelMonAn(Nullable<int> mamon, Nullable<int> madvtinh, Nullable<int> maloai, Nullable<int> mahinhanh, string tengoi, Nullable<double> dongia, string mota, string cachlam, Nullable<System.DateTime> ngaytao, string type)
        {
            var mamonParameter = mamon.HasValue ?
                new ObjectParameter("mamon", mamon) :
                new ObjectParameter("mamon", typeof(int));
    
            var madvtinhParameter = madvtinh.HasValue ?
                new ObjectParameter("madvtinh", madvtinh) :
                new ObjectParameter("madvtinh", typeof(int));
    
            var maloaiParameter = maloai.HasValue ?
                new ObjectParameter("maloai", maloai) :
                new ObjectParameter("maloai", typeof(int));
    
            var mahinhanhParameter = mahinhanh.HasValue ?
                new ObjectParameter("mahinhanh", mahinhanh) :
                new ObjectParameter("mahinhanh", typeof(int));
    
            var tengoiParameter = tengoi != null ?
                new ObjectParameter("tengoi", tengoi) :
                new ObjectParameter("tengoi", typeof(string));
    
            var dongiaParameter = dongia.HasValue ?
                new ObjectParameter("dongia", dongia) :
                new ObjectParameter("dongia", typeof(double));
    
            var motaParameter = mota != null ?
                new ObjectParameter("mota", mota) :
                new ObjectParameter("mota", typeof(string));
    
            var cachlamParameter = cachlam != null ?
                new ObjectParameter("cachlam", cachlam) :
                new ObjectParameter("cachlam", typeof(string));
    
            var ngaytaoParameter = ngaytao.HasValue ?
                new ObjectParameter("ngaytao", ngaytao) :
                new ObjectParameter("ngaytao", typeof(System.DateTime));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelMonAn_Result>("sp_InsUpdDelMonAn", mamonParameter, madvtinhParameter, maloaiParameter, mahinhanhParameter, tengoiParameter, dongiaParameter, motaParameter, cachlamParameter, ngaytaoParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelNhaCungCap_Result> sp_InsUpdDelNhaCungCap(Nullable<int> mancc, string ten_ncc, string diachi_ncc, string sdt_ncc, string ghichuthem, string type)
        {
            var manccParameter = mancc.HasValue ?
                new ObjectParameter("mancc", mancc) :
                new ObjectParameter("mancc", typeof(int));
    
            var ten_nccParameter = ten_ncc != null ?
                new ObjectParameter("ten_ncc", ten_ncc) :
                new ObjectParameter("ten_ncc", typeof(string));
    
            var diachi_nccParameter = diachi_ncc != null ?
                new ObjectParameter("diachi_ncc", diachi_ncc) :
                new ObjectParameter("diachi_ncc", typeof(string));
    
            var sdt_nccParameter = sdt_ncc != null ?
                new ObjectParameter("sdt_ncc", sdt_ncc) :
                new ObjectParameter("sdt_ncc", typeof(string));
    
            var ghichuthemParameter = ghichuthem != null ?
                new ObjectParameter("ghichuthem", ghichuthem) :
                new ObjectParameter("ghichuthem", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelNhaCungCap_Result>("sp_InsUpdDelNhaCungCap", manccParameter, ten_nccParameter, diachi_nccParameter, sdt_nccParameter, ghichuthemParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelNhaHang_Result> sp_InsUpdDelNhaHang(Nullable<int> manhahang, string tennhahang, string sdt, string fax, string diachi, string gioithieu, string type)
        {
            var manhahangParameter = manhahang.HasValue ?
                new ObjectParameter("manhahang", manhahang) :
                new ObjectParameter("manhahang", typeof(int));
    
            var tennhahangParameter = tennhahang != null ?
                new ObjectParameter("tennhahang", tennhahang) :
                new ObjectParameter("tennhahang", typeof(string));
    
            var sdtParameter = sdt != null ?
                new ObjectParameter("sdt", sdt) :
                new ObjectParameter("sdt", typeof(string));
    
            var faxParameter = fax != null ?
                new ObjectParameter("fax", fax) :
                new ObjectParameter("fax", typeof(string));
    
            var diachiParameter = diachi != null ?
                new ObjectParameter("diachi", diachi) :
                new ObjectParameter("diachi", typeof(string));
    
            var gioithieuParameter = gioithieu != null ?
                new ObjectParameter("gioithieu", gioithieu) :
                new ObjectParameter("gioithieu", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelNhaHang_Result>("sp_InsUpdDelNhaHang", manhahangParameter, tennhahangParameter, sdtParameter, faxParameter, diachiParameter, gioithieuParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelNhanVien_Result> sp_InsUpdDelNhanVien(Nullable<int> manv, Nullable<int> manhahang, Nullable<int> macv, string hoten_nv, string sdt_nv, string diachi_nv, string email_nv, Nullable<System.DateTime> ngaysinh_nv, Nullable<bool> gioitinh_nv, string type)
        {
            var manvParameter = manv.HasValue ?
                new ObjectParameter("manv", manv) :
                new ObjectParameter("manv", typeof(int));
    
            var manhahangParameter = manhahang.HasValue ?
                new ObjectParameter("manhahang", manhahang) :
                new ObjectParameter("manhahang", typeof(int));
    
            var macvParameter = macv.HasValue ?
                new ObjectParameter("macv", macv) :
                new ObjectParameter("macv", typeof(int));
    
            var hoten_nvParameter = hoten_nv != null ?
                new ObjectParameter("hoten_nv", hoten_nv) :
                new ObjectParameter("hoten_nv", typeof(string));
    
            var sdt_nvParameter = sdt_nv != null ?
                new ObjectParameter("sdt_nv", sdt_nv) :
                new ObjectParameter("sdt_nv", typeof(string));
    
            var diachi_nvParameter = diachi_nv != null ?
                new ObjectParameter("diachi_nv", diachi_nv) :
                new ObjectParameter("diachi_nv", typeof(string));
    
            var email_nvParameter = email_nv != null ?
                new ObjectParameter("email_nv", email_nv) :
                new ObjectParameter("email_nv", typeof(string));
    
            var ngaysinh_nvParameter = ngaysinh_nv.HasValue ?
                new ObjectParameter("ngaysinh_nv", ngaysinh_nv) :
                new ObjectParameter("ngaysinh_nv", typeof(System.DateTime));
    
            var gioitinh_nvParameter = gioitinh_nv.HasValue ?
                new ObjectParameter("gioitinh_nv", gioitinh_nv) :
                new ObjectParameter("gioitinh_nv", typeof(bool));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelNhanVien_Result>("sp_InsUpdDelNhanVien", manvParameter, manhahangParameter, macvParameter, hoten_nvParameter, sdt_nvParameter, diachi_nvParameter, email_nvParameter, ngaysinh_nvParameter, gioitinh_nvParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelPhieuNhap_Result> sp_InsUpdDelPhieuNhap(Nullable<int> maphieunhap, Nullable<int> mancc, Nullable<System.DateTime> ngaynhap, string type)
        {
            var maphieunhapParameter = maphieunhap.HasValue ?
                new ObjectParameter("maphieunhap", maphieunhap) :
                new ObjectParameter("maphieunhap", typeof(int));
    
            var manccParameter = mancc.HasValue ?
                new ObjectParameter("mancc", mancc) :
                new ObjectParameter("mancc", typeof(int));
    
            var ngaynhapParameter = ngaynhap.HasValue ?
                new ObjectParameter("ngaynhap", ngaynhap) :
                new ObjectParameter("ngaynhap", typeof(System.DateTime));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelPhieuNhap_Result>("sp_InsUpdDelPhieuNhap", maphieunhapParameter, manccParameter, ngaynhapParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelTaiKhoan_Result> sp_InsUpdDelTaiKhoan(Nullable<int> mataikhoan, Nullable<int> manv, string tendangnhap, string matkhau, string quyensd, Nullable<bool> trangthaikichhoat, string type)
        {
            var mataikhoanParameter = mataikhoan.HasValue ?
                new ObjectParameter("mataikhoan", mataikhoan) :
                new ObjectParameter("mataikhoan", typeof(int));
    
            var manvParameter = manv.HasValue ?
                new ObjectParameter("manv", manv) :
                new ObjectParameter("manv", typeof(int));
    
            var tendangnhapParameter = tendangnhap != null ?
                new ObjectParameter("tendangnhap", tendangnhap) :
                new ObjectParameter("tendangnhap", typeof(string));
    
            var matkhauParameter = matkhau != null ?
                new ObjectParameter("matkhau", matkhau) :
                new ObjectParameter("matkhau", typeof(string));
    
            var quyensdParameter = quyensd != null ?
                new ObjectParameter("quyensd", quyensd) :
                new ObjectParameter("quyensd", typeof(string));
    
            var trangthaikichhoatParameter = trangthaikichhoat.HasValue ?
                new ObjectParameter("trangthaikichhoat", trangthaikichhoat) :
                new ObjectParameter("trangthaikichhoat", typeof(bool));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelTaiKhoan_Result>("sp_InsUpdDelTaiKhoan", mataikhoanParameter, manvParameter, tendangnhapParameter, matkhauParameter, quyensdParameter, trangthaikichhoatParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelTang_Result> sp_InsUpdDelTang(Nullable<int> matang, Nullable<int> manhahang, string tentang, string type)
        {
            var matangParameter = matang.HasValue ?
                new ObjectParameter("matang", matang) :
                new ObjectParameter("matang", typeof(int));
    
            var manhahangParameter = manhahang.HasValue ?
                new ObjectParameter("manhahang", manhahang) :
                new ObjectParameter("manhahang", typeof(int));
    
            var tentangParameter = tentang != null ?
                new ObjectParameter("tentang", tentang) :
                new ObjectParameter("tentang", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelTang_Result>("sp_InsUpdDelTang", matangParameter, manhahangParameter, tentangParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_InsUpdDelThucPham_Result> sp_InsUpdDelThucPham(Nullable<int> mathucpham, string tenthucpham, string dvtinh, string type)
        {
            var mathucphamParameter = mathucpham.HasValue ?
                new ObjectParameter("mathucpham", mathucpham) :
                new ObjectParameter("mathucpham", typeof(int));
    
            var tenthucphamParameter = tenthucpham != null ?
                new ObjectParameter("tenthucpham", tenthucpham) :
                new ObjectParameter("tenthucpham", typeof(string));
    
            var dvtinhParameter = dvtinh != null ?
                new ObjectParameter("dvtinh", dvtinh) :
                new ObjectParameter("dvtinh", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InsUpdDelThucPham_Result>("sp_InsUpdDelThucPham", mathucphamParameter, tenthucphamParameter, dvtinhParameter, typeParameter);
        }
    
        public virtual int usp_insert_order(ObjectParameter order_id, Nullable<System.DateTime> order_date, Nullable<int> custom_id, Nullable<bool> status, string received_address)
        {
            var order_dateParameter = order_date.HasValue ?
                new ObjectParameter("order_date", order_date) :
                new ObjectParameter("order_date", typeof(System.DateTime));
    
            var custom_idParameter = custom_id.HasValue ?
                new ObjectParameter("custom_id", custom_id) :
                new ObjectParameter("custom_id", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(bool));
    
            var received_addressParameter = received_address != null ?
                new ObjectParameter("received_address", received_address) :
                new ObjectParameter("received_address", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_insert_order", order_id, order_dateParameter, custom_idParameter, statusParameter, received_addressParameter);
        }
    }
}
