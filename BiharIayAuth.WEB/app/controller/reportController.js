'use strict';
app.controller('reportController', ['$scope', 'reportService', function ($scope, reportService) {

    debugger;
    $scope.iayins = {};

    reportService.getDistricts().then(function (results) {
        debugger;
        $scope.districts = results.data;
        var pdata = { did: 0, dname: "Please Select" };
        $scope.districts.splice(0, 0, pdata);
        $scope.iayins.DISTRICT = $scope.districts[0];
    }, function (error) {
        //alert(error.data.message);
    });


    $scope.$watch('iayins.DISTRICT', function () {
        debugger;
        var did = $scope.iayins.DISTRICT.did;
        reportService.getBlocks(did).then(function (results) {
            debugger;
            $scope.blocks = results.data;
            var pdata = { bid: 0, bname: "Please Select" };
            $scope.blocks.splice(0, 0, pdata);
            $scope.iayins.BLOCK = $scope.blocks[0];
        }).error(function (e) {
            debugger;
        });
    });

    $scope.$watch('iayins.BLOCK', function () {
        debugger;
        var bid = $scope.iayins.BLOCK.bid;
        reportService.getPanchayats(bid).then(function (results) {
            debugger;
            $scope.panchayats = results.data;
            var pdata = { pid: 0, pname: "Please Select" };
            $scope.panchayats.splice(0, 0, pdata);
            $scope.iayins.PANCHAYAT = $scope.panchayats[0];
        }).error(function (e) {
            debugger;
        });
    });

    $scope.getBlockReport = function () {
        debugger;
        reportService.postBlock($scope.iayins).then(function (path) {
            debugger;
            path = path.slice(1, path.length - 1);
            window.open('pdfstore\\'+path, '_blank', '');
        }).error(function (e) {
            debugger;
        });
    };

    $scope.getPanchReport = function () {
        debugger;
        reportService.postPanchayat($scope.iayins).then(function (path) {
            debugger;
            path = path.slice(1, path.length - 1);
            window.open('pdfstore\\' + path, '_blank', '');
        }).error(function (e) {
            debugger;
        });
    };
}]);