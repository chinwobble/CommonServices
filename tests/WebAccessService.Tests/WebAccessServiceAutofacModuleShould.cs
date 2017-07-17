using System.Threading.Tasks;
using Autofac;
using NUnit.Framework;
using WebAccessService.EVEXmlAPIService;

namespace WebAccessService.Tests
{
    [TestFixture]
    public class WebAccessServiceAutofacModuleShould : TestsBase
    {
        [Test]
        public async Task WebAccessServiceAutofacModule_Can_Resolve_EVEXMLAPIService()
        {
            base.SetUpLogTable();
            var service = _container.Resolve<IEveXmlWebClient>();
            await service.GetServerStatus();    
        }
    }
}
