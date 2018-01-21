
app.service("categoryService", ['$http', '$window', '$timeout', function ($http, $window, $timeout) {

    var urlBase = uriAPI + "category/";

    this.getCategories = function () {
        return $http.get(urlBase + "categories").then(function (response) { return response.data; });
    };

    this.getCategory = function (id) {
        return $http.get(urlBase + "category?id=" + id).then(function (response) { return response.data; });
    };

    this.deleteCategory = function (id) {
        return $http.delete(urlBase + "delete?id=" + id).then(function (response) { return response.data; });
    };

    this.addCategory = function (model) {
        return $http.post(urlBase + "add", model).then(function (response) { return response.data; });
    };

}]);