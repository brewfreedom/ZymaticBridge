using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    public class Yeasts
    {
        [XmlElement("YEAST")]
        public List<Yeast> Collection { get; set; }
    }
}
