﻿using System.Xml.Serialization;

namespace WebAccessService.EVEXmlAPIService.Models
{
    /// <summary>
    /// http://eveonline-third-party-documentation.readthedocs.io/en/latest/xmlapi/server/serv_serverstatus.html
    /// </summary>
    public class ServerStatus : IEVEXmlResult
    {
        [XmlElement("onlinePlayers")]
        public int OnlinePlayers { get; set; }
        [XmlElement("serverOpen")]
        public string ServerOpen
        { 
            set { _serverOpen = bool.Parse(value.ToLower()); }
            get { return _serverOpen.ToString(); }
        }
        /// <summary>
        /// backing field required because the api returns Pascal case boolean text which is not valid xml
        /// </summary>
        private bool _serverOpen;
    }
}
