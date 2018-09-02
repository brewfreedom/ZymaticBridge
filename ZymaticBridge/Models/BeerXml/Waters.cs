using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Waters
    {
        [XmlElement("WATER")]
        public List<Water> Collection { get; set; }
    }
}
