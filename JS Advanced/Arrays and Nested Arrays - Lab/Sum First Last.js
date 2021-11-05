function SumFirstLast(array){
    array = array.map(Number);
    return array.shift() + array.pop();
}

console.log(SumFirstLast(['20', '30', '40']))