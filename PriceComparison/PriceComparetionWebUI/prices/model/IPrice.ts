namespace PriceComparison.Prices {
    export interface IPrice {
        priceId: number;
        itemId: number;
        storeId: number;
        itemPrice: number;
    }
}