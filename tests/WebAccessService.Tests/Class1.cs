using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebAccessService.Common;
using WebAccessService.EVEXmlAPIService.Models;

namespace WebAccessService.Tests
{
    
    public class TestClass
    {
        [Fact]
        public async Task testMethod()
        {
            var client = new HttpClientWrapper(new HttpClient());
            var result = await client.GetAsync<SovereigntyResponse>("https://api.eveonline.com/map/Sovereignty.xml.aspx");
            Assert.True(result.Result.RowSet.Count > 1000);
        }
    }
}
