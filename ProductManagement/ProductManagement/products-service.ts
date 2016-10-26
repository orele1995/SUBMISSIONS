interface IProductsService {
    products: IProdact[];
    getProducts(): IProdact[];
    deleteProduct(p: IProdact):void;
}

class ProductsService implements IProductsService {
    products: IProdact[] = [];
    constructor() {
        this.init();
    }

  
    getProducts(): IProdact[] { return this.products; }

    

    deleteProduct(p: IProdact): void {
        const indexOf = this.products.indexOf(p);
        this.products.splice(indexOf, 1);
    }

    init () {
        for (let i = 0; i < 10; i++) {
            this.products.push({
                id: i,
                description: `description ${i}`,
                name: `product ${i}`,
                price: i * 10,
                creationDate: new Date()
            });
        }
    }
}