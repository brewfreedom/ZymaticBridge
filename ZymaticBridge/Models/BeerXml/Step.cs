using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Step
    {
        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("TEMP")]
        public int Temp { get; set; }

        [XmlElement("TIME")]
        public int Time { get; set; }

        [XmlElement("LOCATION")]
        public int Location { get; set; }

        [XmlElement("DRAIN")]
        public int Drain { get; set; }
    }
}
