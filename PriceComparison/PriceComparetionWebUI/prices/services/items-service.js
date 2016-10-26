var PriceComparison;
(function (PriceComparison) {
    var Prices;
    (function (Prices) {
        var PricesService = (function () {
            function PricesService($http) {
                this.$http = $http;
            }
            PricesService.prototype.getItems = function () {
                return this.$http.get("api/priceComparetion/GetItems")
                    .then(function (data) {
                    return data.data;
                });
            };
            PricesService.prototype.getChanis = function () {
                return this.$http.get("api/priceComparetion/GetChains")
                    .then(function (data) {
                    return data.data;
                });
            };
            PricesService.prototype.getItemsOfChain = function (_chainId) {
                return this.$http.get("api/priceComparetion/GetItemsOfChain", {
                    params: {
                        chainId: _chainId
                    }
                })
                    .then(function (data) {
                    return data.data;
                });
            };
            return PricesService;
        }());
        Prices.PricesService = PricesService;
        pricesModule.service("pricesService", PricesService);
    })(Prices = PriceComparison.Prices || (PriceComparison.Prices = {}));
})(PriceComparison || (PriceComparison = {}));
//# sourceMappingURL=items-service.js.map