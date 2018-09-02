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
            string s = "4406c30c181a4f918ff3f091d64d84a3";



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


           
 
            Console.WriteLine("Your Zymatic should now be able to brew freely. Remember to set your router's DNS for www.picobrew.com to the IP address in appsettings.json \"urls\".");
        }

        //TODO: make this easy to config for users 
        //allong with reserving the port/ip. for folks running IIS on a dev rig sorry.
        public static IWebHost BuildWebHost(string[] args)
        {
          

            string urlConfig = _Configuration["urls"];

            var webHost = WebHost.CreateDefaultBuilder(args)
       

            .UseKestrel((options) =>
            {
                IPAddress ipAddress = null;
                IPAddress.TryParse("192.168.1.192", out ipAddress);
                options.Listen(ipAddress, 80, listenOptions =>
                {

                    listenOptions.UseConnectionLogging();
                });

            })

            .UseStartup<Startup>();

           

            return webHost.Build();
        }
    }
}
