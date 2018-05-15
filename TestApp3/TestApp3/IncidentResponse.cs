using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp3
{
    [Serializable]
    class IncidentResponse
    {

        [JsonProperty(PropertyName = "incident")]
        public Incident incident { get; set; }

        [JsonProperty(PropertyName = "license-plate")]
        public string license_plate { get; set; }


        public IncidentResponse() { }

    }
}
