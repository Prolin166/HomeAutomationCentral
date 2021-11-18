using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;


namespace HomeAutomationCentral.Models
{

    public class HueLightModel
    {
        public int ID { get; set; }
        [JsonProperty("state")]
        public HueLightModelState State {get; set;}
        [JsonProperty("swupdate")]
        public Swupdate Swupdate {get; set;}
        [JsonProperty("type")]
        public string Type {get; set;}
        [JsonProperty("name")]
        public string Name {get; set;}
        [JsonProperty("modelid")]
        public string Modelid {get; set;}
        [JsonProperty("manufacturername")]
        public string Manufacturername {get; set;}
        [JsonProperty("productname")]
        public string Productname {get; set;}
        [JsonProperty("capabilities")]
        public Capabilities Capabilities {get; set;}
        [JsonProperty("config")]
        public Config Config {get; set;}
        [JsonProperty("uniqueid")]
        public string Uniqueid {get; set;}
        [JsonProperty("swversion")]
        public string Swversion {get; set;}
    }

    public class HueLightModelState
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

    public class Swupdate 
    {
        [JsonProperty("state")]
        public string State {get; set;}
        [JsonProperty("lastinstall")]
        public DateTime Lastinstall {get; set;}
    }

    public class Capabilities 
    {
        [JsonProperty("certified")]
        public bool Certified {get; set;}
        [JsonProperty("control")]
        public Control Control {get; set;}
        [JsonProperty("streaming")]
        public Streaming Streaming {get; set;}
    }

    public class Control 
    {
        [JsonProperty("colorgamuttype")]
        public string Colorgamuttype {get; set;}
        [JsonProperty("colorgamut")]
        public IList<ArrayList> Colorgamuts {get; set;}
        [JsonProperty("ct")]
        public Ct Ct {get; set;}
    }

    public class Ct 
    {
        [JsonProperty("min")]
        public int Min {get; set;}
        [JsonProperty("max")]
        public int Max {get; set;}
    }

    public class Streaming 
    {
        [JsonProperty("renderer")]
        public bool Renderer {get; set;}
        [JsonProperty("proxy")]
        public bool Proxy {get; set;}
    }

    public class Config 
    {
        [JsonProperty("archetype")]
        public string Archetype {get; set;}
        [JsonProperty("function")]
        public string Function {get; set;}
        [JsonProperty("direction")]
        public string Direction {get; set;}
    }
}
