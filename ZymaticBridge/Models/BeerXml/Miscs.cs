using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Miscs
    {
        [XmlElement("MISC")]
        public List<Misc> Collection { get; set; }
    }
}
