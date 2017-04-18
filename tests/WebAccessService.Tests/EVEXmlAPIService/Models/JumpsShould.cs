using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebAccessService.EVEXmlAPIService.Models;
using Xunit;

namespace WebAccessService.Tests.EVEXmlAPIService.Models
{
    public class JumpsShould : TestsBase
    {
        [Fact]
        public void Deserialise_Correctly()
        {
            var mediaTypeFormatters = _container.Resolve<MediaTypeFormatterCollection>();
            var reader = mediaTypeFormatters.FindReader(typeof(Jumps), new MediaTypeHeaderValue("application/xml"));
            
            //reader.ReadFromStreamAsync(typeof(Jumps),)

        }
    }
}
