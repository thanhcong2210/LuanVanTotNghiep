NhaHangApp.controller('monAnController', ['$scope', '$http','growl', monAnController]);

// Angularjs Controller
function monAnController($scope, $http, growl) {
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
    //button thêm mới 
    $scope.ShowHide = function () {
        $scope.ShowAddForm = $scope.ShowAddForm = true;
        $scope.ShowUpdateForm = $scope.ShowUpdateForm = false;
        $scope.ShowDataTable = $scope.ShowDataTable = false;
    };
    // lấy tất cả thông tin

    $http.get('/api/MonAnAPI/').success(function (data) {
            $scope.ShowAddForm = false;
            $scope.ShowUpdateForm = false;
            $scope.ShowDataTable = true;
            $scope.monans = data;
            $scope.totalItems = $scope.monans.length;
            
    }).error(function () {
        growl.error('Xảy ra lỗi trong quá trình tải dữ liệu lên!', { title: 'Thông báo' });
        });
    //phân trang
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
    ////phân trang
    //lấy danh sách loại món ăn
    $http.get('/api/MonAnAPI/loaimonan').success(function (data) {
        $scope.loaimonans = data;
    }).error(function () {
        growl.error('Xảy ra lỗi trong quá trình tải dữ liệu loại món ăn!', { title: 'Thông báo' });
        });

    //lấy danh sách hình ảnh 
    $http.get('/api/MonAnAPI/hinhanh').success(function (data) {
        $scope.hinhanhs = data;
    }).error(function () {
        growl.error('Xảy ra lỗi trong quá trình tải dữ liệu hình ảnh!', { title: 'Thông báo' });
        });

    //lấy danh sách đơn vị tính
    $http.get('/api/MonAnAPI/donvitinh').success(function (data) {
        $scope.dvtinhs = data;
    }).error(function () {
        growl.error('Xảy ra lỗi trong quá trình tải dữ liệu đơn vị tính!', { title: 'Thông báo' });
    });

    //thêm mới 
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/MonAnAPI/', this.newmonanadd).success(function (data) {
            $scope.monans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            growl.success('Thêm mới thành công !', { title: 'Thông báo' });
            location.reload();
            $scope.newmonanadd = '';
            
        }).error(function (data) {
            growl.error('Thêm mới không thành công !'+ data +'', { title: 'Lỗi' }); //thông báo
        });
    };

    //chỉnh sửa
    //lấy mã món để chình sửa
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
            growl.error('Xảy ra lỗi trong quá trình tải dữ liệu!', { title: 'Thông báo' });
        });
    };
    //cập nhật vào CSDL
    $scope.update = function () {
        $scope.loading = true;
        $scope.ShowDataTable = true;
        $scope.ShowAddForm = false;
        console.log(this.newmonan);
        $http.put('/api/MonAnAPI/', this.newmonan).success(function (data) {
            data.NGAYTAOMOI = new Date(data.NGAYTAOMOI).setDate(data.NGAYTAOMOI);
            $scope.monans = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newmonan = '';
            location.reload();
            $scope.ShowDataTable = false;
            $scope.ShowAddForm = false;
            $scope.ShowUpdateForm = false;
            growl.success('Cập nhật thành công !', { title: 'Thông báo' });
        }).error(function (data) {
            growl.error('Xảy ra lỗi trong quá trình lưu thông tin! ' + data, { title: 'Thông báo' });
        });
    };

    //Xóa
    $scope.delete = function () {
        var Id = this.monan.MAMON;
        $scope.loading = true;
        $http.delete('/api/MonAnAPI/' + Id).success(function (data) {
            growl.success('Xóa thành công !', { title: 'Thông báo' });
            $scope.monans = data;
            
            location.reload();
        }).error(function (data) {
            growl.error('Xóa không thành công' + data + ' !', { title: 'Thông báo' });
            
        });
    };

    //Hủy bỏ
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newmonan = '';
        $scope.newmonanadd = '';
        $scope.ShowAddForm = false;
        $scope.ShowUpdateForm = false;
        $scope.ShowDataTable = true;
        $scope.error = "";
        $scope.reload();

    };
    // load lại trang
    $scope.reload = function () {
        $http.get('/api/MonAnAPI/').success(function (data) {
            $scope.ShowAddForm = false;
            $scope.ShowUpdateForm = false;
            $scope.ShowDataTable = true;
            $scope.monans = data;
            $scope.totalItems = $scope.monans.length;
        }).error(function () {
            growl.error('Xảy ra lỗi trong quá trình tải dữ liệu hình ảnh!', { title: 'Thông báo' });
        });
    };
    
    
}