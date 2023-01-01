
using Microsoft.Extensions.Configuration;
using Nest;
using System;

namespace WebAdvert.SearchWorker
{
    public static class ElasticSearchHelper
    {
        private static IElasticClient? _elasticClient;
        public static IElasticClient GetInstance(IConfiguration configuration)
        {
            if (_elasticClient == null)
            {
                string? url = @"https://elastic.appmode.dev/";// configuration.GetSection("ES").GetValue<string>("URL");
                string? user = "elastic";//configuration.GetSection("ES").GetValue<string>("UserName");
                string? password = "oxn4J3v9oqJ8sud"; //configuration.GetSection("ES").GetValue<string>("Password");
                ConnectionSettings settings = new ConnectionSettings(new Uri(url)).DefaultIndex("adverts").BasicAuthentication(user, password);
                _elasticClient = new ElasticClient(settings);
            }
            return _elasticClient;
        }
    }
}
