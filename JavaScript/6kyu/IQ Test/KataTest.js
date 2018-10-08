const Test = require("tape");
const Kata = require("./Kata.js");

Test("should work for some examples", (assert) => {
    assert.equal(Kata.iqTest("2 4 7 8 10"),3);
    assert.equal(Kata.iqTest("2 3 3"), 1);
    assert.end();
})