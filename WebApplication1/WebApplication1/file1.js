var output = "";
var op = "";
var result = 0;
var firstNum = "0";
$(document)
    .ready(function () {
    $('.numButton')
        .bind('click', function (e) {
        if (op !== "") {
            if (result === 0) {
                result = parseFloat(firstNum);
                firstNum = "0";
            }
            switch (op) {
                case "+":
                    result += parseFloat(e.target.textContent);
                    break;
                case "-":
                    result -= parseFloat(e.target.textContent);
                    break;
                case "/":
                    result /= parseFloat(e.target.textContent);
                    break;
                case "*":
                    result *= parseFloat(e.target.textContent);
                    break;
            }
            op = "";
        }
        else if (result === 0) {
            firstNum += e.target.textContent;
        }
        output += e.target.textContent;
        $('#input').val(output);
    });
    $('.clearButton')
        .bind('click', function (e) {
        output = "";
        result = 0;
        op = "";
        firstNum = "0";
        $('#input').val(output);
    });
    $('.opButton')
        .bind('click', function (e) {
        output += e.target.textContent;
        $('#input').val(output);
        op = e.target.textContent;
    });
    $('.eqButton')
        .bind('click', function (e) {
        output = result.toString();
        $('#input').val(output);
    });
});
//# sourceMappingURL=file1.js.map