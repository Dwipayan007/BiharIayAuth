'use strict';
app.factory('drilldownService', ['$http', '$q', function ($http, $q) {

    var serviceBase = 'http://localhost:50117/';
    var drilldownServiceFactory = {};

    var _getDistrictsData = function () {
        var deferred = $q.defer();
        var p = 'district,0';
        $http.get(serviceBase + '/api/Drilldown/' + p).success(function (res) {
            deferred.resolve(res);
        }).error(function (err) {

            deferred.reject(err);
        });
        return deferred.promise;
    };

    var _getBlocksData = function (did) {
        debugger;
        var deferred = $q.defer();
        var p = 'block,' + did;
        $http.get(serviceBase + '/api/Drilldown/' + p).success(function (res) {
            deferred.resolve(res);
        }).error(function (err) {

            deferred.reject(err);
        });
        return deferred.promise;
    };

    var _getPanchayatsData = function (bid) {
        debugger;
        var deferred = $q.defer();
        var p = 'panchayat,' + bid;
        $http.get(serviceBase + '/api/Drilldown/' + p).success(function (res) {
            deferred.resolve(res);
        }).error(function (err) {

            deferred.reject(err);
        });
        return deferred.promise;
    };

    var _getBenefsData = function (pid) {
        debugger;
        var deferred = $q.defer();
        var p = 'benef,' + pid;
        $http.get(serviceBase + '/api/Drilldown/' + p).success(function (res) {
            deferred.resolve(res);
        }).error(function (err) {

            deferred.reject(err);
        });
        return deferred.promise;
    };

    drilldownServiceFactory.getDistrictsData = _getDistrictsData;
    drilldownServiceFactory.getBlocksData = _getBlocksData;
    drilldownServiceFactory.getPanchayatsData = _getPanchayatsData;
    drilldownServiceFactory.getBenefsData = _getBenefsData;

    return drilldownServiceFactory;

}]);