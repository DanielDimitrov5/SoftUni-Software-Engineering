function OddPositions(array){

    let arr = [];

    for (let i = 0; i < array.length; i++) {
        
        if (i % 2 == 1) {
            const element = array[i];
            arr.push(element)
        }
    }

    return arr.reverse().map(x => x * 2).join(' ');
}

console.log(OddPositions([3, 0, 10, 4, 7, 3]))