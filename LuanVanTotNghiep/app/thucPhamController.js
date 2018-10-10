NhaHangApp.controller('thucPhamController', ['$scope', '$http', thucPhamController]);

// Angularjs Controller
function thucPhamController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/ThucPhamAPI/').success(function (data) {
        $scope.thucphams = data;
    }).error(function () {
        $scope.error = "An Error has occured while loading posts!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/ThucPhamAPI/', this.newthucpham).success(function (data) {
            $scope.thucphams = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newthucpham = '';
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding employee! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.thucpham.MATHUCPHAM;
        $http.get('/api/ThucPhamAPI/' + Id).success(function (data) {
            $scope.newthucpham = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "An Error has occured while loading posts!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newthucpham);
        $http.put('/api/ThucPhamAPI/', this.newthucpham).success(function (data) {
            $scope.thucphams = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newthucpham = '';
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving employee! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.thucpham.MATHUCPHAM;
        $scope.loading = true;
        $http.delete('/api/ThucPhamAPI/' + Id).success(function (data) {
            $scope.thucphams = data;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving employee! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newthucpham = '';
    }
}