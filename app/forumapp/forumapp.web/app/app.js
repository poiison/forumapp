var app = angular.module('app', ['ui.router']);

app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('home', {
            url: "/home",
            templateUrl: '/app/components/login/login.html',
            controller: 'loginCtrl'
        })
        .state('main', {
            url: "/main",
            templateUrl: '/app/components/main/main.html',
            controller: 'mainCtrl'
        })
        .state('threads', {
            url: "/threads",
            templateUrl: '/app/components/threads/threads.html',
            controller: 'threadsCtrl'
        });

});