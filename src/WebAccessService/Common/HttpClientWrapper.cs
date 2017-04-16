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
        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private readonly HttpClient _httpClient;

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var xmlFormatter = new XmlMediaTypeFormatter { UseXmlSerializer = false };
            xmlFormatter.SetSerializer<T>(new XmlSerializer(typeof(T)));
            return await response.Content.ReadAsAsync<T>(
                new List<MediaTypeFormatter>
                {
                    xmlFormatter,
                    new JsonMediaTypeFormatter()
                });
            
        }

        public async Task<T> GetXMLAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var serialiser = new XmlSerializer(typeof(T));
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                return (T)serialiser.Deserialize(stream);
            }
        }
        public async Task<T> PostAsync<T>(string url, HttpContent content)
        {
            var response = await _httpClient.PostAsync(url, content);
            return await response.Content.ReadAsAsync<T>(
                new List<MediaTypeFormatter>
                {
                    new XmlMediaTypeFormatter { UseXmlSerializer = true },
                    new JsonMediaTypeFormatter()
                });
        }
    }
}
