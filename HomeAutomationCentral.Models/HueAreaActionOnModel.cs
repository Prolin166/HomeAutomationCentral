using Newtonsoft.Json;

namespace HomeAutomationCentral.Models
{
    public class HueAreaActionOnModel
    {

        [JsonProperty("on")]
        public bool On { get; set; }

    }
}

