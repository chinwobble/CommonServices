using System;
using System.Collections.Generic;
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
            => await getFromServerAndUnwrap<ServerStatus>("/server/ServerStatus.xml.aspx");

        public async Task<List<Sovereignty>> GetSovereignty()
            => await getFromServerAndUnwrapCollection<Sovereignty>("/map/Sovereignty.xml.aspx");

        public async Task<List<Kills>> GetKills()
            => await getFromServerAndUnwrapCollection<Kills>("/map/Kills.xml.aspx");

        public async Task<List<Jumps>> GetJumps()
            => await getFromServerAndUnwrapCollection<Jumps>("/map/Jumps.xml.aspx");

        private async Task<TResult> getFromServerAndUnwrap<TResult>(string path) 
            where TResult : IEVEXmlResult
        {
            var url = buildUri(path);
            var response = await _httpClient.GetAsync<ResponseWrapper<TResult>>(url);
            return response.Result;
        }

        private async Task<List<TResult>> getFromServerAndUnwrapCollection<TResult>(string path)
            where TResult : IEVEXmlResultRow
        {
            var url = buildUri(path);
            var response = await _httpClient.GetAsync<ResponseWrapper<IEVEXmlRowset<TResult>>>(url);
            return response.Result.RowSet;
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
