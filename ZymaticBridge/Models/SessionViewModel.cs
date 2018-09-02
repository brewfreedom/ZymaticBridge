using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZymaticBridge.Models
{
    public class SessionViewModel
    {
        public string user { get; set; }

        public string recipe { get; set; }

        public int code { get; set; }

        public string machine { get; set; }

        public string firmware { get; set; }

        public string data { get; set; }

        public string session { get; set; }

        public int step { get; set; }
    }
}
