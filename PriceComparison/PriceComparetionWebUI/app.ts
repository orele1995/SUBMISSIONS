var app = angular.module("app", ["ngRoute","prices", "ui.bootstrap"]);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            template: "<selection></selection>"
        })
        .when("/selection", {
            template: "<selection></selection>"

        })
        .when("/results", {
            template: "<comparison-result></comparison-result>"
        });
});