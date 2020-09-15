using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_Challenge
{
    class ProjectCreateResponse
    {
        public class Root
        {
            public string expand { get; set; }
            public string self { get; set; }
            public string id { get; set; }
            public string key { get; set; }
            public string description { get; set; }
            public Lead lead { get; set; }
        }
        public class Lead
        {
            public string self { get; set; }
            public string key { get; set; }
            public string name { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
        }


    }
}
