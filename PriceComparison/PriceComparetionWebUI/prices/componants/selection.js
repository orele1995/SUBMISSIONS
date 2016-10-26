var PriceComparison;
(function (PriceComparison) {
    var Prices;
    (function (Prices) {
        var SelectionCrtlOld = (function () {
            function SelectionCrtlOld(pricesService, $rootScope) {
                var _this = this;
                this.pricesService = pricesService;
                this.$rootScope = $rootScope;
                this.shoppingCart = [];
                this.toRemove = [];
                this.toAdd = [];
                this.stores = [];
                pricesService.getItems().then(function (data) { return _this.items = data; });
                pricesService.getChanis().then(function (data) { return _this.chains = data; });
                //$timeout(() => {
                //    var a = $ as any;
                //    a('.selectpicker').selectpicker();
                //});
            }
            SelectionCrtlOld.prototype.addToCart = function () {
                var i;
                for (i = 0; i < this.toAdd.length; i++) {
                    this.shoppingCart.push(this.toAdd[i]);
                }
                this.toAdd = [];
                this.$rootScope.$broadcast('addToCartEvent');
            };
            SelectionCrtlOld.prototype.removeFromCart = function () {
                var i;
                for (i = 0; i < this.toRemove.length; i++) {
                    var index = this.shoppingCart.indexOf(this.toRemove[i]);
                    this.shoppingCart.splice(index, 1);
                }
                this.toRemove = [];
            };
            SelectionCrtlOld.prototype.selectFromCart = function (item) {
                this.toRemove.push(item);
            };
            SelectionCrtlOld.prototype.unselectFromCart = function (item) {
                var index = this.toRemove.indexOf(item);
                this.toRemove.splice(index, 1);
            };
            SelectionCrtlOld.prototype.unselectFromAll = function (item) {
                var index = this.toAdd.indexOf(item);
                this.toAdd.splice(index, 1);
            };
            SelectionCrtlOld.prototype.selectFromAll = function (item) {
                this.toAdd.push(item);
            };
            SelectionCrtlOld.prototype.changeChain = function () {
                var _this = this;
                if (this.selectedChain) {
                    this.stores = this.selectedChain.stores;
                    this.pricesService.getItemsOfChain(this.selectedChain.chainID).then(function (data) { return _this.items = data; });
                }
                else {
                    this.stores = [];
                }
            };
            SelectionCrtlOld.prototype.changeStore = function () {
                if (this.selectedStore) {
                }
            };
            return SelectionCrtlOld;
        }());
        var SelectionCrtl = (function () {
            function SelectionCrtl(pricesService) {
                var _this = this;
                this.pricesService = pricesService;
                this.stores = [];
                this.numOfItems = 0;
                this.numOfStores = 1;
                this.shoppingCart = [];
                this.items = [];
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
                pricesService.getItems().then(function (data) { return _this.items = data; });
            }
            SelectionCrtl.prototype.addStore = function () {
                this.stores.push({
                    storeId: this.numOfStores++,
                    address: "",
                    chainId: 1,
                    city: "",
                    prices: [],
                    storeCode: 1
                });
            };
            SelectionCrtl.prototype.changeStore = function (index, newStore) {
                this.stores[index - 1] = newStore;
            };
            return SelectionCrtl;
        }());
        pricesModule.component("selection", {
            templateUrl: "prices/templates/selection-tmplate.html",
            controller: SelectionCrtl
        });
    })(Prices = PriceComparison.Prices || (PriceComparison.Prices = {}));
})(PriceComparison || (PriceComparison = {}));
//# sourceMappingURL=selection.js.map