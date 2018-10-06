//app.js
var NhaHangApp = angular.module('NhaHangApp', ['ui.router']);

NhaHangApp.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    // For any unmatched url, send to /business
    $urlRouterProvider.otherwise("/")

    $stateProvider
        .state('home', {//State demonstrating Nested views
            url: "/home",
            templateUrl: '/app/components/home/homeView.html',
            controller: 'homeController'
        })
        .state('monan', {//nested state [products is the nested state of business state]
            url: "/monan",
            templateUrl: '/app/components/monan/monanListView.html',
            controller: 'monanListController'
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
        });
}]);
