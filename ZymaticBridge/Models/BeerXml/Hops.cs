using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Hops
    {
        [XmlElement("HOP")]
        public List<Hop> Collection { get; set; }
    }
}
