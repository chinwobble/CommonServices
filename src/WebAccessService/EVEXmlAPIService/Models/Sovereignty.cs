using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WebAccessService.EVEXmlAPIService.Models
{
    /// <summary>
    /// http://eveonline-third-party-documentation.readthedocs.io/en/latest/xmlapi/map/map_sovereignty.html
    /// </summary>
    public class Sovereignty : IEVEXmlResultRow
    {
        [XmlAttribute("solarSystemID")]
        public int solarSystemId { get; set; }
        [XmlAttribute("allianceID")]
        public int AllianceId { get; set; }
        [XmlAttribute("factionID")]
        public int FactionId { get; set; }
        [XmlAttribute("solarSystemName")]
        public string SolarSystemName { get; set; }
        [XmlAttribute("corporationID")]
        public int CorporationId { get; set; }
    }
}
