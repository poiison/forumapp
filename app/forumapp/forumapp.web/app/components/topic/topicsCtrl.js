app.controller(
    'topicsCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state', '$stateParams', 'categoryService', 'topicService',
        function ($scope, $http, $rootScope, $log, $location, $window, $state, $stateParams, categoryService, topicService) {

            $scope.lsTopics = [];
            $scope.topic = { id: 0, name: '', text: 0, author: '', date: '' }
            $scope.category = { id: 0, name: '', totaltopics: 0 }

            $scope.goToTopics = function () {
                $state.go('post');
            };

            $scope.openModalNewTopic = function () {
                $scope.topic = { id: 0, name: '', text: 0, author: '', date: '' };

                $('#mdl_newtopic').modal('show');
            };

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
            
            $scope.loadCategory();
            $scope.loadTopics();
        }]);