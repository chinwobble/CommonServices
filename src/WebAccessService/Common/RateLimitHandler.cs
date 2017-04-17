using RateLimiter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebAccessService.Common
{
    public class RateLimitHandler : DelegatingHandler
    {
        private readonly IRateLimiter _rateLimiter;

        public RateLimitHandler(IRateLimiter rateLimiter)
        {
            _rateLimiter = rateLimiter;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await _rateLimiter.Perform(() => base.SendAsync(request, cancellationToken));
        }
    }
}
