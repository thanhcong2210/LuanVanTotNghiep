//app.js
var NhaHangApp = angular.module('NhaHangApp', ['ui.router']);

NhaHangApp.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    // For any unmatched url, send to /business
    $urlRouterProvider.otherwise("/")

    $stateProvider
        .state('home', {//State demonstrating Nested views
            url: "/home",
            templateUrl: '/app/components/home/homeView.html',
            controller: 'homeController'
        })
        .state('monan', {//nested state [products is the nested state of business state]
            url: "/monan",
            templateUrl: '/app/components/monan/monanListView.html',
            controller: 'monanListController'
        })
        .state('loaimonan', {//nested state [products is the nested state of business state]
        url: "/loaimonan",
            templateUrl: '/app/View/LoaiMonAnList.html',
            controller: 'loaiMonAnController'
        });
}]);
