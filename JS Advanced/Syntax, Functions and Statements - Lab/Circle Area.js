function CircleArea(argument){
    let type = typeof(argument)
    
    if(type == 'number'){
        console.log((Math.PI * Math.pow(argument, 2)).toFixed(2))
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${type}.`)
    }
}

CircleArea(5)