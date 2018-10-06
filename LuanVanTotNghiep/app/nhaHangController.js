NhaHangApp.controller('nhaHangController', ['$scope', '$http', nhaHangController]);

// Angularjs Controller
function nhaHangController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/NhaHangAPI/').success(function (data) {
        $scope.nhahangs = data;
    }).error(function () {
        $scope.error = "An Error has occured while loading posts!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/NhaHangAPI/', this.newnh).success(function (data) {
            $scope.nhahangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newnh = '';
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding employee! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.nhahang.MANHAHANG;
        $http.get('/api/NhaHangAPI/' + Id).success(function (data) {
            $scope.newnh = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "An Error has occured while loading posts!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newnh);
        $http.put('/api/NhaHangAPI/', this.newnh).success(function (data) {
            $scope.nhahangs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newnh = '';
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving employee! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.nhahang.MANHAHANG;
        $scope.loading = true;
        $http.delete('/api/NhaHangAPI/' + Id).success(function (data) {
            $scope.nhahangs = data;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving employee! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newnh = '';
    }
}