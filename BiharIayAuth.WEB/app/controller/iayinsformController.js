'use strict';
app.controller('iayinsformController', ['$scope', 'iayinsformService', function ($scope, iayinsformService) {

    debugger;
    $scope.iayins = {};
    $scope.hlevels = ['Please Select', 'Not Started', 'Plinth Level', 'Lintel Level', 'Roof Level', 'Completed'];
    $scope.iayins.HOUSELEVEL = $scope.hlevels[0];

    iayinsformService.getDistricts().then(function (results) {
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
        iayinsformService.getBlocks(did).then(function (results) {
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
        iayinsformService.getPanchayats(bid).then(function (results) {
            debugger;
            $scope.panchayats = results.data;
            var pdata = { pid: 0, pname: "Please Select" };
            $scope.panchayats.splice(0, 0, pdata);
            $scope.iayins.PANCHAYAT = $scope.panchayats[0];
        }).error(function (e) {
            debugger;
        });
    });

    $scope.$watch('iayins.PANCHAYAT', function () {
        debugger;
        var pid = $scope.iayins.PANCHAYAT.pid;
        iayinsformService.getBenefs(pid).then(function (results) {
            debugger;
            $scope.benefs = results.data;
            var pdata = { bfid: 0, bfname: "Please Select" };
            $scope.benefs.splice(0, 0, pdata);
            $scope.iayins.BENEF = $scope.benefs[0];
        }).error(function (e) {
            debugger;
        });
    });

    $scope.addIayIns = function () {
        debugger;
        iayinsformService.postIayIns($scope.iayins).then(function (results) {
            debugger;
       
        }).error(function (e) {
            debugger;
        });
    };

    $scope.getReport = function () {
        debugger;
        iayinsformService.postBlock($scope.iayins.BLOCK).then(function (results) {
            debugger;

        }).error(function (e) {
            debugger;
        });
    };
}]);