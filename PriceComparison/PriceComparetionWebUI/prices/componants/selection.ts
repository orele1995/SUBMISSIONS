namespace PriceComparison.Prices {
    import Item = PriceComparison.Prices.IItem;

    class SelectionCrtl {
        stores: IStoreModel[] = [];
        emptyStore: IStore;
        numOfItems: number = 0;
        numOfStores: number = 1;
        shoppingCart: IItem[] = [];
        selectedItem: IItem;
        items: IItem[] = [];
        chains: IChain[];

        constructor(private pricesService: IPricesService, $scope: ng.IScope, private loadingService:ILoadingService) {
            this.stores.push({
                id: this.numOfStores++,
                store: {
                    storeID: 1,
                    address: "",
                    chainID: 1,
                    city: "",
                    prices: [],
                    storeCode: 1
                }
            });
            this.stores.push({
                id: this.numOfStores++,
                store: {
                    storeID: 1,
                    address: "",
                    chainID: 1,
                    city: "",
                    prices: [],
                    storeCode: 1
                }
            });
            this.loadingService.loading(pricesService.getChanis())
                .then(data => {
                    this.chains = data;
                });
        }
        public onFirstStoreChanged(newValue: IStoreModel) {
            if (newValue !== null && newValue!== undefined && newValue.id===1) {
                if (newValue.store.chainID !== 1) {
                    this.loadingService.loading(this.pricesService.getItemsOfStore(newValue.store)).then((data) => {
                        this.items = data;
                    });
                }
            }
        }

        public addStore() {
            this.stores.push({
                id: this.numOfStores++,
                store: {
                    storeID: 1,
                    address: "",
                    chainID: 1,
                    city: "",
                    prices: [],
                    storeCode: 1
                }
            });
        }

        public onSelect($item, $model, $label) {
            for (var i = 0; i < this.shoppingCart.length; i++) {
                if (this.shoppingCart[i].itemID === $item.itemID) {
                    this.items[this.items.indexOf($item)].numOfItems = 0;
                    return;
                }
            }
            this.shoppingCart.push({
                itemID: $item.itemID,
                itemName: $item.itemName,
                manufacturerName: $item.manufacturerName,
                numOfItems: $item.numOfItems,
                quantity: $item.quantity
            });
            this.items[this.items.indexOf($item)].numOfItems = 1;
        }

        public onRemoveClick(item: Item) {
            this.shoppingCart.splice(this.shoppingCart.indexOf(item), 1);
        }

        public onCompareClick() {
            var stores: IStore[] = [];
            for (var i = 0; i < this.stores.length; i++) {
                stores.push(this.stores[i].store);
            }
            this.pricesService.setPricesResult(this.shoppingCart, stores);
        }

        public storesSelected() {
            for (var i = 0; i < this.stores.length; i++) {
                if (this.stores[i].store.chainID===1) return false;
            }
            return true;
        }
    }

    pricesModule.component("selection", {
    templateUrl: "prices/templates/selection-tmplate.html",
    controller: SelectionCrtl
    });

   
}
