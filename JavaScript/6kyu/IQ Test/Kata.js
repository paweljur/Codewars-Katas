function iqTest(numbers){
    const numbersParsed= numbers.split(' ').map(value => parseInt(value));
    const oddNumbers = numbersParsed.filter(number => number % 2 === 1);
    const evenNumbers = numbersParsed.filter(number => number % 2 === 0);
    return oddNumbers.length < evenNumbers.length ?
        numbersParsed.indexOf(oddNumbers[0]) + 1 :
        numbersParsed.indexOf(evenNumbers[0]) + 1;
}

module.exports = {
    iqTest
}