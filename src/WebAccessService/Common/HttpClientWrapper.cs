using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace WebAccessService.Common
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly MediaTypeFormatterCollection _mediaTypeFormatters;
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient, MediaTypeFormatterCollection mediaTypeFormatters)
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
