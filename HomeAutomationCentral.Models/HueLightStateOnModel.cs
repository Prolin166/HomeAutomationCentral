using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HomeAutomationCentral.Models
{
    public class HueLightStateOnModel
    {

        [JsonProperty("on")]
        public bool On { get; set; }

    }
}

