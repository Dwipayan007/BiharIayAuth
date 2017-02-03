'use strict';
app.controller('drilldownController', ['$scope', 'drilldownService', function ($scope, drilldownService) {

    debugger;
    $scope.drilldata = [];

    drilldownService.getDistrictsData().then(function (results) {
        debugger;
        $scope.drilldata = results;
    }, function (error) {
        //alert(error.data.message);
    });

    $scope.getBlocks = function (did) {
        debugger;
        drilldownService.getBlocksData(did).then(function (results) {
            debugger;
            $scope.drilldata = results;
        }, function (error) {
            //alert(error.data.message);
        });
    };

    $scope.getPanchayats = function (bid) {
        debugger;
        drilldownService.getPanchayatsData(bid).then(function (results) {
            debugger;
            $scope.drilldata = results;
        }, function (error) {
            //alert(error.data.message);
        });
    };

    $scope.getBenefs = function (pid) {
        debugger;
        drilldownService.getBenefsData(pid).then(function (results) {
            debugger;
            $scope.drilldata = results;
        }, function (error) {
            //alert(error.data.message);
        });
    };
}]);