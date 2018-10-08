function digPow(n, p){
    const digits = n.toString().split('').map(c => parseInt(c));
    const reducer = (sum, curr) => sum + Math.pow(curr, p++);
    let sumOfDigitsPower = digits.reduce(reducer, 0);
    return sumOfDigitsPower % parseInt(n) === 0 ?
        sumOfDigitsPower / n :
        -1;
}

module.exports = {
    digPow
}