NhaHangApp.controller('donDatBanController', ['$scope', '$http', donDatBanController]);

// Angularjs Controller
function donDatBanController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/DonDatBanAPI/').success(function (data) {
        $scope.dondatbans = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/DonDatBanAPI/', this.newdondatban).success(function (data) {
            $scope.dondatbans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newdondatban = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Edit 
    $scope.edit = function () {
        var Id = this.dondatban.MADATBAN;
        $http.get('/api/DonDatBanAPI/' + Id).success(function (data) {
            data.NGAYDEN = new Date(data.NGAYDEN);
            data.GIODEN = new Date(data.GIODEN);
            $scope.newdondatban = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    };

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newdondatban);
        $http.put('/api/DonDatBanAPI/', this.newdondatban).success(function (data) {
            data.NGAYDEN = new Date(data.NGAYDEN).setDate;
            data.GIODEN = new Date(data.GIODEN).setTime; 
            $scope.dondatbans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newdondatban = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Delete 
    $scope.delete = function () {
        var Id = this.dondatban.MADATBAN;
        $scope.loading = true;
        $http.delete('/api/DonDatBanAPI/' + Id).success(function (data) {
            $scope.dondatbans = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newdondatban = '';
    };
}