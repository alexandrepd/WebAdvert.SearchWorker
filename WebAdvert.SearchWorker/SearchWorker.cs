using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Nest;
using Newtonsoft.Json;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace WebAdvert.SearchWorker
{
    public class SearchWorker
    {
        public SearchWorker() : this(ElasticSearchHelper.GetInstance(ConfigurationHelper.instance)) { }

        private readonly IElasticClient _client;
        private SearchWorker(IElasticClient client) { _client = client; }

        public async Task PopulateElasticSearch(SNSEvent snsEvent, ILambdaContext contex)
        {
            foreach (var item in snsEvent.Records)
            {
                contex.Logger.LogLine(item.Sns.Message);

                AdvertConfirmeMessage? confirmeMessage =  JsonConvert.DeserializeObject<AdvertConfirmeMessage>(item.Sns.Message);
                AdvertType? advert = MappingHelper.Map(confirmeMessage);

                await _client.IndexDocumentAsync(advert);
            }
        }

    }
}