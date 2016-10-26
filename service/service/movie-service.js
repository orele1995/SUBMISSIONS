var MovieService = (function () {
    function MovieService($http) {
        this.$http = $http;
    }
    MovieService.prototype.getMoviesByName = function (name) {
        return this.$http.get("http://www.omdbapi.com/?s=$" + name + "&type=movie")
            .then(function (result) { return result.data.Search; });
    };
    return MovieService;
}());
