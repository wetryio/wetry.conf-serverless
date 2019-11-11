namespace Serverless.App.Shared.Models
{
    public class SentimentalAnalysis
    {
        public SentimentalAnalysisItem[] Documents { get; set; }
        public dynamic Errors { get; set; }
    }

    public class SentimentalAnalysisItem
    {
        public int Id { get; set; }
        public float Score { get; set; }
    }
}
