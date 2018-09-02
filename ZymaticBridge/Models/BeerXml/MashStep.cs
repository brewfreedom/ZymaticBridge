using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [XmlType(TypeName="HOP")]
    [Serializable]
    public class MashStep
    {
        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        public int Version { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("STEP_TEMP")]
        public decimal StepTemp { get; set; }

        [XmlElement("STEP_TIME")]
        public decimal StepTime { get; set; }
    }
}
