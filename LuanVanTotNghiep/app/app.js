//app.js
var NhaHangApp = angular.module('NhaHangApp', ['ui.router', 'ui.bootstrap','angular-growl']);

NhaHangApp.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    // For any unmatched url, send to /business


    $stateProvider
        .state('home', {//State demonstrating Nested views
            url: "/admin",
            templateUrl: '/app/View/homeView.html',
            controller: 'homeController'
        })
        .state('monan', {//nested state [products is the nested state of business state]
            url: "/monan",
             
            templateUrl: '/app/View/MonAn.html',
            controller: 'monAnController'
        })
        .state('loaimonan', {//nested state [products is the nested state of business state]
            url: "/loaimonan",
             
            templateUrl: '/app/View/LoaiMonAnList.html',
            controller: 'loaiMonAnController'
        })
        .state('dvtinh', {//nested state [products is the nested state of business state]
            url: "/dvtinh",
             
            templateUrl: '/app/View/DonViTinh.html',
            controller: 'donViTinhController'
        })
        .state('hinhanh', {//nested state [products is the nested state of business state]
            url: "/hinhanh",
             
            templateUrl: '/app/View/HinhAnh.html',
            controller: 'hinhAnhController'
        })
        .state('nhahang', {//nested state [products is the nested state of business state]
            url: "/nhahang",
             
            templateUrl: '/app/View/NhaHang.html',
            controller: 'nhaHangController'
        })
        .state('tang', {//nested state [products is the nested state of business state]
            url: "/tang",
             
            headers: { 'Content-Type': 'application/json' },
            templateUrl: '/app/View/Tang.html',
            controller: 'tangController'
        })
        .state('chucvu', {//nested state [products is the nested state of business state]
            url: "/chucvu",
             
            templateUrl: '/app/View/ChucVu.html',
            controller: 'chucVuController'
        })
        .state('nhanvien', {//nested state [products is the nested state of business state]
            url: "/nhanvien",
             
            templateUrl: '/app/View/NhanVien.html',
            controller: 'nhanVienController'
        })
        .state('taikhoan', {//nested state [products is the nested state of business state]
            url: "/taikhoan",
             
            templateUrl: '/app/View/TaiKhoan.html',
            controller: 'taiKhoanController'
        })
        .state('thucpham', {//nested state [products is the nested state of business state]
            url: "/thucpham",
             
            templateUrl: '/app/View/ThucPham.html',
            controller: 'thucPhamController'
        })
        .state('nhacungcap', {//nested state [products is the nested state of business state]
            url: "/nhacungcaP",
             
            templateUrl: '/app/View/NhaCungCap.html',
            controller: 'nhaCungCapController'
        })
        .state('ban', {//nested state [products is the nested state of business state]
            url: "/ban",
             
            templateUrl: '/app/View/Ban.html',
            controller: 'banController'
        })
        .state('phieunhap', {//nested state [products is the nested state of business state]
            url: "/phieunhap",
             
            templateUrl: '/app/View/PhieuNhap.html',
            controller: 'phieuNhapController'
        })
        .state('khachhang', {//nested state [products is the nested state of business state]
            url: "/khachhang",
             
            templateUrl: '/app/View/KhachHang.html',
            controller: 'khachHangController'
        })
        .state('loaikhachhang', {//nested state [products is the nested state of business state]
            url: "/loaikhachhang",
             
            templateUrl: '/app/View/LoaiKhachHang.html',
            controller: 'loaiKhachHangController'
        })
        .state('dondatban', {//nested state [products is the nested state of business state]
            url: "/dondatban",
             
            templateUrl: '/app/View/DonDatBan.html',
            controller: 'donDatBanController'
        })
        .state('duyetgiohang', {//nested state [products is the nested state of business state]
            url: "/duyetgiohang",
             
            templateUrl: '/app/View/DuyetGioHang.html',
            controller: 'duyetGioHangController'
        })
        .state('giohang', {//nested state [products is the nested state of business state]
            url: "/giohang",
             
            templateUrl: '/app/View/GioHang.html',
            controller: 'gioHangController'
        });


    $urlRouterProvider.otherwise("/admin");
}]);
