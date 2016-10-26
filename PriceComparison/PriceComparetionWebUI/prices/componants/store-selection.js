var PriceComparison;
(function (PriceComparison) {
    var Prices;
    (function (Prices) {
        var StoreSelection = (function () {
            function StoreSelection(pricesService) {
                var _this = this;
                this.pricesService = pricesService;
                this.stores = [];
                pricesService.getChanis().then(function (data) { return _this.chains = data; });
            }
            StoreSelection.prototype.changeChain = function () {
                if (this.selectedChain) {
                    this.stores = this.selectedChain.stores;
                }
                else {
                    this.stores = [];
                }
            };
            StoreSelection.prototype.changeStore = function () {
                if (this.selectedStore) {
                    this.onChangeStore({
                        $num: this.num,
                        $store: this.selectedStore
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
                onChangeStore: "&"
            }
        });
    })(Prices = PriceComparison.Prices || (PriceComparison.Prices = {}));
})(PriceComparison || (PriceComparison = {}));
//# sourceMappingURL=store-selection.js.map