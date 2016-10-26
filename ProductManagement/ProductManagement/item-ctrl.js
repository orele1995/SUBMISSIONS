var ItemCtrl = (function () {
    function ItemCtrl(ProductsService) {
        this.ProductsService = ProductsService;
    }
    ItemCtrl.prototype.onRemove = function (p) {
        this.ProductsService.deleteProduct(p);
    };
    return ItemCtrl;
}());
