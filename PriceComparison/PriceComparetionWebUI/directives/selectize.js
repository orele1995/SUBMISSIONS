var PriceComparison;
(function (PriceComparison) {
    var Selectize;
    (function (Selectize) {
        pricesModule.directive('selectize', function () {
            return function (scope, element, attr, ctrls) {
                var el = $(element);
                el.selectpicker();
            };
        });
    })(Selectize = PriceComparison.Selectize || (PriceComparison.Selectize = {}));
})(PriceComparison || (PriceComparison = {}));
//# sourceMappingURL=selectize.js.map