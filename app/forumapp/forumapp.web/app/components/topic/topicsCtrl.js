app.controller(
    'topicsCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state', '$stateParams', 'categoryService', 'topicService', '$cookieStore',
        function ($scope, $http, $rootScope, $log, $location, $window, $state, $stateParams, categoryService, topicService, $cookieStore) {

            $scope.lsTopics = [];
            $scope.topic = { Id: 0, Title: '', Comment: '', Author: '', Reply: 0, IdCategory: $stateParams.cid, IdUser: 0 }
            $scope.category = { id: 0, name: '', totaltopics: 0 }
            $scope.user = $cookieStore.get('user');

            $scope.goToTopics = function (id) {
                $state.go('post', { cid: $stateParams.cid, pid: id });
            };

            $scope.openModalNewTopic = function () {
                $scope.topic = { Id: 0, Title: '', Comment: '', Author: '', Reply: 0, IdCategory: $stateParams.cid, IdUser: $scope.user.Id }

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
                topic.Author = $scope.user.Username;
                topic.User = $scope.user;

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

            $scope.deleteTopic = function (id) {
                
                topicService.deleteTopic(id).then(
                    function (result) {
                        $scope.loadTopics();
                    })
                    .catch(function (httpError) {
                        console.log(httpError.data.Message);
                    });

            };

            $scope.logout = function () {
                $cookieStore.remove('user');
                $state.go('home');
            };

            $scope.loadCategory();
            $scope.loadTopics();
        }]);