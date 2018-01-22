app.controller(
    'loginCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state', 'accountService',
        function ($scope, $http, $rootScope, $log, $location, $window, $state, accountService) {

            $scope.user = { id: 0, Username: '', Password: '' }

            $scope.Login = function () {

                accountService.login($scope.user).then(
                    function (result) {
                        $state.go('main');
                    })
                    .catch(function (httpError) {
                        console.log(parseErrors(httpError));
                    });
            };

            $scope.createNewUser = function () {
                $('#mdl_newuser').modal('show');
            };

        }]);