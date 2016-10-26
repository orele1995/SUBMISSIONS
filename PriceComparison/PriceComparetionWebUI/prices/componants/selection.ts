namespace PriceComparison.Prices {
    
    class SelectionCrtlOld {

        items: IItem[];
        shoppingCart: IItem[] = [];
        toRemove: IItem[] = [];
        toAdd: IItem[] = [];
        chains: IChain[];
        stores: IStore[] = [];
        selectedChain: IChain;
        selectedStore: IStore;
        constructor(private pricesService: IPricesService,private $rootScope) {
            pricesService.getItems().then(data => this.items = data);
            pricesService.getChanis().then(data => this.chains = data);
            //$timeout(() => {
            //    var a = $ as any;

            //    a('.selectpicker').selectpicker();
            //});
        }

        addToCart() {
            let i: number;
            for (i = 0; i < this.toAdd.length; i++) {
                this.shoppingCart.push(this.toAdd[i]);
            }
            this.toAdd = [];
            this.$rootScope.$broadcast('addToCartEvent');
            }
        removeFromCart() {
            let i: number;
            for (i = 0; i < this.toRemove.length; i++) {
                const index = this.shoppingCart.indexOf(this.toRemove[i]); 
                this.shoppingCart.splice(index, 1);
            }
            this.toRemove = [];
            }

        selectFromCart(item: IItem) {
            this.toRemove.push(item);
        }
        unselectFromCart(item: IItem) {
            let index = this.toRemove.indexOf(item);
            this.toRemove.splice(index, 1);
        }
        unselectFromAll(item: IItem) {
            let index = this.toAdd.indexOf(item);
            this.toAdd.splice(index, 1);
        }
        selectFromAll(item: IItem) {
            this.toAdd.push(item);
        }

        changeChain() {
            if (this.selectedChain) {
                this.stores = this.selectedChain.stores;
                this.pricesService.getItemsOfChain(this.selectedChain.chainID).then((data) => this.items = data);
                } else {
                this.stores = [];
            }
        }

        changeStore() {
            if (this.selectedStore) {
              //  this.pricesService.
            }
        }

        
    }

    class SelectionCrtl {
        stores: IStore[] = [];
        emptyStore: IStore;
        numOfItems: number = 0;
        numOfStores: number = 1;
        shoppingCart: IItem[] = [];
        selectedItem: IItem;
        items: IItem[] = [];

        constructor(private pricesService: IPricesService) {
            this.stores.push({
                storeId: this.numOfStores++,
                address: "",
                chainId: 1,
                city: "",
                prices: [],
                storeCode: 1
            });
            this.stores.push({
                storeId: this.numOfStores++,
                address: "",
                chainId: 1,
                city: "",
                prices: [],
                storeCode: 1
            });
            pricesService.getItems().then(data => this.items = data);

            
        }
        public addStore() {
            this.stores.push({
                storeId: this.numOfStores++,
                address: "",
                chainId: 1,
                city: "",
                prices: [],
                storeCode: 1
            });
        }

        public changeStore(index:number, newStore:IStore) {
            this.stores[index-1] = newStore;
        }
    }
        pricesModule.component("selection", {
    templateUrl: "prices/templates/selection-tmplate.html",
    controller: SelectionCrtl
    });

   
}
