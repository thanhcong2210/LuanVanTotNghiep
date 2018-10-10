NhaHangApp.controller('nhaCungCapController', ['$scope', '$http', nhaCungCapController]);

// Angularjs Controller
function nhaCungCapController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/NhaCungCapAPI/').success(function (data) {
        $scope.nhacungcaps = data;
    }).error(function () {
        $scope.error = "An Error has occured while loading posts!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/NhaCungCapAPI/', this.newncc).success(function (data) {
            $scope.nhacungcaps = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newncc = '';
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding employee! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.nhacungcap.MANCC;
        $http.get('/api/NhaCungCapAPI/' + Id).success(function (data) {
            $scope.newncc = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "An Error has occured while loading posts!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newncc);
        $http.put('/api/NhaCungCapAPI/', this.newncc).success(function (data) {
            $scope.nhacungcaps = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newncc = '';
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving employee! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.nhacungcap.MANCC;
        $scope.loading = true;
        $http.delete('/api/NhaCungCapAPI/' + Id).success(function (data) {
            $scope.nhacungcaps = data;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving employee! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newncc = '';
    }
}