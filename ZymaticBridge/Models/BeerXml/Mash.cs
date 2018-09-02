using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Mash
    {
        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        public int Version { get; set; }

        [XmlElement("GRAIN_TEMP")]
        public decimal GrainTemps { get; set; }

        [XmlElement("MASH_STEPS")]
        public MashSteps MashSteps { get; set; }

    }
}
