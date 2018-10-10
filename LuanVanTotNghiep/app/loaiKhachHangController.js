NhaHangApp.controller('loaiKhachHangController', ['$scope', '$http', loaiKhachHangController]);

// Angularjs Controller
function loaiKhachHangController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/LoaiKhachHangAPI/').success(function (data) {
        $scope.loaikhachhangs = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/LoaiKhachHangAPI/', this.newlkh).success(function (data) {
            $scope.loaikhachhangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newlkh = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.loaikhachhang.MALOAI_KH;
        $http.get('/api/LoaiKhachHangAPI/' + Id).success(function (data) {
            $scope.newlkh = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newlkh);
        $http.put('/api/LoaiKhachHangAPI/', this.newlkh).success(function (data) {
            $scope.loaikhachhangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newlkh = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.loaikhachhang.MALOAI_KH;
        $scope.loading = true;
        $http.delete('/api/LoaiKhachHangAPI/' + Id).success(function (data) {
            $scope.loaikhachhangs = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newlkh = '';
    }
}