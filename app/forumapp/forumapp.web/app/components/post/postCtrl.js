app.controller(
    'postCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state', '$stateParams', 'categoryService', 'topicService', '$cookieStore',
        function ($scope, $http, $rootScope, $log, $location, $window, $state, $stateParams, categoryService, topicService, $cookieStore) {

            $scope.lsPots = [];
            $scope.topic = { Id: 0, Title: '', Comment: '', Author: '', Reply: 0, IdCategory: $stateParams.cid, IdUser: 0 }
            $scope.category = { id: 0, name: '', totaltopics: 0 }
            $scope.user = $cookieStore.get('user');

            $scope.loadCategory = function () {
                categoryService.getCategory($stateParams.cid).then(
                    function (result) {
                        $scope.category = result;
                    })
                    .catch(function (httpError) {
                        console.log(httpError.data.Message);
                    });
            };

            $scope.loadTopics = function () {
                topicService.getTopics($stateParams.cid).then(
                    function (result) {
                        $scope.lsTopics = result;
                    })
                    .catch(function (httpError) {
                        console.log(httpError.data.Message);
                    });
            };

        }]);