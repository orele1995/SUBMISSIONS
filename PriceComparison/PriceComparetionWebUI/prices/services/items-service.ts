namespace PriceComparison.Prices {

    export interface IPricesService {
        getItems(): ng.IPromise<PriceComparison.Prices.IItem[]>;
        getChanis(): ng.IPromise<IChain[]>;  
        getItemsOfChain(chainId: number): ng.IPromise<IItem[]>;  
        setPricesResult(_items: IItem[], _stores: IStore[]);    
        getPricesResult(): ng.IPromise<ICompareResult[]>;
        getItemsOfStore(store:IStore): ng.IPromise<IItem[]>;
    }

    export class PricesService implements IPricesService {

        results: ICompareResult[];
        items: IItem[];
        stores: IStore[];

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
        setPricesResult(items: IItem[], stores: IStore[]) {
            this.items = items;
            this.stores = stores;
        }
        getResults(_items: IItem[], _stores: IStore[]): ng.IPromise<ICompareResult[]> {
            return this.$http.post("api/priceComparetion/getPricesResult",
                {
                        cart: _items,
                        stores: _stores
                    
                })
                .then(data => {
                    return data.data;
                });
        }
        getPricesResult(): ng.IPromise<ICompareResult[]> {
            return this.getResults(this.items, this.stores)
                .then(data => {
                    this.results = data;
                    return this.results;
                });
        }
        getItemsOfStore(store: IStore): ng.IPromise<IItem[]> {
            return this.$http.get("api/priceComparetion/GetItemsOfStore", {
                params: {
                    storeId: store.storeID
                }
            })
                .then(data => {
                    return data.data;
                });
        }
    }

    pricesModule.service("pricesService", PricesService);

}

