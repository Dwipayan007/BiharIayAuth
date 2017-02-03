
var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);
app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/blkrep", {
        controller: "reportController",
        templateUrl: "/app/views/blocklevelreport.html"
    });

    $routeProvider.when("/panchrep", {
        controller: "reportController",
        templateUrl: "/app/views/panchlevelreport.html"
    });

    $routeProvider.when("/iayinsform", {
        controller: "iayinsformController",
        templateUrl: "/app/views/iayinsform.html"
    });

    $routeProvider.when("/ddreport", {
        controller: "drilldownController",
        templateUrl: "/app/views/drilldownreport.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);