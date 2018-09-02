using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZymaticBridge.Models.BeerXml;

namespace ZymaticBridge.Models
{
    public class BrewSession
    {
        public Recipe Recipe { get; internal set; }

        public string SessionId { get; internal set; }

        public int CurrentStep { get; set; }

        public List<String> DataReadings { get; set; }

        public BrewSession(Recipe recipe)
        {
            Guid sessionGuid = Guid.NewGuid();

            Recipe = recipe;

            var md5 = System.Security.Cryptography.MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(sessionGuid.ToString()));

            StringBuilder sb = new StringBuilder();

            sb.Append("#");

            foreach (var h in hash)
            {
                sb.Append(h.ToString("X2"));
            }

            sb.Append("#"); 


            SessionId = sb.ToString();
        }

    }
}
