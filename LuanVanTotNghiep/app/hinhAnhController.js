NhaHangApp.controller('hinhAnhController', ['$scope', 'AddImageService', hinhAnhController]);

function hinhAnhController($scope, $AddImageService) {
    //Add File start.....
    $scope.getTheFiles = function ($files) {

        $scope.imagesrc = [];

        for (var i = 0; i < $files.length; i++) {

            var reader = new FileReader();
            reader.fileName = $files[i].name;

            reader.onload = function (event) {

                var image = {};
                image.TENHINHANH = event.target.fileName;
                image.DUONGDAN1 = event.target.result;
                $scope.imagesrc.push(image);
                $scope.$apply();
            };
            reader.readAsDataURL($files[i]);
        }

        $scope.Files = $files;

    };
    //Add File End...

    // Submit Forn data
    $scope.Submit = function () {


        //FILL FormData WITH FILE DETAILS.
        var data = new FormData();

        angular.forEach($scope.Files, function (value, key) {
            data.append(key, value);
        });

        data.append("DealModel", angular.toJson($scope.HINHANH));
        AddImageService.AddImage(data).then(function (response) {
            alert("Added Successfully");
        }, function () {

        });
    };



}

NhaHangApp.factory('AddImageService', ['$http', function ($http) {

    var fac = {};

    fac.AddImage = function (data) {
        return $http.post("/api/HinhAnhAPI/", data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        });
    };
    return fac;
}]);

