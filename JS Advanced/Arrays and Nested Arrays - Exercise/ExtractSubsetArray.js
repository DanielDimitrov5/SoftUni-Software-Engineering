function SubsetExtractor(array){
    let reduced = [];

    let minValue = array[0];

    for (const el of array) {
        if (el >= minValue) {
            reduced.push(el)

            minValue = el;
        }
    }

    return reduced;
}

console.log(SubsetExtractor([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    ))

console.log(SubsetExtractor([1, 
    2, 
    3,
    4]
    ))

console.log(SubsetExtractor([20, 
    3, 
    2, 
    15,
    6, 
    1]
     ))