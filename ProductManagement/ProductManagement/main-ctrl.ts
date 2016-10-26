

class MainCtrl {
   
   
    constructor(private ProductsService: ProductsService) {
    
    }
    getProducts(): IProdact[]{
        return this.ProductsService.getProducts();
   }

  
}