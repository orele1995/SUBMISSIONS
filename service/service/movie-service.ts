
interface IMovieService {

    getMoviesByName(name: string): ng.IPromise<IMovie[]>;
}

class MovieService implements IMovieService {
    constructor(private $http: ng.IHttpService) {
    }

    getMoviesByName(name: string): angular.IPromise<IMovie[]> {
       return this.$http.get<IImdbSearchResult>("http://www.omdbapi.com/?s=$" + name + "&type=movie")
            .then(result => { return result.data.Search; });
    }
}