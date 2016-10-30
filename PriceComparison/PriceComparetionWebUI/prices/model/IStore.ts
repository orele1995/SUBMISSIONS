namespace PriceComparison.Prices {

    export interface IStoreModel {
        id: number;
        store:IStore;
    }

    export interface IStore {
        storeID: number;
        storeCode: number;
        chainID: number;
        address: string;
        city: string;
        prices: IPrice[];
        }
}
