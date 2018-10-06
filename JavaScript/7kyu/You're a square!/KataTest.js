const Test = require("tape");
const Kata = require("./Kata.js");

Test("should work for some examples", (assert) => {
    assert.equal(Kata.isSquare(-1), false,"-1: Negative numbers cannot be square numbers");
    assert.equal(Kata.isSquare( 0), true, "0 is a square number (0 * 0)");
    assert.equal(Kata.isSquare( 3), false, "3 is not a square number");
    assert.equal(Kata.isSquare( 4), true, "4 is a square number (2 * 2)");
    assert.equal(Kata.isSquare(25), true, "25 is a square number (5 * 5)");
    assert.equal(Kata.isSquare(26), false, "26 is not a square number");
    assert.end();
})