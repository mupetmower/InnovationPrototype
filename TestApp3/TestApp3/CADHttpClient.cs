using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace TestApp3
{
    /// <summary>
    /// Uses CADConnection to send request to other RESTful endpoints in order to create, update,
    /// and query incidents, etc. App will use this to build new incidents for Alert situations.
    /// </summary>
    class CADHttpClient
    {
        //Eventually will need to get user information like name, location(from phone GPS), etc from
        //the phone and app's settings page

        /// <summary>
        /// Number in string format that is used for every api call to created incident
        /// </summary>
        private string incidentTrackingNumber;
        
        private CADConnection cadConnection;



        public CADHttpClient() { }

        /// <summary>
        /// Send Authentication. If Authentication fails, FUTURE - use normal 911 dails, alert user to use 911, etc
        /// </summary>
        public void Connect()
        {
            cadConnection = new CADConnection();

            bool isAuthenticated = cadConnection.Authenticate();

            //Future - If auth fails, need to have next steps, such as alert user to use 911, automatically use
            //911 dial instead, etc
            if (!isAuthenticated)
                throw new Exception("Authentication Fialed.");
            
        }


        /// <summary>
        /// Send GET to /incidents with NewIncident Object. If GET succeeds, this will set a tracking number for the new 
        /// incident which will be used in incident updates, etc
        /// </summary>
        public IncidentResponse SendIncident(NewIncident newIncident)
        {
            string incidentUri = cadConnection.BuildRestUri(CADRestAPI.INCIDENTS);
            HttpWebRequest request = cadConnection.GetNewPostRequest(incidentUri);
            string response = cadConnection.SendPostRequest(request, newIncident);

            IncidentResponse incidentResponse = JsonConvert.DeserializeObject<IncidentResponse>(response);
            incidentTrackingNumber = incidentResponse.incident.tracking_number;
            return incidentResponse;
        }


        //FUTURE - talk to someone about whether this and other similar methods are better suited to be in CADConnection
        //or another class alltogether
        public IncidentResponse GetIncident(string trackingNumber)
        {
            string incidentUri = cadConnection.BuildRestUri(CADRestAPI.INCIDENTS);

            //FUTURE - find a way to add this in a better way
            incidentUri += "/" + trackingNumber;

            //FUTURE - need to make sure username is same that is used for auth
            //FUTURE - need to figure out why we are needing to use deprecated=true when we are not supposed to be using it
            //FUTURE - find a way to add this in a better way
            incidentUri += "?username=superuser&deprecated=true";

            HttpWebRequest request = cadConnection.GetNewGetRequest(incidentUri);
            
            string response = cadConnection.SendGetRequest(request);

            IncidentResponse incidentResponse = JsonConvert.DeserializeObject<IncidentResponse>(response);


            return incidentResponse;
        }

        /// <summary>
        /// Create a NewIncident Object for use with SendIncident()
        /// </summary>
        //FUTURE - add method params for NewIncident params
        public NewIncident CreateIncident()
        {
            //FUTURE - will need to get info from user settings and phone
            return null;
        }



        public NewIncident CreateTestIncident()
        {
            NewIncident newIncident = new NewIncident("superuser", "testCity-AF", "testCaller-AF", "RUN");

            return newIncident;
        }

    }
}
