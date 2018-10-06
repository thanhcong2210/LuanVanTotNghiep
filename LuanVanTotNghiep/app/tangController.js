NhaHangApp.controller('tangController', ['$scope', '$http', tangController]);

// Angularjs Controller
function tangController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/TangAPI/').success(function (data) {
        $scope.tangs = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    //$http.getnhahang('/api/TangAPI/').success(function (data) {
    //    $scope.nhahangs = data;
    //}).error(function () {
    //    $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    //});
    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/TangAPI/', this.newt).success(function (data) {
            $scope.tang = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newt = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.tang.MATANG;
        $http.get('/api/TangAPI/' + Id).success(function (data) {
            $scope.newt = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newt);
        $http.put('/api/TangAPI/', this.newt).success(function (data) {
            $scope.tangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newt = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.tang.MATANG;
        $scope.loading = true;
        $http.delete('/api/TangAPI/' + Id).success(function (data) {
            $scope.tangs = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.tangs = '';
    }
}