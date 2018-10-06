function DNAStrand(dna){
    const dict = {
        A:"T",
        C:"G",
        T:"A",
        G:"C"
    };
    let reducer = (string, char) => string + dict[char];
    return dna.split('').reduce(reducer, "");
}

module.exports = {
    DNAStrand
}