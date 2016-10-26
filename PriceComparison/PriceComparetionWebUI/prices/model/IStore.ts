namespace PriceComparison.Prices {

    export interface IStore {
        storeId: number;
        storeCode: number;
        chainId: number;
        address: string;
        city: string;
        prices: IPrice[];
    }
}
