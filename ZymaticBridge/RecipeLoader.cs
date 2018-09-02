using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZymaticBridge.Models.BeerXml;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text;

namespace ZymaticBridge
{
    public class RecipeLoader
    {
        private static List<Recipe> _Recipes;

        public static List<Recipe> Recipes
        {
            get
            {
                return _Recipes;
            }
        }

        /// <summary>
        /// Keeping this stupid simple for now. You export your receipes and throw them into a folder.
        /// DB support down the road if there is demand
        /// </summary>
        /// <param name="recipePath"></param>
        /// <returns></returns>
        public static void LoadRecipes(string recipePath)
        {
            _Recipes = new List<Recipe>();

            var md5 = System.Security.Cryptography.MD5.Create();

            DirectoryInfo recipeDir = new DirectoryInfo(recipePath);
            FileInfo[] files = recipeDir.GetFiles("*.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(Recipes));

            foreach (FileInfo file in files)
            {
                using (var reader = XmlReader.Create(file.FullName))
                {
                    var recipe = serializer.Deserialize(reader) as Recipes;

                    if(recipe!=null)
                    {
                        var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(recipe.Recipe.Name));

                        StringBuilder sb = new StringBuilder();

                        foreach (var h in hash)
                        {
                            sb.Append(h.ToString("X2"));
                        }

                        recipe.Recipe.Hash = sb.ToString();

                        _Recipes.Add(recipe.Recipe);
                    }
                }
            }
             
        }
    }
}
