﻿app.controller(
    'topicsCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state',
function ($scope, $http, $rootScope, $log, $location, $window, $state) {

    $scope.moveToThread = function () {
        $state.go('post');
    };
}]);