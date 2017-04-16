using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAccessService.EVEXmlAPIService.Models
{
    /// <summary>
    /// http://eveonline-third-party-documentation.readthedocs.io/en/latest/xmlapi/server/serv_serverstatus.html
    /// 
    /// </summary>
    [XmlRoot(ElementName = "eveapi", Namespace = "")]
    public class ServerStatusResponse : ResponseModelBase<ServerStatus>
    {
    }

    public class ServerStatus
    {
        [XmlElement("onlinePlayers")]
        public int OnlinePlayers { get; set; }
        [XmlElement("serverOpen")]
        public bool ServerOpen { get; set; }
    }
}
