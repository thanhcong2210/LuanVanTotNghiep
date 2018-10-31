NhaHangApp.controller('chucVuController', ['$scope', '$http', chucVuController]);

// Angularjs Controller
function chucVuController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/ChucVuAPI/').success(function (data) {
        $scope.chucvus = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/ChucVuAPI/', this.newchucvu).success(function (data) {
            $scope.chucvus = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newchucvu = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.chucvu.MACV;
        $http.get('/api/ChucVuAPI/' + Id).success(function (data) {
            $scope.newchucvu = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newchucvu);
        $http.put('/api/ChucVuAPI/', this.newchucvu).success(function (data) {
            $scope.chucvus = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newchucvu = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.chucvu.MACV;
        $scope.loading = true;
        $http.delete('/api/ChucVuAPI/' + Id).success(function (data) {
            $scope.chucvus = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newchucvu = '';
    }
}