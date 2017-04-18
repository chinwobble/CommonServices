using System.Xml.Serialization;

namespace WebAccessService.EVEXmlAPIService.Models
{
    public class Kills : IEVEXmlResultRow
    {
        [XmlAttribute(AttributeName = "solarSystemID")]
        public int SolarSystemID { get; set; }
        [XmlAttribute(AttributeName = "shipKills")]
        public int ShipKills { get; set; }
        [XmlAttribute(AttributeName = "factionKills")]
        public int FactionKills { get; set; }
        [XmlAttribute(AttributeName = "podKills")]
        public int PodKills { get; set; }
    }
}
