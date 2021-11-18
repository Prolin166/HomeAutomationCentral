using Newtonsoft.Json;
using System.Collections.Generic;

namespace HomeAutomationCentral.Models
{
   
    public class HueLightStateModel 
    {
        [JsonProperty("on")]
        public bool On {get; set;}
        [JsonProperty("bri")]
        public int Bri {get; set;}
        [JsonProperty("hue")]
        public int Hue {get; set;}
        [JsonProperty("sat")]
        public int Sat {get; set;}
        [JsonProperty("effect")]
        public string Effect {get; set;}
        [JsonProperty("xy")]
        public IList<float> Xys {get; set;}
        [JsonProperty("ct")]
        public int Ct {get; set;}
        [JsonProperty("alert")]
        public string Alert {get; set;}
        [JsonProperty("colormode")]
        public string Colormode {get; set;}
        [JsonProperty("mode")]
        public string Mode {get; set;}
        [JsonProperty("reachable")]
        public bool Reachable {get; set;}
    }
}
