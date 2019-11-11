using System;

namespace Serverless.App.Shared.Models
{
    public class GoldenBook
    {
        public GoldenBookItemDto[] Data { get; set; }
    }

    public class GoldenBookItemDto : GoldenBookCreateItemDto
    {
        public int Id { get; set; }
        public long CreateAt { get; set; }
        public SentimentalAnalysisItem Sentiments { get; set; }
    }

    public class GoldenBookCreateItemDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
