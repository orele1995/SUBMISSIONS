var PriceComparison;
(function (PriceComparison) {
    var Prices;
    (function (Prices) {
        var ComparisonResultCrtl = (function () {
            function ComparisonResultCrtl(pricesService) {
                var _this = this;
                this.pricesService = pricesService;
                this.pricesService.getPricesResult()
                    .then(function (data) {
                    _this.results = data;
                    _this.minSum = _this.results[0].sum;
                    for (var i = 1; i < _this.results.length; i++) {
                        if (_this.results[i].sum < _this.minSum) {
                            _this.minSum = _this.results[i].sum;
                        }
                    }
                });
            }
            ComparisonResultCrtl.prototype.classOfPrice = function (item) {
                var minPrice;
                var maxPrice;
                // initialize min and max prices
                for (var k = 0; k < this.results[0].cart.length; k++) {
                    if (this.results[0].cart[k].itemName === item.itemName) {
                        minPrice = this.results[0].cart[k].itemPrice;
                        maxPrice = this.results[0].cart[k].itemPrice;
                    }
                }
                //finding min and max prices
                for (var i = 1; i < this.results.length; i++) {
                    for (var j = 0; j < this.results[i].cart.length; j++) {
                        if (this.results[i].cart[j].itemName === item.itemName) {
                            var price = this.results[i].cart[j].itemPrice;
                            if (price < minPrice) {
                                minPrice = price;
                            }
                            if (price > maxPrice) {
                                maxPrice = price;
                            }
                        }
                    }
                }
                switch (item.itemPrice) {
                    case minPrice:
                        return "min-price";
                    case maxPrice:
                        return "max-price";
                    default:
                        return "";
                }
            };
            return ComparisonResultCrtl;
        }());
        pricesModule.component("comparisonResult", {
            templateUrl: "prices/templates/comparison-result.html",
            controller: ComparisonResultCrtl
        });
    })(Prices = PriceComparison.Prices || (PriceComparison.Prices = {}));
})(PriceComparison || (PriceComparison = {}));
