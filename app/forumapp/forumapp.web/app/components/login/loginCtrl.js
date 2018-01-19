app.controller(
    'loginCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window','$state',
function ($scope, $http, $rootScope, $log, $location, $window, $state) {

    $scope.login = function () {
        $state.go('main');
    }
}]);