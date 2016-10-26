var MainCtrl = (function () {
    function MainCtrl(getMovies) {
        var _this = this;
        getMovies.getMoviesByName("star").then(function (r) { return _this.Movies = r; });
    }
    return MainCtrl;
}());
