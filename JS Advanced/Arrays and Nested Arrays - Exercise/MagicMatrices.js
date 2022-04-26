function MagicMatrices(matrix){
    let value = matrix[0].reduce((a, b) => a + b, 0);

    for (let i = 0; i < matrix.length; i++) {

        if (value != matrix[i].reduce((a, b) => a + b, 0)) {
            return false;
        }
    }

    
    for (let i = 0; i < matrix.length; i++) {
        let sum = 0;
        for (let j = 0; j < matrix.length; j++) {
            sum += matrix[j][i];            
        }

        if (value != sum) {
            return false;
        }
    }

    return true;
}

console.log(MagicMatrices([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   ))

console.log(MagicMatrices([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
   ))

console.log(MagicMatrices([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
   ))