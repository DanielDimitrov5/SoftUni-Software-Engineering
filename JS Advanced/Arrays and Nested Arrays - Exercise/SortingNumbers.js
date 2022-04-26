function NumberSort(array){
    let sorted = [];

    while (array.length > 0) {
        if (array.length == 1) {
            sorted.push(array[0])
            break;
        }

        const min = Math.min.apply(Math, array);
        const max = Math.max.apply(Math, array);

        sorted.push(min);
        sorted.push(max);

        const minIndex = array.indexOf(min);
        array.splice(minIndex, 1);

        const maxIndex = array.indexOf(max);
        array.splice(maxIndex, 1);
    }

    return sorted
}

console.log(NumberSort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
console.log(NumberSort([1, 65, 3, 52, 48, 63, 31, -3, 18]));
console.log(NumberSort([1]));