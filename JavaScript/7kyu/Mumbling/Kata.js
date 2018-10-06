function accum(str) {
    return str.split('')
        .map((value, index) => value.toUpperCase() + value.toLowerCase().repeat(index))
        .join('-');
}

module.exports = {
    accum
}