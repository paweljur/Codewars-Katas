function sumTwoSmallestNumbers(numbers) {
    let firstMin = Infinity;
    let secondMin = Infinity;
    numbers.forEach(i => {
        if(i < firstMin) {
            secondMin = firstMin;
            firstMin = i;
        }
        else if (i < secondMin)
            secondMin = i;
    })
    return firstMin + secondMin;
};

module.exports = {
    sumTwoSmallestNumbers
}