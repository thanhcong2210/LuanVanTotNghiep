NhaHangApp.controller('nhanVienController', ['$scope', '$http', nhanVienController]);

// Angularjs Controller
function nhanVienController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/NhanVienAPI/').success(function (data) {
        $scope.nhanviens = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/NhanVienAPI/', this.newnhanvien).success(function (data) {
            $scope.nhanviens = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newnhanvien = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin!" + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.nhanvien.MANV;
        $http.get('/api/NhanVienAPI/' + Id).success(function (data) {
            data.NGAYSINH_NV = new Date(data.NGAYSINH_NV);
            $scope.newnhanvien = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newnhanvien);
        $http.put('/api/NhanVienAPI/', this.newnhanvien).success(function (data) {
            data.NGAYSINH_NV = new Date(data.NGAYSINH_NV);
            $scope.nhanviens = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newnhanvien = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.nhanvien.MANV;
        $scope.loading = true;
        $http.delete('/api/NhanVienAPI/' + Id).success(function (data) {
            $scope.nhanviens = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newnhanvien = '';
    }
}