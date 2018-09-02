using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZymaticBridge.Models.BeerXml
{
    [Serializable]
    public class Recipe
    {
        [XmlElement("VERSION")]
        public int Version { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("BREWER")]
        public string Brewer { get; set; }

        [XmlElement("BATCH_SIZE")]
        public decimal BatchSize { get; set; }

        [XmlElement("BOIL_SIZE")]
        public decimal BoilSize { get; set; }

        [XmlElement("BOIL_TIME")]
        public int BoilTime { get; set; }

        [XmlElement("EFFICIENCY")]
        public int Efficiency { get; set; }

        [XmlElement("TASTE_NOTES")]
        public string TaseNotes { get; set; }

        [XmlElement("DATE")]
        public string Date { get; set; }
         

        [XmlElement("OG")]
        public decimal OG { get; set; }


        [XmlElement("FG")]
        public decimal FG { get; set; }


        [XmlElement("IBU")]
        public int IBU { get; set; }


        [XmlElement("EST_COLOR")]
        public int EstColor { get; set; }

        [XmlElement("EST_ABV")]
        public decimal EstAbv { get; set; }


        [XmlElement("PRIMARY_AGE")]
        public int PrimaryAge { get; set; }


        [XmlElement("PRIMARY_TEMP")]
        public decimal PrimaryTemp { get; set; }

        [XmlElement("FERMENTATION_STAGES")]
        public int FermentationStages { get; set; }


        [XmlElement("STYLE")]
        public Style Style { get; set; }

        [XmlElement("NOTES")]
        public string Notes { get; set; }

        [XmlElement("ZYMATIC")]
        public Zymatic Zymatic { get; set; }


        [XmlElement("MASH")]
        public Mash Mash { get; set; }
         
        [XmlElement("HOPS")]
        public Hops Hops { get; set; }

        [XmlElement("WATERS")]
        public Waters Waters { get; set; }

        [XmlElement("FERMENTABLES")]
        public Fermentables Fermentables { get; set; }
         
        [XmlElement("YEASTS")]
        public Yeasts Yeasts { get; set; }

        [XmlElement("MISCS")]
        public Miscs Miscs { get; set; }

        //Not implementing Kegsmart


        [XmlElement("NAME")]
        public string Name { get; set; }
        public string Hash { get;  set; }



        public override string ToString()
        {
            //#Motueka Dark Ale/8f085361e36643ea89bfefd9d08bf60f/Heat to Temp,102,0,0,0/Dough In,102,20,1,8/Heat to Mash,152,0,0,0/Mash 1,152,30,1,8/Mash 2,154,60,1,8/Heat to MO,175,0,0,0/Mash Out,175,10,1,10/Heat to Boil,207,0,0,0/Boil Adjunct 1,207,30,2,0/Boil Adjunct 2,207,20,3,0/Boil Adjunct 3,207,10,4,5/Connect Chiller,0,0,6,0/Chill,65,10,0,10/|Pico Pale Ale/b7f69fad72494b99a1978fff6c0f9bf0/Heat Water,152,0,0,0/Mash,152,90,1,8/Heat to Boil,207,0,0,0/Boil Adjunct 1,207,45,2,0/Boil Adjunct 2,207,5,3,0/Boil Adjunct 3,207,5,4,0/Boil Adjunct 4,207,5,5,5/Connect Chiller,70,0,6,0/Chill,70,10,0,10/|Polaris Single Hop/1877ea832ea64b29860fc52454305203/Heat Water,152,0,0,0/Mash,152,90,1,8/Heat to Boil,207,0,0,0/Boil Adjunct 1,207,30,2,0/Boil Adjunct 2,207,25,3,0/Boil Adjunct 3,207,5,4,5/Connect Chiller,0,0,6,0/Chill,65,10,0,10/|#
            //# RECIPE_NAME / HASH on Picobrew.com / STEP_NAME, TEMPERATURE, DURATION, COMPARTMENT , DRAIN / |#

            StringBuilder builder = new StringBuilder();

            builder.Append(string.Format("#{0}/{1}/",
                        Name,
                        Hash));

            foreach(var step in Zymatic.Step)
            {
                builder.Append(string.Format("{0},{1},{2},{3}/",
                                step.Name,
                                step.Temp,
                                step.Time,
                                step.Location,
                                step.Drain
                    ));
            }

            builder.Append("|#");

            return builder.ToString();
        }
    }
}
