NhaHangApp.controller('donDatBanController', ['$scope', '$http', donDatBanController]);

// Angularjs Controller
function donDatBanController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;
    $scope.Changed;
    $scope.ShowChuaDuyet;
    //code
    $scope.ShowUpdateForm = false;
    $scope.ShowDataTable;
    $scope.viewby = 10;
    $scope.totalItems = 0;
    $scope.currentPage = 4;
    $scope.itemsPerPage = $scope.viewby;
    $scope.maxSize = 5; //Number of pager buttons to show
    $scope.activeduyet;
    $scope.activechuaduyet;
    

    // Get All 
    $http.get('/api/DonDatBanAPI/').success(function (data) {
        $scope.activeduyet = "active";
        $scope.activechuaduyet = "";
        $scope.ShowUpdateForm = false;
        $scope.ShowDataTable = true;
        $scope.dondatbans = data;
        $scope.totalItems = $scope.dondatbans.length;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };

    $scope.pageChanged = function () {
        console.log('Page changed to: ' + $scope.currentPage);
    };

    $scope.setItemsPerPage = function (num) {
        $scope.itemsPerPage = num;
        $scope.currentPage = 1; //reset to first page
    };
    //change tabs
    $scope.ChangeChuaDuyet = function () {
        $http.get('/api/DonDatBanAPI/getchuaduyet').success(function (data) {
            $scope.activeduyet = "";
            $scope.activechuaduyet = "active";
            $scope.ShowUpdateForm = false;
            $scope.ShowChuaDuyet = true;
            $scope.ShowDataTable = false;
            $scope.chuaduyets = data;
            $scope.totalItems = $scope.chuaduyets.length;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    };
    $scope.ChangeDuyet = function () {
        $http.get('/api/DonDatBanAPI/').success(function (data) {
            $scope.activeduyet = "active";
            $scope.activechuaduyet = "";
            $scope.ShowChuaDuyet = false;
            $scope.ShowDataTable = true;
            $scope.ShowUpdateForm = false;
            $scope.dondatbans = data;
            $scope.totalItems = $scope.dondatbans.length;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    };
    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/DonDatBanAPI/', this.newdondatban).success(function (data) {
            $scope.dondatbans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newdondatban = '';
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Edit 
    $scope.edit = function () {
        $scope.ShowUpdateForm = true;
        $scope.ShowDataTable = false;
        $scope.ShowChuaDuyet = false;
        var Id = this.chuaduyet.MADATBAN;
        $http.get('/api/DonDatBanAPI/' + Id).success(function (data) {
            data.NGAYDEN = new Date(data.NGAYDEN);
            data.GIODEN = new Date(data.GIODEN);
            $scope.newdondatban = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    };

    $scope.update = function () {
        $scope.loading = true;
        $scope.ShowUpdateForm = true;
        $scope.ShowDataTable = false;
        $scope.ShowChuaDuyet = false;
        console.log(this.newdondatban);
        $http.put('/api/DonDatBanAPI/', this.newdondatban).success(function (data) {
            data.NGAYDEN = new Date(data.NGAYDEN).setDate;
            data.GIODEN = new Date(data.GIODEN).setTime; 
            $scope.dondatbans = data;
            $scope.updateShow = true;
            $scope.addShow = false;
            $scope.newdondatban = '';
            $scope.reload();
            $interval($scope.reload, 5000);
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Delete 
    $scope.delete = function () {
        var Id = this.dondatban.MADATBAN;
        $scope.loading = true;
        $http.delete('/api/DonDatBanAPI/' + Id).success(function (data) {
            $scope.dondatbans = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newdondatban = '';
        $scope.ShowUpdateForm = false;
        $scope.ShowDataTable = true;
        $scope.reload();
        $interval($scope.reload, 5000);
    };
    $scope.reload = function () {
        $http.get('/api/MonAnAPI/').success(function (data) {
            $scope.ShowAddForm = false;
            $scope.ShowUpdateForm = false;
            $scope.ShowDataTable = true;
            $scope.monans = data;
            $scope.totalItems = $scope.monans.length;

        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    };
}