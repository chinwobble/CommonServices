using RateLimiter;
using System.Net.Http;
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
