using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WebAccessService.EVEXmlAPIService.Models;
using WebAccessService.Common;
using WebAccessService.EVEXmlAPIService;
using System.Net.Http.Formatting;
using System.Net.Http;
using RateLimiter;
using NLog;

namespace WebAccessService
{
    public class WebAccessServiceAutofacModule : Autofac.Module
    {
        // list of named services to link httpClients with services
        public enum WebServices
        {
            EVEXMLAPI
        }

        protected override void Load(ContainerBuilder builder)
        {
            registerEVEAPIServices(builder);
            builder.Register(c => LogManager.GetCurrentClassLogger())
                .As<ILogger>();

            builder.Register<TimeLimiter>(c => TimeLimiter.GetFromMaxCountByInterval(c.Resolve<IConfigurationProvider>().EveAPIRateLimit, TimeSpan.FromSeconds(1)))
                .Keyed<IRateLimiter>(WebServices.EVEXMLAPI)
                .SingleInstance();
                
            builder.RegisterType<ConfigurationProvider>()
                .As<IConfigurationProvider>()
                .SingleInstance();

            // a collection of serialiser deserialisers which are configured globally and cached 
            builder.Register(c =>
            {
                var mediaTypeFormatters = new MediaTypeFormatterCollection();
                mediaTypeFormatters.XmlFormatter.UseXmlSerializer = true;
                return mediaTypeFormatters;
            })  .As<IEnumerable<MediaTypeFormatter>>()
                .SingleInstance();
        }

        /// <summary>
        /// Register all the services that are specific to an external eve xml api web service
        /// </summary>
        /// <param name="builder"></param>
        private void registerEVEAPIServices(ContainerBuilder builder)
        {
            builder.Register<EVEXMLAPIService>(c => new EVEXMLAPIService(
                    c.ResolveKeyed<IHttpClientWrapper>(WebServices.EVEXMLAPI),
                    c.Resolve<IConfigurationProvider>()))
                .As<IEVEXMLAPIService>()
                .InstancePerLifetimeScope();

            builder.Register<HttpClient>(c => HttpClientFactory.Create(
                new HttpClientHandler(),
                new RateLimitHandler(c.ResolveKeyed<IRateLimiter>(WebServices.EVEXMLAPI)),
                new LoggingHandler(c.Resolve<ILogger>())))
                .Keyed<HttpClient>(WebServices.EVEXMLAPI);

            builder.Register(c =>
                new HttpClientWrapper(
                    c.ResolveKeyed<HttpClient>(WebServices.EVEXMLAPI),
                    c.Resolve<IEnumerable<MediaTypeFormatter>>()
            ))  .Keyed<IHttpClientWrapper>(WebServices.EVEXMLAPI)
                .SingleInstance();
        }
    }
}
