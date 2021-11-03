function StringLength(string1, string2, string3){
    let sum = string1.length + string2.length + string3.length
    console.log(sum)
    console.log(Math.floor(sum / 3))
}

StringLength('chocolate', 'ice cream', 'cake')