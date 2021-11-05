function EqualNeighbors(matrix){

    let equalElements = 0;

    for (let i = 0; i < matrix.length; i++) {

        for (let j = 0; j < matrix[i].length; j++) {

            let value = matrix[i][j];

            if (i - 1 >= 0) {
                
                if(value === matrix[i - 1][j]){
                    equalElements++;
                }
            }
            if (j - 1 >= 0) {
                
                if(value === matrix[i][j - 1]){
                    equalElements++;
                }
            }
            if (i + 1 < matrix.length) {
                
                if(value === matrix[i + 1][j]){
                    equalElements++;
                }
            }
            if (j + 1 < matrix[i].length) {
                
                if(value === matrix[i][j + 1]){
                    equalElements++;
                }
            }
            ;
        }        
    }

    return equalElements / 2
}

console.log(EqualNeighbors([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]
))

console.log(EqualNeighbors([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
))