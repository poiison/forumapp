app.controller(
    'postCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state', '$stateParams', 'categoryService', 'topicService', '$cookieStore', 'postService', '$filter',
        function ($scope, $http, $rootScope, $log, $location, $window, $state, $stateParams, categoryService, topicService, $cookieStore, postService, $filter) {

            $scope.user = $cookieStore.get('user');

            $scope.lsPots = [];
            $scope.topic = { Id: 0, Title: '', Comment: '', Author: '', Reply: 0, IdCategory: $stateParams.cid, IdUser: 0 }
            $scope.newpost = { Id: 0, Title: '', Comment: '', Author: '', Reply: $stateParams.pid, IdCategory: $stateParams.cid, IdUser: $scope.user.Id }

            $scope.category = { id: 0, name: '', totaltopics: 0 }


            $scope.loadCategory = function () {
                categoryService.getCategory($stateParams.cid).then(
                    function (result) {
                        $scope.category = result;
                    })
                    .catch(function (httpError) {
                        console.log(httpError.data.Message);
                    });
            };

            $scope.loadPosts = function () {
                postService.getPosts($stateParams.pid).then(
                    function (result) {
                        $scope.lsPots = result;
                    })
                    .catch(function (httpError) {
                        console.log(httpError.data.Message);
                    });
            };

            $scope.editPost = function (id) {

                var p = $filter('filter')($scope.lsPots, { 'Id': id })[0];

                $scope.newpost = { Id: p.Id, Title: p.Title, Comment: p.Comment, Author: p.Author, Reply: p.Reply, IdCategory: $stateParams.cid, IdUser: p.IdUser }
            }

            $scope.createNewPost = function (id) {
                var post = $scope.newpost;

                post.Author = $scope.user.Username;
                post.User = $scope.user;

                postService.addPost(post).then(
                    function (result) {
                        $scope.loadPosts();
                        $scope.newpost = { Id: 0, Title: '', Comment: '', Author: '', Reply: $stateParams.pid, IdCategory: $stateParams.cid, IdUser: $scope.user.Id }
                    })
                    .catch(function (httpError) {
                        console.log(httpError);
                        console.log(parseErrors(httpError));
                    });

            };

            $scope.deletePost = function (id) {
                postService.deletePost(id).then(
                    function (result) {
                        $scope.loadPosts();
                    })
                    .catch(function (httpError) {
                        console.log(httpError.data.Message);
                    });
            };

            $scope.loadPosts();
            $scope.loadCategory();
        }]);