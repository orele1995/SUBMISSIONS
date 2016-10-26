const app = angular.module("app", ["ngRoute"]);

app.controller("mainCtrl", MainCtrl);
app.service("ProductsService", ProductsService);

app.component("item",
    {
        templateUrl: "/item.html",
        bindings: {
            item: "="
        },
        controller: ItemCtrl
    }
);

app.config(($routeProvider: ng.route.IRouteProvider) => {
    $routeProvider.when("/allProdacts",
    {
        templateUrl: "/all-products.html",
        controller: MainCtrl,
        controllerAs: "$ctrl"
        });
    $routeProvider.when("/Product:id",
        {
            templateUrl: "/product.html",
            controller: ItemCtrl,
            controllerAs: "$ctrl"
        });
    $routeProvider.otherwise("/allProdacts");
});

