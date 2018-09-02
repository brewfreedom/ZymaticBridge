using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Style
    {
        [XmlElement("CATEGORY_NUMBER")]
        public int CategoryNumber { get; set; }
         
        [XmlElement("STYLE_LETTER")]
        public string StyleLetter { get; set; }


        [XmlElement("NAME")]
        public string Name { get; set; }
         
        [XmlElement("VERSION")]
        public int Version { get; set; }
         
        [XmlElement("STYLE_GUIDE")]
        public string StyleGuide { get; set; }
         
        [XmlElement("OG_MIN")]
        public decimal OGMin { get; set; }

        [XmlElement("OG_MAX")]
        public decimal OGMax { get; set; }


        [XmlElement("FG_MIN")]
        public decimal FGMin { get; set; }

        [XmlElement("FG_MAX")]
        public decimal FGMax { get; set; }

        [XmlElement("IBU_MIN")]
        public int IBUMin { get; set; }

        [XmlElement("IBU_MAX")]
        public int IBUMax { get; set; }

        [XmlElement("COLOR_MIN")]
        public int ColorMin { get; set; }

        [XmlElement("COLOR_MAX")]
        public int ColorMax { get; set; }
    }
}
