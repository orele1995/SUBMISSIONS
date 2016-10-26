namespace PriceComparison.Prices {

    class StoreSelection {
        num: number;
        selectedChain: IChain;
        selectedStore: IStore;
        chains: IChain[];
        stores: IStore[] = [];
        onChangeStore: Function;
        
        constructor(private pricesService: IPricesService) {
            pricesService.getChanis().then(data => this.chains = data);
        }

        changeChain() {
            if (this.selectedChain) {
                this.stores = this.selectedChain.stores;
            } else {
                this.stores = [];
            }
        }

        changeStore() {
            if (this.selectedStore) {
                this.onChangeStore({
                    $num: this.num,
                    $store: this.selectedStore
                });
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
            onChangeStore: "&"
        }
    });
}