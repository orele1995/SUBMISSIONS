var PriceComparison;
(function (PriceComparison) {
    var Prices;
    (function (Prices) {
        var ComparisonResultCrtl = (function () {
            function ComparisonResultCrtl(pricesService) {
                this.pricesService = pricesService;
            }
            return ComparisonResultCrtl;
        }());
        pricesModule.component("comparisonResult", {
            templateUrl: "prices/templates/comparison-result.html",
            bindings: {
                items: "="
            },
            controller: ComparisonResultCrtl
        });
    })(Prices = PriceComparison.Prices || (PriceComparison.Prices = {}));
})(PriceComparison || (PriceComparison = {}));
//# sourceMappingURL=comparison-result.js.map