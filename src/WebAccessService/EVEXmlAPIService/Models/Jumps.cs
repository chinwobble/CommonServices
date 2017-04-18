using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAccessService.EVEXmlAPIService.Models
{
    public class Jumps : IEVEXmlResultRow
    {
        [XmlAttribute(AttributeName = "solarSystemID")]
        public int SolarSystemID { get; set; }
        [XmlAttribute(AttributeName = "shipJumps")]
        public string ShipJumps { get; set; }
    }
}
