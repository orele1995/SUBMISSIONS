namespace PriceComparison.Prices {

    class ListItemCrtl {
        isChecked: boolean;
        item: IItem;  
        onSelect: Function;
        onUnselect: Function;

        constructor(private $rootScope ) {
            $rootScope.$on('addToCartEvent',
                () => {
                    this.isChecked = false;
                });
           
        }
        onCheckboxClick(isChacked: boolean) {
            if (isChacked) {
                this.onSelect();
            }
            else {
                this.onUnselect();
            }
        }

     
    }

    pricesModule.component("listItem", {
        templateUrl: "prices/templates/list-item.html",
        bindings: {
            item: "=",
            onSelect:"&",
            onUnselect:"&"
        },
        controller: ListItemCrtl
    });
}