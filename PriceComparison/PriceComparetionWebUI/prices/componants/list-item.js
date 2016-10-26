var PriceComparison;
(function (PriceComparison) {
    var Prices;
    (function (Prices) {
        var ListItemCrtl = (function () {
            function ListItemCrtl($rootScope) {
                var _this = this;
                this.$rootScope = $rootScope;
                $rootScope.$on('addToCartEvent', function () {
                    _this.isChecked = false;
                });
            }
            ListItemCrtl.prototype.onCheckboxClick = function (isChacked) {
                if (isChacked) {
                    this.onSelect();
                }
                else {
                    this.onUnselect();
                }
            };
            return ListItemCrtl;
        }());
        pricesModule.component("listItem", {
            templateUrl: "prices/templates/list-item.html",
            bindings: {
                item: "=",
                onSelect: "&",
                onUnselect: "&"
            },
            controller: ListItemCrtl
        });
    })(Prices = PriceComparison.Prices || (PriceComparison.Prices = {}));
})(PriceComparison || (PriceComparison = {}));
//# sourceMappingURL=list-item.js.map