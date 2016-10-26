namespace PriceComparison.Prices {

    class ComparisonResultCrtl {
        items: IItem[];

        constructor(private pricesService: IPricesService) {
            
        }

    }

    pricesModule.component("comparisonResult", {
        templateUrl: "prices/templates/comparison-result.html",
        bindings: {
            items: "="        
        },
        controller: ComparisonResultCrtl
    });
}