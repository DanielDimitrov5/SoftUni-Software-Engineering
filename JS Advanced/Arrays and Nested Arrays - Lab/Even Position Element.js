function EvenPositionElemnets(array){

    let elements = '';

    for (let i = 0; i < array.length; i++) {
        
        if (i % 2 == 0) {
            elements += array[i] + ' ';
        }
    }

    return elements;
}

console.log(EvenPositionElemnets(['20', '30', '40', '50', '60']));