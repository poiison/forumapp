
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


app.service("accountService", ['$http', '$window', '$timeout', function ($http, $window, $timeout) {
    var urlBase = uriAPI + "account/";

    this.login = function (model) {
        return $http.post(urlBase + "login", model).then(function (response) { return response.data; });
    };
}]);

app.service("topicService", ['$http', '$window', '$timeout', function ($http, $window, $timeout) {
    var urlBase = uriAPI + "topic/";

    this.getTopics = function (id) {
        return $http.get(urlBase + "topics?category=" + id).then(function (response) { return response.data; });
    };

    this.addTopic = function (model) {
        return $http.post(urlBase + "add", model).then(function (response) { return response.data; });
    };
}]);
