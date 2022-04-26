function ArrayRotator(array, rotationCount){
    for (let i = 0; i < rotationCount; i++) {
        array.unshift(array.pop())
    }

    return array.join(' ');
}

console.log(ArrayRotator(['1', 
'2', 
'3', 
'4'], 
2
))

console.log(ArrayRotator(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
))