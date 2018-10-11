const Test = require("tape");
const Kata = require("./Kata.js");

Test("should work for some examples", (assert) => {
    assert.equal(Kata.findUniq([ 0, 1, 0 ]), 1);
    assert.equal(Kata.findUniq([ 1, 1, 1, 2, 1, 1 ]), 2);
    assert.equal(Kata.findUniq([ 3, 10, 3, 3, 3 ]), 10);
    assert.end();
});