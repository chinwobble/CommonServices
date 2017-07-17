using Autofac;
using NUnit.Framework;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAccessService.EVEXmlAPIService.Models;

namespace WebAccessService.Tests.EVEXmlAPIService.Models
{
    [TestFixture]
    public class JumpsShould : TestsBase
    {
        [Test]
        public void Deserialise_Correctly()
        {
            var mediaTypeFormatters = _container.Resolve<MediaTypeFormatterCollection>();
            var reader = mediaTypeFormatters.FindReader(typeof(Jumps), new MediaTypeHeaderValue("application/xml"));
            
            //reader.ReadFromStreamAsync(typeof(Jumps),)

        }
    }
}
