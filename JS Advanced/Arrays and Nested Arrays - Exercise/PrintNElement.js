function GetNElement(array, step){
    let outputArr = [];

    for (let i = 0; i < array.length; i += step) {
        const element = array[i];
        
        outputArr.push(element);
    }

    return outputArr;
}

console.log(GetNElement(['5', 
'20', 
'31', 
'4', 
'20'], 
2
))

console.log(GetNElement(['dsa',
'asd', 
'test', 
'tset'], 
2
))