app.controller(
    'topicsCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state', '$stateParams', 'categoryService', 'topicService',
        function ($scope, $http, $rootScope, $log, $location, $window, $state, $stateParams, categoryService, topicService) {

            $scope.lsTopics = [];
            $scope.topic = { Id: 0, Title: '', Comment: '', Author: '', Reply: 0, IdCategory: $stateParams.cid, IdUser: 0 }
            $scope.category = { id: 0, name: '', totaltopics: 0 }

            $scope.goToTopics = function () {
                $state.go('post');
            };

            $scope.openModalNewTopic = function () {
                $scope.topic = { Id: 0, Title: '', Comment: '', Author: '', Reply: 0, IdCategory: $stateParams.cid, IdUser: 0}

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

            $scope.createNewTopic = function () {
                var topic = $scope.topic;

                topicService.addTopic(topic).then(
                    function (result) {
                        $scope.lsTopics.push(result);

                        $('#mdl_newtopic').modal('hide');
                    })
                    .catch(function (httpError) {
                        console.log(httpError);
                        console.log(parseErrors(httpError));
                    });
            };
            
            $scope.loadCategory();
            $scope.loadTopics();
        }]);