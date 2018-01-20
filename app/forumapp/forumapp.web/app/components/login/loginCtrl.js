app.controller(
    'loginCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window','$state',
function ($scope, $http, $rootScope, $log, $location, $window, $state) {

    $scope.Login = function () {
        $state.go('main');
    };

    $scope.createNewUser = function () {
        $('#mdl_newuser').modal('show');
    };

}]);