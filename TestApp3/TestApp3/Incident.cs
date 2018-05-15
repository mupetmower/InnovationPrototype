using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp3
{
    [Serializable]
    class Incident
    {
        [JsonProperty(PropertyName = "tracking-number")]
        public string tracking_number { get; set; }

        [JsonProperty(PropertyName = "created-timestamp")]
        public string created_timestamp { get; set; }



        public Incident() { }

        public Incident(string tracking_number, string created_timestamp)
        {
            this.tracking_number = tracking_number;
            this.created_timestamp = created_timestamp;
        }
    }
}
