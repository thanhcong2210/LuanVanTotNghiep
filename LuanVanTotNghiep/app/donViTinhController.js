NhaHangApp.controller('donViTinhController', ['$scope', '$http', donViTinhController]);

// Angularjs Controller
function donViTinhController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/DonViTinhAPI/').success(function (data) {
        $scope.dvtinhs = data;
    }).error(function () {
        $scope.error = "An Error has occured while loading posts!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/DonViTinhAPI/', this.newdvtinh).success(function (data) {
            $scope.dvtinhs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newdvtinh = '';
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding employee! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.dvtinh.MADVTINH;
        $http.get('/api/DonViTinhAPI/' + Id).success(function (data) {
            $scope.newdvtinh = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "An Error has occured while loading posts!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newdvtinh);
        $http.put('/api/DonViTinhAPI/', this.newdvtinh).success(function (data) {
            $scope.dvtinhs = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newdvtinh = '';
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving employee! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.dvtinh.MADVTINH;
        $scope.loading = true;
        $http.delete('/api/DonViTinhAPI/' + Id).success(function (data) {
            $scope.dvtinhs = data;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving employee! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newdvtinh = '';
    }
}