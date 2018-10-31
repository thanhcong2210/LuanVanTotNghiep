NhaHangApp.controller('duyetGioHangController', ['$scope', '$http', duyetGioHangController]);

// Angularjs Controller
function duyetGioHangController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/DuyetGioHangAPI/').success(function (data) {
        $scope.duyetgiohangs = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });


    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/DuyetGioHangAPI/', this.newduyetgiohang).success(function (data) {
            $scope.duyetgiohangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newduyetgiohang = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Edit 
    $scope.edit = function () {
        var Id = this.duyetgiohang.MADUYET;
        $http.get('/api/DuyetGioHangAPI/' + Id).success(function (data) {
            data.NGAYDUYET = new Date(data.NGAYDUYET);
            $scope.newduyetgiohang = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    };

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newduyetgiohang);
        $http.put('/api/DuyetGioHangAPI/', this.newduyetgiohang).success(function (data) {
            $scope.duyetgiohangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newduyetgiohang = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Delete 
    $scope.delete = function () {
        var Id = this.duyetgiohang.MADUYET;
        $scope.loading = true;
        $http.delete('/api/DuyetGioHangAPI/' + Id).success(function (data) {
            $scope.duyetgiohangs = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newduyetgiohang = '';
    };
}