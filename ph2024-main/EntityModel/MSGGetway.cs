using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public partial class Msg91
    {
        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("route")]
        public string Route { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sms")]
        public List<Sm> Sms { get; set; }

        
    }

    public partial class Sm
    {
        public string PersonalID { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("to")]
        public List<string> To { get; set; }
    }
}
