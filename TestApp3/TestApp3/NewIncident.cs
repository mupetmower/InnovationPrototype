using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp3
{
    /// <summary>
    /// Incident Object. FUTURE - only has required fields for now, will add others later.
    /// </summary>
    [Serializable]
    class NewIncident
    {
        //FUTURE - could get from user settings
        [JsonProperty("caller-first-name")]
        public string caller_first_name { get; set; }
        //public string caller_last_name { get; set; }
        //public string caller { get; set; }
        //public string caller_callback_phone { get; set; }
        //public string caller_location_info { get; set; }
        public bool scheduled { get; set; }
        

        //REQUIRED FIELDS

        //FUTURE - could get from phone location
        public string city { get; set; }
        public string address { get; set; }


        [JsonProperty("location-info")]
        public string location_info { get; set; }
        //FUTURE - posibly have new user created in DB for this app's use.. then default this to
        //that username. Example - firstalertuser
        public string username { get; set; }

        [JsonProperty("caller-phone")]
        public string caller_phone { get; set; }


        [JsonProperty("event-code")]
        public string event_code { get; set; }



        public NewIncident() { }


        public NewIncident(string username, string city, string event_code)
        {
            this.username = username;
            this.city = city;
            this.event_code = event_code;
        }

        public NewIncident(string username, string city, string caller_first_name, string event_code, string location_info, string address, string caller_phone)
        {
            this.username = username;
            this.city = city;
            this.caller_first_name = caller_first_name;
            this.event_code = event_code;
            this.location_info = location_info;
            this.address = address;
            this.caller_phone = caller_phone;
        }


    }
}
