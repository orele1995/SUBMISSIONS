var ProductsService = (function () {
    function ProductsService() {
        this.products = [];
        this.init();
    }
    ProductsService.prototype.getProducts = function () { return this.products; };
    ProductsService.prototype.deleteProduct = function (p) {
        var indexOf = this.products.indexOf(p);
        this.products.splice(indexOf, 1);
    };
    ProductsService.prototype.init = function () {
        for (var i = 0; i < 10; i++) {
            this.products.push({
                id: i,
                description: "description " + i,
                name: "product " + i,
                price: i * 10,
                creationDate: new Date()
            });
        }
    };
    return ProductsService;
}());
