"use strict";

const CognitiveServicesCredentials = require("@azure/ms-rest-js");
const TextAnalyticsAPIClient = require("@azure/cognitiveservices-textanalytics");
const fs = require('fs');

async function analyzeContent(text) {
    const subscription_key = '43ef3ee75b274baca613fce15bafe9f9';
    const endpoint = 'https://wetryconf.cognitiveservices.azure.com/';

    const creds = new CognitiveServicesCredentials.ApiKeyCredentials({ inHeader: { 'Ocp-Apim-Subscription-Key': subscription_key } });
    const textAnalyticsClient = new TextAnalyticsAPIClient.TextAnalyticsClient(creds, endpoint);

    return await sentimentAnalysis(textAnalyticsClient, text);
};

async function sentimentAnalysis(client, text) {

    const sentimentInput = {
        documents: [
            { language: "fr", id: "1", text: text }
        ]
    };

    const sentimentResult = await client.sentiment({
        multiLanguageBatchInput: sentimentInput
    });

    return sentimentResult;
};

function signInUser(username, password) {
    return username === 'admin' && password === 'admin';
}

function cleanItems() {
    var items = getGoldenBookItems();
}

// Helpers
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

// For test -> node .\common-functions.js
// { documents: [ { id: '1', score: 0.6132941842079163 } ], errors: [] }
analyzeContent('Je vous aime pour toujours').then(
    response => {
        console.log(response);
    }
);

insertGoldenBookItems({ title: 'My Title', content: 'Je vous aime pour toujours ! Vous êtez geniaux !', createAt: Date.now() });

console.log(getGoldenBookItems());
