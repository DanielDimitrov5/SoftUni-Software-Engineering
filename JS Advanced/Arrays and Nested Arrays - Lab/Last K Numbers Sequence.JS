function LastKElements(n, k){
    let array = [1];

    for (let i = 1; i < n; i++) {

        let num = 0;

        if (i - 1 < k) {

            num = array.reduce((a, b) => a + b);
        } else{

            num = array.slice(i - k, i).reduce((a, b) => a + b);
        }

        array[i] = num
    }

    return array
}

console.log(LastKElements(6, 3))
console.log(LastKElements(8, 2))