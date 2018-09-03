using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ZymaticBridge
{
    public class Program
    {
        private static IConfiguration _Configuration;

        public static void Main(string[] args)
        {
           

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _Configuration = builder.Build();

            string recipes = _Configuration["RecipesFolder"];

            if (!string.IsNullOrWhiteSpace(recipes))
            {
                Console.WriteLine("Initializing Recipe Library");

                RecipeLoader.LoadRecipes(recipes);
            }


            Console.WriteLine("Initializing hosting.");

            BuildWebHost(args).Run();
             
 
        }
         
        public static IWebHost BuildWebHost(string[] args)
        {
           

            var webHost = WebHost.CreateDefaultBuilder(args) 
            .UseKestrel()
            .UseConfiguration(_Configuration)
            .UseStartup<Startup>();

            Console.WriteLine("Your Zymatic should now be able to brew freely. Remember to set your router's DNS for www.picobrew.com to the IP address in appsettings.json \"urls\".");


            return webHost.Build();
        }
    }
}
