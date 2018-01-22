app.controller(
    'mainCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state', 'categoryService', '$filter','$cookieStore',
        function ($scope, $http, $rootScope, $log, $location, $window, $state, categoryService, $filter, $cookieStore) {

            $scope.lsCategories = [];
            $scope.category = { id: 0, name: '', IdUserCreated: 0, totaltopics: 0 }
            $scope.user = $cookieStore.get('user');

            $scope.goToTopics = function (id) {
                $state.go('topics', {cid: id});
            };

            $scope.openModalNewCategory = function () {
                $scope.category = { id: 0, name: '', IdUserCreated: $scope.user.Id, totaltopics: 0 };

                $('#mdl_newcategory').modal('show');
            };

            $scope.loadCategires = function () {
                categoryService.getCategories().then(
                    function (result) {
                        $scope.lsCategories = result;
                    })
                    .catch(function (httpError) {
                        console.log(httpError);
                        console.log(parseErrors(httpError));
                    });
            };

            $scope.createNewCategory = function () {
                var cat = $scope.category;

                categoryService.addCategory(cat).then(
                    function (result) {
                        $scope.lsCategories.push(result);

                        $('#mdl_newcategory').modal('hide');
                    })
                    .catch(function (httpError) {
                        console.log(httpError);
                        console.log(parseErrors(httpError));
                    });
            };

            $scope.deleteCategory = function (id) {

                var cat = $filter('filter')($scope.lsCategories, { 'Id': id })[0];

                if (cat.TotalTopics == 0) {
                    categoryService.deleteCategory(id).then(
                        function (result) {
                            $scope.loadCategires();
                        })
                        .catch(function (httpError) {
                            console.log(httpError.data.Message);
                        });
                } else {
                    alert("You can not delete while there are posts in this categories.");
                }
            };

            $scope.loadCategires();
        }]);