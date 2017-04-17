using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            var startTime = DateTime.UtcNow;
            var result = await base.SendAsync(request, cancellationToken);

            var endTime = DateTime.UtcNow;
            var elapsedTime = (startTime - endTime).Duration();
            _logger.Info(request.RequestUri + $"finished in {elapsedTime}");
            return result;
        }
    }
}
