function BiggstElement(matrix){

    let biggest = Number.MIN_SAFE_INTEGER;

    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col < matrix[row].length; col++) {
            
            if (matrix[row][col] > biggest) {

                biggest = matrix[row][col]
            }
        }
    }

    return biggest
}

console.log(BiggstElement([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]   
   ))