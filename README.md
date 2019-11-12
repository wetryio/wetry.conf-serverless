# WeTry.conf 
## WeTry Serverless avec vous 

### Prerequis
- [NodeJS](https://nodejs.org/en/)
- [Visual Studio Code](https://code.visualstudio.com/)

## Create project
Copier le fichier book.json de common vers Azure dans le folder des functions.

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
    var FIVE_MIN = 5*60*1000;
    var items = getGoldenBookItems();
    var itemsCanStay = { data: [] };
    for (var i = 0; i < items.data.length; i++) {
        var item = items.data[i];
        var diff = (new Date(item.createAt)) - (new Date());
        if(diff >= (-FIVE_MIN)){
            itemsCanStay.data.push(item);
        }
    }
    writeGoldenBookItems(itemsCanStay);
}
```
