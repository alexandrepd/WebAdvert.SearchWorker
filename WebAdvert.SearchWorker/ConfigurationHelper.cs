
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebAdvert.SearchWorker
{
    public static class ConfigurationHelper
    {
        private static IConfiguration _configuration;
        public static IConfiguration instance
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true).Build();
                }
                return _configuration;
            }

        }
    }
}
