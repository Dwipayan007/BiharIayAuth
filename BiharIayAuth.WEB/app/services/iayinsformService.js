'use strict';
app.factory('iayinsformService', ['$http', '$q', function ($http, $q) {

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
        return $http.get(serviceBase + '/api/Block/'+did).then(function (results) {
            return results;
        });
    };

    var _getPanchayats = function (bid) {
        debugger;
        return $http.get(serviceBase + '/api/Panchayat/'+ bid).then(function (results) {
            return results;
        });
    };

    var _getBenefs = function (pid) {
        debugger;
        return $http.get(serviceBase + '/api/Benef/' + pid).then(function (results) {
            return results;
        });
    };
    var _postIayIns = function (iayins) {
        debugger;
        var deferred = $q.defer();

        var postdata = { method: "POST", url: serviceBase + "/api/IayForm", data: iayins };
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
    iayinsServiceFactory.getBenefs = _getBenefs;
    iayinsServiceFactory.postIayIns = _postIayIns;

    return iayinsServiceFactory;

}]);