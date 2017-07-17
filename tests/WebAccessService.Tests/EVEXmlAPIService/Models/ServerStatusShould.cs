using System.Threading.Tasks;
using Autofac;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using NUnit.Framework;
using WebAccessService.EVEXmlAPIService.Models;

namespace WebAccessService.Tests.EVEXmlAPIService.Models
{
    [TestFixture]
    public class ServerStatusShould : TestsBase
    {
        [Test]
        public async Task Deserialise_Correctly()
        {
            var formatters = _container.Resolve<MediaTypeFormatterCollection>();
            var formatter = formatters.FindReader(typeof(ResponseWrapper<ServerStatus>), new MediaTypeHeaderValue("application/xml"));
            var httpResponse = TestDataHelpers.GetServerStatus();
            var stream = await httpResponse.Content.ReadAsStreamAsync();
            
            var result = await formatter.ReadFromStreamAsync(typeof(ResponseWrapper<ServerStatus>), stream, httpResponse.Content, null)
                as ResponseWrapper<ServerStatus>;
            Assert.AreEqual(34999, result.Result.OnlinePlayers);
            Assert.AreEqual("True", result.Result.ServerOpen);
        }
    }
}
