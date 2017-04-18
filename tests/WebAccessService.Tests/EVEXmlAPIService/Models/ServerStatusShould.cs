using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Autofac;
using System.Net.Http.Formatting;
using WebAccessService.EVEXmlAPIService.Models;
using System.Net.Http.Headers;

namespace WebAccessService.Tests.EVEXmlAPIService.Models
{
    public class ServerStatusShould : TestsBase
    {
        [Fact]
        public async Task Deserialise_Correctly()
        {
            var formatters = _container.Resolve<MediaTypeFormatterCollection>();
            var formatter = formatters.FindReader(typeof(ResponseWrapper<ServerStatus>), new MediaTypeHeaderValue("application/xml"));
            var httpResponse = TestDataHelpers.GetServerStatus();
            var stream = await httpResponse.Content.ReadAsStreamAsync();
            
            var result = await formatter.ReadFromStreamAsync(typeof(ResponseWrapper<ServerStatus>), stream, httpResponse.Content, null)
                as ResponseWrapper<ServerStatus>;
            Assert.Equal(34999, result.Result.OnlinePlayers);
            Assert.Equal("True", result.Result.ServerOpen);
        }
    }
}
