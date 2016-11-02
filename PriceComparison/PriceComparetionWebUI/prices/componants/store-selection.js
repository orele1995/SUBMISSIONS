var PriceComparison;
(function (PriceComparison) {
    var Prices;
    (function (Prices) {
        var StoreSelection = (function () {
            function StoreSelection(pricesService, loadingService) {
                this.pricesService = pricesService;
                this.loadingService = loadingService;
                this.stores = [];
            }
            StoreSelection.prototype.changeChain = function () {
                if (this.selectedChain) {
                    this.stores = this.selectedChain.stores;
                }
                else {
                    this.stores = [];
                }
            };
            StoreSelection.prototype.changeStore = function (selected) {
                if (this.selected) {
                    this.selectedStore = this.selected;
                    this.onChangeStore({
                        $storeModel: {
                            id: this.num,
                            store: this.selectedStore
                        }
                    });
                }
            };
            return StoreSelection;
        }());
        pricesModule.component("storeSelection", {
            templateUrl: "prices/templates/store-selection.html",
            controller: StoreSelection,
            bindings: {
                num: "=",
                selectedStore: "=",
                onChangeStore: "&",
                chains: "="
            }
        });
    })(Prices = PriceComparison.Prices || (PriceComparison.Prices = {}));
})(PriceComparison || (PriceComparison = {}));
//# sourceMappingURL=store-selection.js.map