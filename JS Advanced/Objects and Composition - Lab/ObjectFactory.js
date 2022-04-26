const library = {
    print: function () {
      console.log(`${this.name} is printing a page`);
    },
    scan: function () {
      console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
      console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
  };

  const orders = [
    {
      template: { name: 'ACME Printer'},
      parts: ['print']      
    },
    {
      template: { name: 'Initech Scanner'},
      parts: ['scan']      
    },
    {
      template: { name: 'ComTron Copier'},
      parts: ['scan', 'print']      
    },
    {
      template: { name: 'BoomBox Stereo'},
      parts: ['play']      
    }
  ];

function factory(library, orders){

    let output = [];

    for (const object of orders) {
        
        let currentObj = {};

        for (const key in object) {
            if (key === 'template') {
                currentObj = {
                    name: object[key].name
                }
            }
            else{
                for (const part of object[key]) {
                    currentObj[part] = library[part]
                }
            }
        }

        output.push(currentObj);

    }

    return output
}


const products = factory(library, orders);
console.log(products);

  