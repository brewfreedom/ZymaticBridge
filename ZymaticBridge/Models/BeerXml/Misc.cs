using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Misc
    {
        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        public int Version { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("TIME")]
        public int Time { get; set; }

        [XmlElement("USE")]
        public string Use { get; set; }
    }
}
