function AggregateElements(array){
    console.log(array.reduce((a, b) => a + b));

    let revercedSum = 0;

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        
        revercedSum += 1 / element;
    }

    console.log(revercedSum)

    console.log(array.join(''))
}


AggregateElements([1, 2, 3]);