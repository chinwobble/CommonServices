using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebAccessService.Common;
using WebAccessService.EVEXmlAPIService.Models;
using Autofac;
using WebAccessService.EVEXmlAPIService;
using static WebAccessService.WebAccessServiceAutofacModule;
using System.Net.Http.Formatting;

namespace WebAccessService.Tests
{
    public class WebAccessServiceAutofacModuleShould
    {
        [Fact]
        public async Task WebAccessServiceAutofacModule_Can_Resolve_EVEXMLAPIService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<WebAccessServiceAutofacModule>();

            using (var container = builder.Build())
            {
                var service = container.Resolve<IEVEXMLAPIService>();
                await service.GetServerStatus();
            }
        }
    }
}
