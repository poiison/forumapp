app.controller(
    'topicsCtrl', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state',
function ($scope, $http, $rootScope, $log, $location, $window, $state) {

    $scope.lsTopics = [];
    $scope.topic = { id: 0, name: '', text: 0, author: '', date: '' }

    $scope.goToTopics = function () {
        $state.go('post');
    };
    
    $scope.openModalNewTopic = function () {
        $scope.topic = { id: 0, name: '', text: 0, author: '', date: '' };

        $('#mdl_newtopic').modal('show');
    };
}]);