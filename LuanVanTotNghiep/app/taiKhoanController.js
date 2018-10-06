NhaHangApp.controller('taiKhoanController', ['$scope', '$http', taiKhoanController]);

// Angularjs Controller
function taiKhoanController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/TaiKhoanAPI/').success(function (data) {
        $scope.taikhoans = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });
    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/TaiKhoanAPI/', this.newtk).success(function (data) {
            $scope.tang = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newtk = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.taikhoan.MATAIKHOAN;
        $http.get('/api/TaiKhoanAPI/' + Id).success(function (data) {
            $scope.newtk = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newtk);
        $http.put('/api/TaiKhoanAPI/', this.newtk).success(function (data) {
            $scope.taikhoans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newtk = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.taikhoan.MATAIKHOAN;
        $scope.loading = true;
        $http.delete('/api/TaiKhoanAPI/' + Id).success(function (data) {
            $scope.taikhoans = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.taikhoans = '';
        $scope.error = '';
    }
}