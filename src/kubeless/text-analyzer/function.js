const CognitiveServicesCredentials = require("@azure/ms-rest-js");
const TextAnalyticsAPIClient = require("@azure/cognitiveservices-textanalytics");

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

module.exports = {
  analyze: function(event, context) {
     if (!event.data.text) {
        const { response } = event.extensions;
        response.writeHead(400);
        return;
     }
     return analyzeContent(event.data.text);
  }
};
