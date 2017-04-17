using System.Configuration;

namespace WebAccessService.Common
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public string EveAPIHost => getFromConfigFile("EVEAPI:HostName");
        public int EveAPIRateLimit => int.Parse(getFromConfigFile("EVEAPI:RateLimit"));

        private string getFromConfigFile(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        
    }
}
