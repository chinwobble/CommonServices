using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAccessService.Common
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly IEnumerable<MediaTypeFormatter> _mediaTypeFormatters;
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient, IEnumerable<MediaTypeFormatter> mediaTypeFormatters)
        {
            _httpClient = httpClient;
            _mediaTypeFormatters = mediaTypeFormatters;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var responseStr = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsAsync<T>(_mediaTypeFormatters);
        }

        public async Task<T> PostAsync<T>(string url, HttpContent content)
        {
            var response = await _httpClient.PostAsync(url, content);
            return await response.Content.ReadAsAsync<T>(_mediaTypeFormatters);
        }
    }
}
