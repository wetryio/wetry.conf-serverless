# WeTry.conf 
## WeTry Serverless avec vous 

### Prerequis
- [NodeJS](https://nodejs.org/en/)
- [Visual Studio Code](https://code.visualstudio.com/)

## Create project
Copier le fichier book.json de common vers Azure dans le folder des functions.

## Website de test
https://wetryconfserverlessapp.azurewebsites.net/

## CORS
``` javascript
"Host": {
    "LocalHttpPort": 7001,
    "CORS": "*",
    "CORSCredentials": false
  }
```

## HttpTrigger Function Get Items
Ajouter :

``` javascript
const fs = require('fs');

function getGoldenBookItems() {
    let rawdata = fs.readFileSync('book.json');
    return JSON.parse(rawdata);
}
```

## HttpTrigger Function Post Items
Ajouter :

``` javascript
const fs = require('fs');

function getGoldenBookItems() {
    let rawdata = fs.readFileSync('book.json');
    return JSON.parse(rawdata);
}

function writeGoldenBookItems(items) {
    let data = JSON.stringify(items);
    fs.writeFileSync('book.json', data);
}

function insertGoldenBookItem(item) {
    var items = getGoldenBookItems();
    items.data.push(item);
    writeGoldenBookItems(items);
}
```

## TimerTrigger Function Clear
Ajouter :

``` javascript
const fs = require('fs');

function getGoldenBookItems() {
    let rawdata = fs.readFileSync('book.json');
    return JSON.parse(rawdata);
}

function writeGoldenBookItems(items) {
    let data = JSON.stringify(items);
    fs.writeFileSync('book.json', data);
}

function cleanItems() {
    var items = getGoldenBookItems();
    var itemsCanStay = { data: [] };
    for (var i = 0; i < items.data.length; i++) {
        if(items.data[i].createAt < ){
            
        }
    }

    writeGoldenBookItems(itemsCanStay);
}
```