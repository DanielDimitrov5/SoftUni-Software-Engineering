function DiagonalSum(matrix){

    let primarySum = 0;
    let secondarySum = 0;

    for (let i = 0; i < matrix.length; i++) {
        primarySum += matrix[i][i];
    }

    matrix = matrix.reverse();

    for (let i = 0; i < matrix.length; i++) {
        secondarySum += matrix[i][i];
    }

    console.log(`${primarySum} ${secondarySum}`)
}

DiagonalSum([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]   
   )