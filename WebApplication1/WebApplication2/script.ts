let numToGuess = 0;
let numOfGuesses = 10;
$(document)
    .ready(() => {
        "use strict";
        $('#new-game-button')
            .bind('click',
            (e) => {
                numToGuess = Math.floor((Math.random() * 100) + 1);
            });
        $('#submit-button')
            .bind('click',
            (e) => {

                let guess = parseInt($('#input-num').val());
                if (guess === numToGuess) {
                    $('#num-of-guesses').text("You Won!!!");
                    var s = $("<div class=\"right-guess\">" + guess.toString() + " is right</div>");
                    $('#scroll-bar').append(s);


                } else {
                    numOfGuesses--;
                    if (numToGuess < guess) {
                        let s = $("<div class=\"up-guess\">" + guess.toString() + " too high</div>");
                        $('#scroll-bar').append(s);
                    } else {
                        let s = $("<div class=\"down-guess\">" + guess + "too low</div>");
                        $('#scroll-bar').append(s);

                    }

                    if (numOfGuesses === 0) {
                        $('#num-of-guesses').text("You lost!! The number is " + numToGuess);
                        return;
                    }
                    $('#num-of-guesses').text("You have " + numOfGuesses + " guesses left");
                }
            });
    });