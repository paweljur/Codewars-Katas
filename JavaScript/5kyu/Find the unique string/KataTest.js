const Test = require("tape");
const Kata = require("./Kata.js");

Test("should work for some examples", (assert) => {
    assert.equal(Kata.findUniq([ 'Aa', 'aaa', 'aaaaa', 'BbBb', 'Aaaa', 'AaAaAa', 'a' ]), 'BbBb');
    assert.equal(Kata.findUniq([ 'abc', 'acb', 'bac', 'foo', 'bca', 'cab', 'cba' ]), 'foo');
    assert.equal(Kata.findUniq([ 'silvia', 'vasili', 'victor' ]), 'victor');
    assert.equal(Kata.findUniq([ 'TomMarvoloRiddle', 'IamLordVoldemort', 'Harry Potter' ]), 'Harry Potter');
    assert.equal(Kata.findUniq([ '    ', 'a', ' ' ]), 'a');
    assert.end();
});