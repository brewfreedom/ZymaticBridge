using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable,XmlRoot("RECIPES",Namespace ="")]
    public class Recipes
    {
        [XmlElement("RECIPE")]
        public Recipe Recipe { get; set; }
    }
}
