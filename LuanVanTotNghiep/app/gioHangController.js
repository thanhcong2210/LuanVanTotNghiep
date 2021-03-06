﻿NhaHangApp.controller('gioHangController', ['$scope', '$http', gioHangController]);

// Angularjs Controller
function gioHangController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;
    $scope.ShowDataTable = false;
    $scope.ShowUpdate = false;
    // PHAN TRANG 
    $scope.viewby = 10;
    $scope.totalItems = 0;
    $scope.currentPage = 4;
    $scope.itemsPerPage = $scope.viewby;
    $scope.maxSize = 5; //Number of pager buttons to show

    // Get All 
    $http.get('/api/GioHangAPI/').success(function (data) {
        $scope.ShowDataTable = true;
        $scope.ShowUpdate = false;
        $scope.giohangs = data;
        $scope.totalItems = $scope.giohangs.length;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });

    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };

    $scope.pageChanged = function () {
        console.log('Page changed to: ' + $scope.currentPage);
    };

    $scope.setItemsPerPage = function (num) {
        $scope.itemsPerPage = num;
        $scope.currentPage = 1; //reset to first page
    };

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/GioHangAPI/', this.newgiohang).success(function (data) {
            $scope.giohangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newgiohang = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Edit 
    $scope.edit = function () {
        var Id = this.giohang.MAGH;
        $scope.ShowUpdate = true;
        $scope.ShowDataTable = false;
        $http.get('/api/GioHangAPI/' + Id).success(function (data) {
            data.NGAYDAT = new Date(data.NGAYDAT);
            $scope.newgiohang = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    };

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newgiohang);
        $http.put('/api/GioHangAPI/', this.newgiohang).success(function (data) {
            data.NGAYDAT = new Date(data.NGAYDAT).setDate(data.NGAYDAT);
            $scope.giohangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newgiohang = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.giohang.MAGH;
        $scope.loading = true;
        $http.delete('/api/GioHangAPI/' + Id).success(function (data) {
            $scope.giohangs = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newgiohang = '';
    }
}