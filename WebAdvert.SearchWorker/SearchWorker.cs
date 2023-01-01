using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace WebAdvert.SearchWorker
{
    public class SearchWorker
    {
        public void PopulateElasticSearch(SNSEvent snsEvent, ILambdaContext contex)
        {
            foreach (var item in snsEvent.Records)
            {
                contex.Logger.LogLine(item.Sns.Message);
            }
        }

    }
}