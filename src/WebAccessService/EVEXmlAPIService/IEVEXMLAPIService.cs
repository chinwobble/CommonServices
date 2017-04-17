using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccessService.EVEXmlAPIService.Models;

namespace WebAccessService.EVEXmlAPIService
{
    public interface IEVEXMLAPIService
    {
        Task<ServerStatus> GetServerStatus();
    }
}
