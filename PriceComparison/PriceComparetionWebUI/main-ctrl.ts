namespace PriceComparison {

    class MainCtrl {
        loading: boolean=false ;

        constructor(private loadingService: ILoadingService) {
            loadingService.register("mainCtrl",this.onLoadingChanged);          
        }

        onLoadingChanged = (newValue: boolean)=> {
            this.loading = newValue;
        }
    }

    app.controller("mainCtrl", MainCtrl);
}
