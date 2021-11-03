function SquareOfStars(n){
    let result = '';

    if (n == null) {
        n = 5;
    }

    for (let i = 0; i < n; i++) {

        for (let j = 0; j < n; j++) {
        result += '* '
        }
        
        result += '\n'
    }

    console.log(result)
}

SquareOfStars(6)