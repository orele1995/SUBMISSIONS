namespace PriceComparison.Prices {

    class StoreSelection {
        num: number;
        selectedChain: IChain;
        selectedStore: IStore;
        chains: IChain[];
        stores: IStore[] = [];
        selected:IStore;

 

        constructor(private pricesService: IPricesService) {


            pricesService.getChanis()
                .then(data => this.chains = data);
        }

        changeChain() {
            if (this.selectedChain) {
                this.stores = this.selectedChain.stores;
            }
            else {
                this.stores = [];
            }
        }

        changeStore(selected:IStore) {
            if (this.selectedStore) {
                this.selectedStore = this.selected;
               }
        }
    }


    pricesModule.component("storeSelection",
    {
        templateUrl: "prices/templates/store-selection.html",
        controller: StoreSelection,
        bindings:
        {
            num: "=",
            selectedStore: "="
        }
    });
}