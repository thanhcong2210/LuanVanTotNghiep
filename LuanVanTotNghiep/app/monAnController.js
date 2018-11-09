NhaHangApp.controller('monAnController', ['$scope', '$http', monAnController]);

// Angularjs Controller
function monAnController($scope, $http) {
    // Declare variable
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;
    $scope.ShowAddForm;
    $scope.ShowUpdateForm;
    $scope.ShowDataTable;
    $scope.viewby = 10;
    $scope.totalItems = 0;
    $scope.currentPage = 4;
    $scope.itemsPerPage = $scope.viewby;
    $scope.maxSize = 5; //Number of pager buttons to show
    


    $scope.ShowHide = function () {
        $scope.ShowAddForm = $scope.ShowAddForm = true;
        $scope.ShowUpdateForm = $scope.ShowUpdateForm = false;
        $scope.ShowDataTable = $scope.ShowDataTable = false;
    };
    // Get All 

    $http.get('/api/MonAnAPI/').success(function (data) {
            $scope.ShowAddForm = false;
            $scope.ShowUpdateForm = false;
            $scope.ShowDataTable = true;
            $scope.monans = data;
            $scope.totalItems = $scope.monans.length;
            
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
    //get loai mon an
    $http.get('/api/MonAnAPI/loaimonan').success(function (data) {
        $scope.loaimonans = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });

    //get hinh anh
    $http.get('/api/MonAnAPI/hinhanh').success(function (data) {
        $scope.hinhanhs = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });

    //get dvtinh 
    $http.get('/api/MonAnAPI/donvitinh').success(function (data) {
        $scope.dvtinhs = data;
    }).error(function () {
        $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
    });

    //Insert 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/MonAnAPI/', this.newmonan).success(function (data) {
            $scope.monans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newmonan = '';
            $scope.reload();
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Edit 
    $scope.edit = function () {
        $scope.ShowUpdateForm = true;
        $scope.ShowDataTable = false;
        var Id = this.monan.MAMON;
        $http.get('/api/MonAnAPI/' + Id).success(function (data) {
            
            data.NGAYTAOMOI = new Date(data.NGAYTAOMOI);
            $scope.newmonan = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        }).error(function () {
            $scope.error = "Xảy ra lỗi trong quá trình tải dữ liệu lên!";
        });
    };

    $scope.update = function () {
        $scope.loading = true;
        $scope.ShowDataTable = true;
        $scope.ShowAddForm = false;
        console.log(this.newmonan);
        $http.put('/api/MonAnAPI/', this.newmonan).success(function (data) {
            data.NGAYTAOMOI = new Date(data.NGAYTAOMOI);
            $scope.monans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newmonan = '';
            $scope.reload();
            $interval($scope.reload, 5000);
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Delete 
    $scope.delete = function () {
        var Id = this.monan.MAMON;
        $scope.loading = true;
        $http.delete('/api/MonAnAPI/' + Id).success(function (data) {
            $scope.monans = data;
        }).error(function (data) {
            $scope.error = "Xảy ra lỗi trong quá trình lưu thông tin! " + data;
        });
    };

    //Cancel 
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newmonan = '';
        $scope.ShowAddForm = false;
        $scope.ShowUpdateForm = false;
        $scope.ShowDataTable = true;
        $scope.error = "";
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