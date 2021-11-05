function NegativePositiveNumber(array){

    let newArr = [];

    for (const element of array) {
        if (element < 0) {
            newArr.unshift(element)
        }else{
            newArr.push(element);
        }
    }

    console.log(newArr.join('\n'))
}

NegativePositiveNumber([7, -2, 8, 9]);
NegativePositiveNumber([3, -2, 0, -1]);