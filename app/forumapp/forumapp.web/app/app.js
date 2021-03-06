﻿var app = angular.module('app', ['ui.router', 'ngCookies', 'ui-notification']);

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
        .state('topics', {
            url: "/topics/:cid",
            templateUrl: '/app/components/topic/topics.html',
            controller: 'topicsCtrl',
            params: {
                cid: null
            }
        })
        .state('post', {
            url: "/posts/:cid/:pid",
            templateUrl: '/app/components/post/post.html',
            controller: 'postCtrl',
            params: {
                cid: null,
                pid: null
            }
        });

});