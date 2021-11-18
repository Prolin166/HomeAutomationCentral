using Newtonsoft.Json;
using System.Collections.Generic;

namespace HomeAutomationCentral.Models
{ 

    public class HueAreaModel 
    {
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name {get; set;}
        [JsonProperty("lights")]
        public IList<string> Lights {get; set;}
        [JsonProperty("sensors")]
        public IList<Sensors> Sensors {get; set;}
        [JsonProperty("type")]
        public string Type {get; set;}
        [JsonProperty("state")]
        public State State {get; set;}
        [JsonProperty("recycle")]
        public bool Recycle {get; set;}
        [JsonProperty("class")]
        public string Class {get; set;}
        [JsonProperty("action")]
        public Action Action {get; set;}
    }

    public class Sensors 
    {

    }

    public class State 
    {
        [JsonProperty("all_on")]
        public bool AllOn {get; set;}
        [JsonProperty("any_on")]
        public bool AnyOn {get; set;}
    }

    public class Action 
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
    }
}
