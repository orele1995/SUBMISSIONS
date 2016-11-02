namespace PriceComparison.Prices {

    class StoreSelection {
        num: number;
        selectedChain: IChain;
        selectedStore: IStore;
        chains: IChain[];
        stores: IStore[] = [];
        selected: IStore;
        onChangeStore: Function;

        constructor(private pricesService: IPricesService, private loadingService: ILoadingService) {
           
        }

        changeChain() {
            if (this.selectedChain) {
                this.stores = this.selectedChain.stores;
            } else {
                this.stores = [];
            }
        }

        changeStore(selected: IStore) {
            if (this.selected) {
                this.selectedStore = this.selected;
                this.onChangeStore({
                    $storeModel: {
                        id: this.num,
                        store: this.selectedStore
                    }

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
            selectedStore: "=",
            onChangeStore: "&",
            chains:"="
        }
    });
}