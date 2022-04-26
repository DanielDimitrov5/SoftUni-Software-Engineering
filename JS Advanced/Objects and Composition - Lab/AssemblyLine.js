function createAssemblyLine(){
    return {
        hasClima(car){
            car.temp = 21;

            car.tempSettings = 21;

            car.adjustTemp = function () {
                if (car.temp < car.tempSettings) {
                    car.temp++;
                }
                else if (car.temp > car.tempSettings){
                    car.temp--;
                } 
            }
        },
        hasAudio(car){
            car.currentTrack = null;

            car.nowPlaying = function(){
                console.log(`Now playing '${car.currentTrack.name}' by ${car.currentTrack.artist}`)
            }
        },
        hasParktronic(car){
            car.checkDistance = function (distance){
                let beep = 'Beep! ';

                if (distance < 0.1) {
                    console.log(beep.repeat(3).trim())
                }
                else if (distance >= 0.1 && distance < 0.25){
                    console.log(beep.repeat(2).trim())
                }
                else if (distance >= 0.25 && distance < 0.5){
                    console.log(beep.repeat(1).trim())
                }
                // else{
                //     console.log('')
                // }
            }
        }
    }
}

const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();

assemblyLine.hasParktronic(myCar);
myCar.checkDistance(2);
myCar.checkDistance(0.2);

console.log(myCar);


