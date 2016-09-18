var numToGuess = 0;
var numOfGuesses = 10;
$(document)
    .ready(function () {
    "use strict";
    $('#new-game-button')
        .bind('click', function (e) {
        numToGuess = Math.floor((Math.random() * 100) + 1);
    });
    $('#submit-button')
        .bind('click', function (e) {
        var guess = parseInt($('#input-num').val());
        if (guess === numToGuess) {
            $('#num-of-guesses').text("You Won!!!");
            var s = $("<div class=\"right-guess\">" + guess.toString() + " is right</div>");
            $('#scroll-bar').append(s);
        }
        else {
            numOfGuesses--;
            if (numToGuess < guess) {
                var s_1 = $("<div class=\"up-guess\">" + guess.toString() + " too high</div>");
                $('#scroll-bar').append(s_1);
            }
            else {
                var s_2 = $("<div class=\"down-guess\">" + guess + "too low</div>");
                $('#scroll-bar').append(s_2);
            }
            if (numOfGuesses === 0) {
                $('#num-of-guesses').text("You lost!! The number is " + numToGuess);
                return;
            }
            $('#num-of-guesses').text("You have " + numOfGuesses + " guesses left");
        }
    });
});
//# sourceMappingURL=script.js.map