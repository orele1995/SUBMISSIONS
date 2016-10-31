
namespace PriceComparison.Prices {

    export interface ICompareResult {
        store: IStore;
        cart: IDisplayItem[];
        sum: number;
        }

}