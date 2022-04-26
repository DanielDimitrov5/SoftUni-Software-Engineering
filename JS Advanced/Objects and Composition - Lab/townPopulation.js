function population (array){
    let towns = {};

    for (const record of array) {
        let tupple = record.split(' <-> ');

        let name = tupple[0];
        let population = Number(tupple[1]);

        if (towns[name] == undefined) {
            towns[name] = 0
        }
    
        towns[name] += population;
    }

    for (const key in towns) {
        console.log(`${key} : ${towns[key]}`)
    }

}

population(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
)

population(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
)