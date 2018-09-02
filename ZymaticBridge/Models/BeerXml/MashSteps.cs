using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class MashSteps 
    {
        [XmlElement("MASH_STEP")]
        public List<MashStep> Steps { get; set; }
    }
}
