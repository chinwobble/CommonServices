using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAccessService.EVEXmlAPIService.Models
{
    [XmlRoot(ElementName = "eveapi", Namespace = "")]
    public class ResponseWrapper<T> where
        T : IEVEXMLResponseResult
    {
        [XmlAttribute("version")]
        public int Version { get; set; }
        [XmlElement("result")]
        public T Result { get; set; }
        [XmlAttribute("cachedUntil")]
        public DateTime CachedUntil { get; set; }
        [XmlAttribute("currentTime")]
        public DateTime CurrentTime { get; set; }
    }
}
