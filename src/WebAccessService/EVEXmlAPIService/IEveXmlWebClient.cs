using System.Collections.Generic;
using System.Threading.Tasks;
using WebAccessService.EVEXmlAPIService.Models;

namespace WebAccessService.EVEXmlAPIService
{
    public interface IEveXmlWebClient
    {
        Task<ServerStatus> GetServerStatus();
        Task<List<Sovereignty>> GetSovereignty();
        Task<List<Jumps>> GetJumps();
        Task<List<Kills>> GetKills();
    }
}
