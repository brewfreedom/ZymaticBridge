using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ZymaticBridge.Models.BeerXml;

namespace Tests
{
    [TestClass]
    public class BeerXmlTests
    {
        [TestMethod]
        public void TestImport()
        { 

            var xmlSerializer  = new XmlSerializer(typeof(Recipes));
              
            var xmlReader = XmlReader.Create(@"C:\PicoBrew\ZymaticBridge\Recipes\Helluva+Heffe+v1.xml");

            var recipes = xmlSerializer.Deserialize(xmlReader) as Recipes;

        }
    }
}
