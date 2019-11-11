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
        public async Task<SentimentalAnalysis> AnalysisSentimentalText(string content)
        {
            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:7000")
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
            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:7000")
            })
            {
                var response = await httpClient.PostAsync("/api/CreateGoldenBookItemHttpTrigger", new StringContent(JsonConvert.SerializeObject(entity)));
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<GoldenBookItemDto>(await response.Content.ReadAsStringAsync());
                }
            }

            return default(GoldenBookItemDto);
        }

        public async Task<GoldenBook> GetGoldenBookItems()
        {
            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:7000")
            })
            {
                var response = await httpClient.GetAsync("/api/GetGoldenBookItemsHttpTrigger");
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<GoldenBook>(await response.Content.ReadAsStringAsync());
                }
            }

            return default(GoldenBook);
        }
    }
}
