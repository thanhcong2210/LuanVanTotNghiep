NhaHangApp.controller('phieuNhapController', ['$scope', '$http', phieuNhapController]);

// Angularjs Controller
function phieuNhapController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/PhieuNhapAPI/').success(function (data) {
        $scope.phieunhaps = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/PhieuNhapAPI/', this.newphieunhap).success(function (data) {
            $scope.phieunhaps = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newphieunhap = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin!" + data;
        });
    };

    //Edit 
    $scope.edit = function () {
        var Id = this.phieunhap.MAPHIEUNHAP;
        $http.get('/api/PhieuNhapAPI/' + Id).success(function (data) {
            data.NGAYNHAP = new Date(data.NGAYNHAP);
            $scope.newphieunhap = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    };

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newphieunhap);
        $http.put('/api/PhieuNhapAPI/', this.newphieunhap).success(function (data) {
            $scope.phieunhaps = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newphieunhap = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };
    //Delete 
    $scope.delete = function () {
        var Id = this.phieunhap.MAPHIEUNHAP;
        $scope.loading = true;
        $http.delete('/api/PhieuNhapAPI/' + Id).success(function (data) {
            $scope.phieunhaps = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newphieunhap = '';
    };
}