function SortByTwoCreteria(array){
    array.sort((a, b) => a.length - b.length || a.localeCompare(b))

    return array.join('\n', array)
}

console.log(SortByTwoCreteria(['test', 
'Deny', 
'omen', 
'Default']
))