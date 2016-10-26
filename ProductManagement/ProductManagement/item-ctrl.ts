class ItemCtrl {
    public item: IProdact;
    

    constructor(private ProductsService: ProductsService) {
    }

    onRemove(p: IProdact) {
        this.ProductsService.deleteProduct(p);
    }
}