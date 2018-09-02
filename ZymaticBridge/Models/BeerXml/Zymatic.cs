using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Zymatic
    {
        [XmlElement("MASH_TEMP")]
        public int MashTemp { get; set; }

        [XmlElement("MASH_TIME")]
        public int MashTime { get; set; }

        [XmlElement("BOIL_TEMP")]
        public int BoilTemp { get; set; }

        [XmlElement("STEP")]
        public List<Step> Step {get; set;}
    }
}
