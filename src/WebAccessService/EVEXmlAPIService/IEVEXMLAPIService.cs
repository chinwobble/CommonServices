using System.Threading.Tasks;
using WebAccessService.EVEXmlAPIService.Models;

namespace WebAccessService.EVEXmlAPIService
{
    public interface IEVEXMLAPIService
    {
        Task<ServerStatus> GetServerStatus();
    }
}
