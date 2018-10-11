function findUniq(arr) {
    const repeatingNumber = arr[0] !== arr[1] ? arr[2] : arr[0];
    return arr.find(number => number !== repeatingNumber);
}

module.exports = {
    findUniq
}