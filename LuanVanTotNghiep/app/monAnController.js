NhaHangApp.controller('monAnController', ['$scope', '$http', monAnController]);

// Angularjs Controller
function monAnController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/MonAnAPI/').success(function (data) {
        $scope.monans = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/MonAnAPI/', this.newmonan).success(function (data) {
            $scope.monans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newmonan = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin!" + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.monan.MAMON;
        $http.get('/api/MonAnAPI/' + Id).success(function (data) {
            data.NGAYTAOMOI = new Date(data.NGAYTAOMOI);
            $scope.newmonan = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newmonan);
        $http.put('/api/MonAnAPI/', this.newmonan).success(function (data) {
            data.NGAYTAOMOI = new Date(data.NGAYTAOMOI);
            $scope.monans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newmonan = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.monan.MAMON;
        $scope.loading = true;
        $http.delete('/api/MonAnAPI/' + Id).success(function (data) {
            $scope.monans = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newmonan = '';
    }
}