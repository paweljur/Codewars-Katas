const Test = require("tape");
const Kata = require("./Kata.js");

Test("should work for some examples", (assert) => {
    assert.equal(Kata.digPow(89, 1), 1)
    assert.equal(Kata.digPow(92, 1), -1)
    assert.equal(Kata.digPow(46288, 3), 51)
    assert.end();
})