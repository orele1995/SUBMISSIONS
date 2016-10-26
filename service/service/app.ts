const app = angular.module("app", []);

app.controller("mainCtrl", MainCtrl);
app.service("getMovies", MovieService);
app.component("movie", {
    templateUrl: "/movie.html",
    bindings: {
        model: "<"
        //onRemove: "&"
    },
    controller: MovieCtrl
});