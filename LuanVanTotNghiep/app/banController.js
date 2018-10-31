NhaHangApp.controller('banController', ['$scope', '$http', banController]);

// Angularjs Controller
function banController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/BanAPI/').success(function (data) {
        $scope.bans = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });

    $http.get('/api/BanAPI/gettang').success(function (data) {
        $scope.tangs = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/BanAPI/', this.newban).success(function (data) {
            $scope.bans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newban = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.ban.MABAN;
        $http.get('/api/BanAPI/' + Id).success(function (data) {
            $scope.newban = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newban);
        $http.put('/api/BanAPI/', this.newban).success(function (data) {
            $scope.bans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newban = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.ban.MABAN;
        $scope.loading = true;
        $http.delete('/api/BanAPI/' + Id).success(function (data) {
            $scope.bans = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newban = '';
    }
}