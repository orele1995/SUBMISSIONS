let output = "";
let op = "";
let result = 0;
let firstNum = "0";

$(document)
    .ready(() => {
        $('.numButton')
            .bind('click',
            (e) => {
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
                } else if (result === 0) {
                    firstNum += e.target.textContent;
                }
                output += e.target.textContent;
                $('#input').val(output);
            });
        $('.clearButton')
            .bind('click',
            (e) => {
                output = "";
                result = 0;
                op = "";
                firstNum = "0";
                $('#input').val(output);
            });
        $('.opButton')
            .bind('click',
            (e) => {
                output += e.target.textContent;

                $('#input').val(output);
                op = e.target.textContent;
            });
        $('.eqButton')
            .bind('click',
            (e) => {
                output = result.toString();
                $('#input').val(output);
            });
    });