NhaHangApp.controller('hinhAnhController', ['$scope', '$http', hinhAnhController]);

function hinhAnhController($scope, $http) {
        // Declare variable
        $scope.loading = true;
        $scope.updateShow = false;
        $scope.addShow = true;

        // Get All 
        $http.get('/api/HinhAnhAPI/').success(function (data) {
            $scope.hinhanhs = data;
        }).error(function () {
            $scope.error = "An Error has occured while loading posts!";
        });

        //Insert 
        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/HinhAnhAPI/', this.newha).success(function (data) {
                $scope.hinhanhs = data;
                $scope.updateShow = false;
                $scope.addShow = true;
                $scope.newha = '';
            }).error(function (data) {
                $scope.error = "An Error has occured while Adding Image! " + data;
            });
        }

        //Edit 
        $scope.edit = function () {
            var Id = this.hinhanh.MAHINHANH;
            $http.get('/api/HinhAnhAPI/' + Id).success(function (data) {
                $scope.newha = data;
                $scope.updateShow = true;
                $scope.addShow = false;
            }).error(function () {
                $scope.error = "An Error has occured while loading posts!";
            });
        }

        $scope.update = function () {
            $scope.loading = true;
            console.log(this.newha);
            $http.put('/api/HinhAnhAPI/', this.newha).success(function (data) {
                $scope.dvtinhs = data;
                $scope.updateShow = false;
                $scope.addShow = true;
                $scope.newha = '';
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Image! " + data;
            });
        }

        //Delete 
        $scope.delete = function () {
            var Id = this.hinhanh.MAHINHANH;
            $scope.loading = true;
            $http.delete('/api/HinhAnhAPI/' + Id).success(function (data) {
                $scope.hinhanhs = data;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Image! " + data;
            });
        }

        //Cancel 
        $scope.cancel = function () {
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newha = '';
        }
}
