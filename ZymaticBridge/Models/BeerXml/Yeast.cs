using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    public class Yeast
    {
        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        public int Version { get; set; }

        [XmlElement("AMOUNT")]
        public int Amount { get; set; }

        [XmlElement("FORM")]
        public string Form { get; set; }

        [XmlElement("LABORATORY")]
        public string Laboratory { get; set; }

        [XmlElement("PRODUCT_ID")]
        public string ProductId { get; set;  }

        [XmlElement("MIN_TEMPERATURE")]
        public string MinTemperature { get; set; }

        [XmlElement("MAX_TEMPERATURE")]
        public string MaxTemperature { get; set; }

        [XmlElement("ATTENUATION")]
        public int Attenuation { get; set; }

        [XmlElement("FLOCCULATION")]
        public string Flocculation { get; set; }

    }
}
