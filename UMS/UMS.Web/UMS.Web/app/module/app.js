/// <reference path="../../Js/angular.js" />
var app = angular.module("mainApp", ['ui.router']);

app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $stateProvider
        .state('login', {
            url: '/login',
            templateUrl: 'app/views/login.html',
            controller: 'loginController'

        });
    //.state('dashboard', {})
    $urlRouterProvider.otherwise('/login');
}])



//var app = angular.module("mainApp", ['ngRoute']);
//app.config(['$routeProvider', function ($routeProvider) {
//    $routeProvider
//        .when('/adduser',
//        {
//            templateUrl: 'app/views/form.html',
//            controller: 'formUsercontroller',
//            currentpage: 'adduser'
//        })
//        .when('/viewuser',
//        {
//            templateUrl: 'app/views/index.html',
//            controller: 'userListcontroller',
//            currentpage: 'viewuser'
//        })
//        .when('/edituser/:id', {
//            templateUrl: 'app/views/form.html',
//            controller: 'formUsercontroller',
//            currentpage: 'edituser'
//        })
//        .when('/delete/:id',
//        {
//            templateUrl: 'app/views/index.html',
//            controller: 'userListcontroller',
//            currentpage: 'deleteuser'
//        })
//        .otherwise({
//            redirectTo: '/viewuser'
//        });

//}])
app.run(function ($rootScope) {
    $rootScope.AppName = "Issue Analyzer";
})
