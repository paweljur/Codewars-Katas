const Test = require("tape");
const Kata = require("./Kata.js");

Test("should work for some examples", (assert) => {
    assert.equal(Kata.sumTwoSmallestNumbers([5, 8, 12, 19, 22]), 13 , "Sum should be 13");
    assert.equal(Kata.sumTwoSmallestNumbers([15, 28, 4, 2, 43]), 6 , "Sum should be 6");
    assert.equal(Kata.sumTwoSmallestNumbers([3, 87, 45, 12, 7]), 10 , "Sum should be 10");
    assert.equal(Kata.sumTwoSmallestNumbers([23, 71, 33, 82, 1]), 24 , "Sum should be 24");
    assert.equal(Kata.sumTwoSmallestNumbers([52, 76, 14, 12, 4]), 16 , "Sum should be 16");
    assert.end();
})