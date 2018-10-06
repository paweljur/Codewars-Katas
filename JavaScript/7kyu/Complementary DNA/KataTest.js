const Test = require("tape");
const Kata = require("./Kata.js");

Test("should work for some examples", (assert) => {
    assert.equal(Kata.DNAStrand("AAAA"),"TTTT","String AAAA is");
    assert.equal(Kata.DNAStrand("ATTGC"),"TAACG","String ATTGC is");
    assert.equal(Kata.DNAStrand("GTAT"),"CATA","String GTAT is");
    assert.end();
})