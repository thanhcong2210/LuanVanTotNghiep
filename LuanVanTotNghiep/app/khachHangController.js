NhaHangApp.controller('khachHangController', ['$scope', '$http', khachHangController]);

// Angularjs Controller
function khachHangController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/KhachHangAPI/').success(function (data) {
        $scope.khachhangs = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });
    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/KhachHangAPI/', this.newkh).success(function (data) {
            $scope.khachhangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newkh = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.khachhang.MAKH;
        $http.get('/api/KhachHangAPI/' + Id).success(function (data) {
            $scope.newkh = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newkh);
        $http.put('/api/KhachHangAPI/', this.newkh).success(function (data) {
            $scope.khachhangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newkh = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.khachhang.MAKH;
        $scope.loading = true;
        $http.delete('/api/KhachHangAPI/' + Id).success(function (data) {
            $scope.khachhangs = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.khachhangs = '';
    }
}