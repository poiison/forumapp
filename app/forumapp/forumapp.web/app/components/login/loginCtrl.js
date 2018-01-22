app.controller(
    'loginCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state', 'accountService', '$cookieStore',
        function ($scope, $http, $rootScope, $log, $location, $window, $state, accountService, $cookieStore) {

            $scope.user = { id: 0, Username: '', Password: '' }

            $scope.Login = function () {

                accountService.login($scope.user).then(
                    function (result) {
                        $cookieStore.put('user', result);
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