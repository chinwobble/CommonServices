using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAccessService.Tests
{
    /// <summary>
    /// Collection of helper methods to be used in tests to mock the HttpResponse by reading from a file
    /// </summary>
    public class TestDataHelpers
    {
        public static HttpResponseMessage GetServerStatus() => getTestData("ServerStatus.xml");

        private static HttpResponseMessage getTestData(string xmlFileName)
        {
            var httpReponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            var codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
            
            var dirPath = Path.GetDirectoryName(codeBasePath);

            var filePath = Path.Combine(dirPath, "MockData", xmlFileName);
            var data = File.ReadAllText(filePath);
            httpReponseMessage.Content = new StringContent(data, Encoding.UTF8, "application/xml");
            return httpReponseMessage;
        }
    }
}
