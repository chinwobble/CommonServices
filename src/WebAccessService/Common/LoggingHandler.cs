using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebAccessService.Common
{
    public class LoggingHandler : DelegatingHandler
    {
        private readonly ILogger _logger;
        public LoggingHandler(ILogger logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage retVal;
            var startTime = DateTime.UtcNow;

            var eventProperties = new Dictionary<string, object>();
            eventProperties["method"] = request.Method;
            eventProperties["uri"] = request.RequestUri;

            try
            {
                retVal = await base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.Error()
                    .Exception(ex)
                    .Message("Fail to call web service")
                    .Properties(eventProperties)
                    .Write();
                throw;
            }
            var endTime = DateTime.UtcNow;
            var elapsedTime = (startTime - endTime).Duration();

            if (retVal.IsSuccessStatusCode) 
            {
                _logger.Info()
                    .Message("successfully response from web service")
                    .Properties(eventProperties)
                    .Property("duration", elapsedTime)
                    .Write();
            }
            else // log an error if status code is 400-500
            {
                _logger.Error()
                    .Message($"Error response from web service {await retVal.Content.ReadAsStringAsync()}")
                    .Properties(eventProperties)
                    .Property("duration", elapsedTime)
                    .Write();
            }
            return retVal;
        }
    }
}
