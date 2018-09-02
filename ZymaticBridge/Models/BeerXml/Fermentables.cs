using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Fermentables
    {
        [XmlElement("FERMENTABLE")]
        public List<Fermentable> Collections { get; set; }
    }
}
