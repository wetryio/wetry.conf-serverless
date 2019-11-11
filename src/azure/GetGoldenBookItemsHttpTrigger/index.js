const fs = require('fs');

function getGoldenBookItems() {
    let rawdata = fs.readFileSync('book.json');
    return JSON.parse(rawdata);
}

module.exports = async function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');
    context.res = {
        status: 200,
        body: getGoldenBookItems()
    };
};