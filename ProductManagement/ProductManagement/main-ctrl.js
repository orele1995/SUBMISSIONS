var MainCtrl = (function () {
    function MainCtrl(ProductsService) {
        this.ProductsService = ProductsService;
    }
    MainCtrl.prototype.getProducts = function () {
        return this.ProductsService.getProducts();
    };
    return MainCtrl;
}());
