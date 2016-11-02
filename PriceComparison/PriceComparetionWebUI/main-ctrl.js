var PriceComparison;
(function (PriceComparison) {
    var MainCtrl = (function () {
        function MainCtrl(loadingService) {
            var _this = this;
            this.loadingService = loadingService;
            this.loading = false;
            this.onLoadingChanged = function (newValue) {
                _this.loading = newValue;
            };
            loadingService.register("mainCtrl", this.onLoadingChanged);
        }
        return MainCtrl;
    }());
    app.controller("mainCtrl", MainCtrl);
})(PriceComparison || (PriceComparison = {}));
//# sourceMappingURL=main-ctrl.js.map