NhaHangApp.factory("nhahangRepoService", nhahangRepoService);

var nhahangRepoService = function ($http) {

    var getNhaHangs = function (tennhahang) {
        return $http.get("http://localhost:14874/api/NhaHangAPI/")
            .then(function (response) {
                return response.data;
            });
    };

    return {
        get: getNhaHangs
    };

};