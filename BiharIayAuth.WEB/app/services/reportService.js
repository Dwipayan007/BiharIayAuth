'use strict';
app.factory('reportService', ['$http', '$q', function ($http, $q) {

    var serviceBase = 'http://localhost:50117/';
    var iayinsServiceFactory = {};

    var _getDistricts = function () {
        debugger;
        return $http.get(serviceBase + '/api/District').then(function (results) {
            return results;
        });
    };

    var _getBlocks = function (did) {
        debugger;
        return $http.get(serviceBase + '/api/Block/' + did).then(function (results) {
            return results;
        });
    };

    var _getPanchayats = function (bid) {
        debugger;
        return $http.get(serviceBase + '/api/Panchayat/' + bid).then(function (results) {
            return results;
        });
    };

    var _postBlock = function (blkrepdata) {
        debugger;
        var deferred = $q.defer();

        var postdata = { method: "POST", url: serviceBase + "/api/BlkLevelReport", data: blkrepdata };
        $http(postdata).success(function (spid) {
            debugger;
            deferred.resolve(spid);

        }).error(function (e) {
            debugger;
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _postPanchayat = function (panchrepdata) {
        debugger;
        var deferred = $q.defer();

        var postdata = { method: "POST", url: serviceBase + "/api/PanchLevelReport", data: panchrepdata };
        $http(postdata).success(function (spid) {
            debugger;
            deferred.resolve(spid);

        }).error(function (e) {
            debugger;
            deferred.reject(err);
        });

        return deferred.promise;

    };

    iayinsServiceFactory.getDistricts = _getDistricts;
    iayinsServiceFactory.getBlocks = _getBlocks;
    iayinsServiceFactory.getPanchayats = _getPanchayats;
    iayinsServiceFactory.postBlock = _postBlock;
    iayinsServiceFactory.postPanchayat = _postPanchayat;

    return iayinsServiceFactory;

}]);