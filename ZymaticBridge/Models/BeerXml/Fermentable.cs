using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Fermentable
    {
        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        public int Version { get; set; }

        [XmlElement("AMOUNT")]
        public decimal Amount { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("YIELD")]
        public decimal Yield { get; set; }

        [XmlElement("COLOR")]
        public decimal Color { get; set; }
    }
}
