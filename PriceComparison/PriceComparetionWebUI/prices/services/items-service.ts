namespace PriceComparison.Prices {

    export interface IPricesService {
        getItems(): ng.IPromise<PriceComparison.Prices.IItem[]>;
        getChanis(): ng.IPromise<IChain[]>;  
        getItemsOfChain(chainId: number): ng.IPromise<IItem[]>;    
     //   getPricesResult(items: IItem[]): ng.IPromise<IDisplayItem[]>;    

    }


    export class PricesService implements IPricesService {

        constructor(private $http: ng.IHttpService) {

        }

        public getItems(): ng.IPromise<IItem[]> {
            return this.$http.get("api/priceComparetion/GetItems")
                .then(data => {
                    return data.data;
                });
        }

        public getChanis(): ng.IPromise<IChain[]> {
            return this.$http.get("api/priceComparetion/GetChains")
                .then(data => {
                    return data.data;
                });
        }

        public getItemsOfChain(_chainId): ng.IPromise<IItem[]> {
            return this.$http.get("api/priceComparetion/GetItemsOfChain",
                {
                    params: {
                        chainId: _chainId
                    }
                })
                .then(data => {
                    return data.data;
                });
        }

        //getPricesResult(items: IItem[]): ng.IPromise<IDisplayItem[]> {
          
            
        //}
    }

    pricesModule.service("pricesService", PricesService);

}

