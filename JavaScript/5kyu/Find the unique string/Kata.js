function compareWords(base, compared){
    let result = true;
    base = base.replace('/r', '/').toLowerCase().split('');
    compared.replace('/r', '/').toLowerCase().split('').forEach(c => {
        if (base.indexOf(c) < 0)
            result = false;
    })
    return result;
}

function findUniq(arr) {
    const repeatingWord = compareWords(arr[0], arr[1]) ? arr[0] : arr[2];
    return arr.filter(word => !compareWords(repeatingWord, word))[0];
}


module.exports = {
    findUniq
}