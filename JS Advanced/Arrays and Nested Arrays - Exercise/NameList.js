function SortNames(array){
    array.sort((a, b) => a.toLowerCase().localeCompare(b.toLowerCase()));
    let sorted = []

    for (let i = 0; i < array.length; i++) {
        sorted[i] = `${i + 1}.${array[i]}`;
    }

    return sorted.join('\n');
}

console.log(SortNames(["John", "Bob", "Christina", "Ema"]))
console.log(SortNames(['Q', 'a']))