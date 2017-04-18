using System.Threading.Tasks;
using Xunit;
using Autofac;
using WebAccessService.EVEXmlAPIService;

namespace WebAccessService.Tests
{
    public class WebAccessServiceAutofacModuleShould : TestsBase
    {
        [Fact]
        public async Task WebAccessServiceAutofacModule_Can_Resolve_EVEXMLAPIService()
        {
            base.SetUpLogTable();
            var service = _container.Resolve<IEVEXMLAPIService>();
            await service.GetServerStatus();    
        }
    }
}
