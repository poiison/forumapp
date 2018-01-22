app.controller(
    'loginCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state', 'accountService', '$cookieStore', 'Notification',
        function ($scope, $http, $rootScope, $log, $location, $window, $state, accountService, $cookieStore, Notification) {

            $scope.user = { id: 0, Username: '', Password: '' }

            $scope.Login = function () {

                accountService.login($scope.user).then(
                    function (result) {
                        $cookieStore.put('user', result);
                        $state.go('main');
                    })
                    .catch(function (httpError) {
                        Notification.error({ message: 'User or password incorrect.' });
                        console.log(httpError);

                        console.log(parseErrors(httpError));
                    });
            };

            $scope.createNewUser = function () {
                $('#mdl_newuser').modal('show');
            };

        }]);