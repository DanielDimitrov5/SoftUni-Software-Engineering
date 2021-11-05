function BiggerHalf(array){
    array.sort(function(a, b) {
        return a - b;
      });
      
    return array.slice(array.length / 2)
}

console.log(BiggerHalf([3, 19, 14, 7, 2, 19, 6]))