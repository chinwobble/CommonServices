using System.Threading.Tasks;

namespace WebAccessService.Common
{
    public interface IHttpClientWrapper
    {
        Task<T> GetAsync<T>(string url);

    }
}
