var PriceComparison;
(function (PriceComparison) {
    var Prices;
    (function (Prices) {
        var SelectionCrtl = (function () {
            function SelectionCrtl(pricesService, $scope) {
                var _this = this;
                this.pricesService = pricesService;
                this.stores = [];
                this.numOfItems = 0;
                this.numOfStores = 1;
                this.shoppingCart = [];
                this.items = [];
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
                $scope.$watch(function () { return _this.stores[0]; }, function (newValue, oldValue) {
                    if (newValue.store !== null) {
                        if (newValue.store.prices.length !== 0) {
                            pricesService.getItemsOfStore(newValue.store).then(function (data) { return _this.items = data; });
                        }
                    }
                }, true);
            }
            SelectionCrtl.prototype.addStore = function () {
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
            };
            SelectionCrtl.prototype.onSelect = function ($item, $model, $label) {
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
            };
            SelectionCrtl.prototype.onRemoveClick = function (item) {
                this.shoppingCart.splice(this.shoppingCart.indexOf(item), 1);
            };
            SelectionCrtl.prototype.onCompareClick = function () {
                var stores = [];
                for (var i = 0; i < this.stores.length; i++) {
                    stores.push(this.stores[i].store);
                }
                this.pricesService.setPricesResult(this.shoppingCart, stores);
            };
            SelectionCrtl.prototype.storesSelected = function () {
                for (var i = 0; i < this.stores.length; i++) {
                    if (this.stores[i].store.prices === [])
                        return false;
                }
                return true;
            };
            return SelectionCrtl;
        }());
        pricesModule.component("selection", {
            templateUrl: "prices/templates/selection-tmplate.html",
            controller: SelectionCrtl
        });
    })(Prices = PriceComparison.Prices || (PriceComparison.Prices = {}));
})(PriceComparison || (PriceComparison = {}));
