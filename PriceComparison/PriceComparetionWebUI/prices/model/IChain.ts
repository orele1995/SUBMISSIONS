namespace PriceComparison.Prices {

    export interface IChain {
        chainID: number;
        chainName: string;
        stores: IStore[];
    }
}