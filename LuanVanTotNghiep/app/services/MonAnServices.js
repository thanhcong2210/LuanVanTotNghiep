NhaHangApp.factory('MonAnServices', function ($http, $q, $log, $rootScope) {

    var baseUrl = '/api/MonAnAPI';

    var service = {
        data: {
            currentmonan: {},
            monans: [],
            selected: [],
            totalPages: 0,

            filterOptions: {
                filterText: '',
                externalFilter: 'searchText',
                useExternalFilter: true
            },
            sortOptions: {
                fields: ["MAMON"],
                directions: ["desc"]
            },
            pagingOptions: {
                pageSizes: [10, 20, 50, 100],
                pageSize: 10,
                currentPage: 1
            }
        },

        find: function () {
            var params = {
                searchtext: service.data.filterOptions.filterText,
                page: service.data.pagingOptions.currentPage,
                pageSize: service.data.pagingOptions.pageSize,
                sortBy: service.data.sortOptions.fields[0],
                sortDirection: service.data.sortOptions.directions[0]
            };

            var deferred = $q.defer();
            $http.get(baseUrl, { params: params })
                .success(function (data) {
                    service.data.monans = data;
                    deferred.resolve(data);
                }).error(function () {
                    deferred.reject();
                });
            return deferred.promise;
        }
    };

    service.find();
    return service;

});