namespace PriceComparison.Prices {

    class ComparisonResultCrtl {
        results: ICompareResult[];
        minSum: Number;

        constructor(private pricesService: IPricesService) {
            this.pricesService.getPricesResult()
                .then((data) => {
                    this.results = data;
                    this.minSum = this.results[0].sum;
                    for (var i = 1; i < this.results.length; i++) {
                        if (this.results[i].sum < this.minSum) {
                            this.minSum = this.results[i].sum;
                        }
                    }
                });
        }

        public classOfPrice(item: IDisplayItem): string {
            var minPrice;
            var maxPrice;

            // initialize min and max prices
            for (var k = 0; k < this.results[0].cart.length; k++) {
                if (this.results[0].cart[k].itemName === item.itemName) {
                    minPrice = this.results[0].cart[k].itemPrice;
                    maxPrice = this.results[0].cart[k].itemPrice;
                }
            }

            //finding min and max prices
            for (var i = 1; i < this.results.length; i++) {             
                for (var j = 0; j < this.results[i].cart.length; j++) {
                    if (this.results[i].cart[j].itemName === item.itemName) {
                        var price = this.results[i].cart[j].itemPrice;
                        if (price < minPrice) {
                            minPrice = price;
                        }
                        if (price > maxPrice) {
                            maxPrice = price;
                        }
                    }
                }               
            }

            switch (item.itemPrice) {
            case minPrice:
                return "min-price";
            case maxPrice:
                return "max-price";
            default:
                return "";
            }
        }
    }

    pricesModule.component("comparisonResult", {
        templateUrl: "prices/templates/comparison-result.html",
      controller: ComparisonResultCrtl
    });
}