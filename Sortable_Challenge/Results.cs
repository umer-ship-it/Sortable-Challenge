using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Sortable_Challenge
{
    class Results
    {
        [JsonProperty]
        public string Product_name { get; set; }


        [JsonProperty]
        public List<string> listing { get; set; }

    }
}
