using System.Collections.Generic;
using System.Xml.Serialization;

namespace WebAccessService.EVEXmlAPIService.Models
{
    public class IEVEXmlRowset<TRowItem> : IEVEXmlResult
        where TRowItem : IEVEXmlResultRow
    {
        [XmlArray("rowset")]
        [XmlArrayItem("row")]
        public List<TRowItem> RowSet { get; set; }
    }
}
