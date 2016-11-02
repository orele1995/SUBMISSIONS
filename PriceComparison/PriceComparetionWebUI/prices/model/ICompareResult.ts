
namespace PriceComparison.Prices {

    export interface ICompareResult {
        storeId: number;
        cart: IDisplayItem[];
        sum: number;
        }

}