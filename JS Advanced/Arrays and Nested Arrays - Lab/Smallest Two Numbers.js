function SmallestTwo(array){
    array.sort(function(a, b) {
        return a - b;
      });

    console.log(`${array[0]} ${array[1]}`);
}

SmallestTwo([30, 15, 50, 5]);