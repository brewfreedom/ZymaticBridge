using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Hop
    {
        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        public int Version { get; set; }

        [XmlElement("ALPHA")]
        public decimal Alpha { get; set; }

        [XmlElement("AMOUNT")]
        public decimal Amount { get; set; }

        [XmlElement("USE")]
        public string Use { get; set; }

        [XmlElement("TIME")]
        public int Time { get; set; }
    }
}
