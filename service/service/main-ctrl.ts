interface IMovie {
    Title: string;
    Poster: string;
}
interface IImdbSearchResult {
    Search: IMovie[];
}

class MainCtrl {

  public Movies: IMovie[];
     
    constructor(getMovies: IMovieService) {
        getMovies.getMoviesByName("star").then(r => this.Movies = r);
    }

}