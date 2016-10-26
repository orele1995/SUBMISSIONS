var ProductsService = (function () {
    function ProductsService() {
    }
    //public getMoviesByTitle(title: string): angular.IPromise<IMovie[]> {
    //    return this.$http.get<IImdbSearchResult>(`http://www.omdbapi.com/?s=${title}&type=movie`).
    //        then(data => {
    //            return data.data.Search;
    //        });
    //}
    ProductsService.prototype.getProducts = function (title) {
        throw new Error("Not implemented");
    };
    return ProductsService;
}());
