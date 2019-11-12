using Blazored.LocalStorage;
using Newtonsoft.Json;
using Serverless.App.Shared.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Serverless.App.Client.Services
{
    public interface IFunctionService
    {
        Task<GoldenBook> GetGoldenBookItems();
        Task<GoldenBookItemDto> CreateGoldenBookItem(GoldenBookCreateItemDto entity);
        Task<SentimentalAnalysis> AnalysisSentimentalText(string content);
    }

    public class FunctionService : IFunctionService
    {

        private readonly Blazored.LocalStorage.ILocalStorageService localStorage;

        public FunctionService(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public async Task<SentimentalAnalysis> AnalysisSentimentalText(string content)
        {
            var getUrl = await localStorage.GetItemAsync<string>("getUrl");

            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(getUrl)
            })
            {
                var response = await httpClient.GetAsync(string.Empty);
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<SentimentalAnalysis>(await response.Content.ReadAsStringAsync());
                }
            }

            return default(SentimentalAnalysis);
        }

        public async Task<GoldenBookItemDto> CreateGoldenBookItem(GoldenBookCreateItemDto entity)
        {
            var postUrl = await localStorage.GetItemAsync<string>("postUrl");

            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(postUrl)
            })
            {
                var response = await httpClient.PostAsync(string.Empty, new StringContent(JsonConvert.SerializeObject(entity)));
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<GoldenBookItemDto>(await response.Content.ReadAsStringAsync());
                }
            }

            return default(GoldenBookItemDto);
        }

        public async Task<GoldenBook> GetGoldenBookItems()
        {
            var sentimentsUrl = await localStorage.GetItemAsync<string>("sentimentsUrl");

            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(sentimentsUrl)
            })
            {
                var response = await httpClient.GetAsync(string.Empty);
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<GoldenBook>(await response.Content.ReadAsStringAsync());
                }
            }

            return default(GoldenBook);
        }
    }
}
