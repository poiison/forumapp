app.controller(
    'mainCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state',
function ($scope, $http, $rootScope, $log, $location, $window, $state) {

    $scope.moveToThread = function () {
        $state.go('topics');
    };
    
}]);