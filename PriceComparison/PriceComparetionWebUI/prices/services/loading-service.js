var PriceComparison;
(function (PriceComparison) {
    var Observer = (function () {
        function Observer(n, callback) {
            this.name = n;
            this.callback = callback;
        }
        return Observer;
    }());
    PriceComparison.Observer = Observer;
    var LoadingService = (function () {
        function LoadingService($q) {
            this.$q = $q;
            this.counter = 0;
            this.observers = [];
        }
        LoadingService.prototype.register = function (name, callback) {
            this.observers.push(new Observer(name, callback));
        };
        LoadingService.prototype.loading = function (action) {
            var _this = this;
            var defferd = this.$q.defer();
            this.loadingStart();
            action.then(function (data) { return defferd.resolve(data); }, function () { return defferd.reject(); })
                .finally(function () { return _this.loadingDone(); });
            return defferd.promise;
        };
        LoadingService.prototype.loadingStart = function () {
            this.counter++;
            if (this.counter === 1) {
                for (var _i = 0, _a = this.observers; _i < _a.length; _i++) {
                    var observer = _a[_i];
                    observer.callback(true);
                }
            }
        };
        LoadingService.prototype.loadingDone = function () {
            this.counter--;
            if (this.counter === 0) {
                for (var _i = 0, _a = this.observers; _i < _a.length; _i++) {
                    var observer = _a[_i];
                    observer.callback(false);
                }
            }
        };
        return LoadingService;
    }());
    PriceComparison.LoadingService = LoadingService;
    app.service("loadingService", LoadingService);
})(PriceComparison || (PriceComparison = {}));
//# sourceMappingURL=loading-service.js.map