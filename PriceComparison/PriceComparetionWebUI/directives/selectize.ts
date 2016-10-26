
namespace PriceComparison.Selectize {
    pricesModule.directive('selectize',
    () => {
        return (scope, element, attr, ctrls) => {
            var el = $(element) as any;

            el.selectpicker();
        };
    });
}