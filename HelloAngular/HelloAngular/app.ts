const app = angular.module("app", []);
//angular.bootstrap(document.body, ["app"]);
app.controller("mainCtrl", ($scope) => {
    //$scope.message = "Enter Something....";
    let num1: string = "";
    let op: string = "";
    let num2: string = "";

    $scope.onClickNum = (n: number) => {
        num1 += n.toString();
        $scope.input_box = num1;

    };
    $scope.onClickString = (c: string) => {
        switch (c) {
        case "+":
                {
                    op = "+";
                    num2 = num1;
                    num1 = "";
                    break;
                }
        case "-":
            {
                op = "-";
                num2 = num1;
                num1 = "";
                break;
            }
        case "*":
            {
                op = "*";
                num2 = num1;
                num1 = "";
                break;
            }
        case "/":
            {
                op = "/";
                num2 = num1;
                num1 = "";
                break;
            }
        case "=":
            {
                switch (op) {
                    case "+":               
                    num1 = (parseFloat(num1) + parseFloat(num2)).toString();                   
                    break;
                    case "*":
                        num1 = (parseFloat(num1)  * parseFloat(num2)).toString();
                        break;
                    case "/":
                        num1 = (parseFloat(num1) / parseFloat(num2)).toString();
                        break;
                    case "-":
                        num1 = (parseFloat(num1) - parseFloat(num2)).toString();
                        break;
                    }
                num2 = "";
                op = "";
            }
        case "c":
        {
                    num1 = "";
                    num2 = "";
            op = "";
                    }
    $scope.input_box = num1;
        }
    };
});
