using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using WebAccessService.Common;
using WebAccessService.EVEXmlAPIService.Models;

namespace WebAccessService.EVEXmlAPIService
{
    public class EVEXMLAPIService : IEVEXMLAPIService
    {
        private readonly IConfigurationProvider _config;
        private readonly IHttpClientWrapper _httpClient;

        public EVEXMLAPIService(IHttpClientWrapper httpClient, IConfigurationProvider config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<ServerStatus> GetServerStatus()
        {
            var url = buildUri("/server/ServerStatus.xml.aspx");
            var response = await _httpClient.GetAsync<ResponseWrapper<ServerStatus>>(url);
            return response.Result;
        }

        private async Task<TResult> getFromServerAndUnwrap<TResult>(string path) 
            where TResult : IEVEXMLResponseResult
        {
            var url = buildUri(path);
            var response = await _httpClient.GetAsync<ResponseWrapper<TResult>>(url);
            return response.Result;
        }

        private string buildUri(string path, NameValueCollection query = null)
        {
            var uriBuilder = new UriBuilder(_config.EveAPIHost);
            if (query != null)
            {
                uriBuilder.Query = query.ToString();
            }
            uriBuilder.Path = path;
            return uriBuilder.ToString();
        }
    }
}
