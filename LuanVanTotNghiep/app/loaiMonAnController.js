NhaHangApp.controller('loaiMonAnController', ['$scope', '$http', loaiMonAnController]);

// Angularjs Controller
function loaiMonAnController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;

    // Get All 
    $http.get('/api/LoaiMonAnAPI/').success(function (data) {
        $scope.loaimonans = data;
    }).error(function () {
        $scope.error = "An Error has occured while loading posts!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/LoaiMonAnAPI/', this.newloaimonan).success(function (data) {
            $scope.loaimonans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newloaimonan = '';
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding employee! " + data;
        });
    }

    //Edit 
    $scope.edit = function () {
        var Id = this.loaimonan.MALOAI;
        $http.get('/api/LoaiMonAnAPI/' + Id).success(function (data) {
            $scope.newloaimonan = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "An Error has occured while loading posts!";
        });
    }

    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newloaimonan);
        $http.put('/api/LoaiMonAnAPI/', this.newloaimonan).success(function (data) {
            $scope.loaimonans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newloaimonan = '';
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving employee! " + data;
        });
    }

    //Delete 
    $scope.delete = function () {
        var Id = this.loaimonan.MALOAI;
        $scope.loading = true;
        $http.delete('/api/LoaiMonAnAPI/' + Id).success(function (data) {
            $scope.loaimonans = data;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving employee! " + data;
        });
    }

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newloaimonan = '';
    }
}