function AddRemoveElement(array){
    let value = 0;

    let arr = [];

    for (const command of array) {
        value++;

        if (command === 'add') {
            arr.push(value)
        }
        else{
            arr.pop();
        }
    }

    if (arr.length == 0) {
        return 'Empty'
    }

    return arr.join('\n');
}

console.log(AddRemoveElement(['add', 
'add', 
'add', 
'add']
))

console.log(AddRemoveElement(['add', 
'add', 
'remove', 
'add', 
'add']
))

console.log(AddRemoveElement(['remove', 
'remove', 
'remove']
))