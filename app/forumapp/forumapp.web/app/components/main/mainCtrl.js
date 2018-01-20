app.controller(
    'mainCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state',
function ($scope, $http, $rootScope, $log, $location, $window, $state) {

    $scope.lsCategories = [];
    $scope.category = { id: 0, name: '', totaltopics: 0 }

    $scope.goToTopics = function () {
        $state.go('topics');
    };

    $scope.openModalNewCategory = function () {
        $scope.category = { id: 0, name: '', totaltopics: 0 };

        $('#mdl_newcategory').modal('show');
    };
    
    $scope.createNewCategory = function () {
        var cat = $scope.category;
        $scope.lsCategories.push(cat);

        $('#mdl_newcategory').modal('hide');
    };

    $scope.deleteCategory = function () {

    };
}]);