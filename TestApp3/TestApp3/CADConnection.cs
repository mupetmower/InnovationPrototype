using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace TestApp3
{
    /// <summary>
    /// Hits CAD's REST Service endpoints
    /// </summary>
    class CADConnection
    {
        //For future use
        private string cadRestServiceIP = "";           //192.168.254.84
        private string cadRestServicePort = "";         //9002
        private string cadRestServiceApiName = "";      //api
        private string cadRestServiceVersion = "";      //v1

        //The API Uri used for testing
        private const string API_BASE_URI = "http://192.168.254.84:9002/api/v1/";

        //The CAD username@tenant and password used for testing
        private const string USERNAME = "superuser@Default";
        private const string PASSWORD = "interact!";
        
        //Token used for all Requests
        private string authenticationToken;

        

        public CADConnection() { }


        public HttpWebRequest GetNewGetRequest(string uriString)
        {
            HttpWebRequest request = WebRequest.CreateHttp(uriString);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", authenticationToken);
            return request;
        }

        public HttpWebRequest GetNewPostRequest(string uriString)
        {
            HttpWebRequest request = WebRequest.CreateHttp(uriString);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", authenticationToken);
            return request;
        }

        public string SendGetRequest(HttpWebRequest request)
        {
            string response = ReadResponseAsString(request.GetResponse().GetResponseStream());
            return response;
        }

        public string SendPostRequest(HttpWebRequest request)
        {
            string response = ReadResponseAsString(request.GetResponse().GetResponseStream());
            return response;
        }

        public string SendPostRequest<T>(HttpWebRequest request, T body)
        {
            string bodyString = JsonConvert.SerializeObject(body);
            HttpWebRequest _request = AddPostBody(request, bodyString);
            string response = ReadResponseAsString(_request.GetResponse().GetResponseStream());
            return response;
        }

        public Stream SendPostRequest(HttpWebRequest request, Dictionary<string, string> body)
        {
            return null;
        }

        public HttpWebRequest AddPostBody(HttpWebRequest request, string bodyString)
        {
            var data = Encoding.ASCII.GetBytes(bodyString);
            request.ContentLength = data.Length;
            var newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();


            return request;
        }

        public HttpWebRequest AddPostBody(HttpWebRequest request, Dictionary<string, string> bodyData)
        {
            //Create body as string from dictionary
            string stringData = "{{";

            int i = 0;
            foreach (var item in bodyData) {
                stringData += string.Format("{{\"{0}\":\"{1}\"}}", item.Key, item.Value);

                if (i < bodyData.Count - 1)
                    stringData += ",";
                i++;
            }
            
            stringData += "}}";

            Console.WriteLine("stringData = " + stringData);

            var data = Encoding.ASCII.GetBytes(stringData);
            //Add to Request body
            request.ContentLength = data.Length;
            var newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();


            return request;
        }


        public string ReadResponseAsString(Stream response)
        {
            using (StreamReader readStream = new StreamReader(response))
            {
                return readStream.ReadToEnd();
            }
        }

        public string BuildRestUri(string endpoint)
        {
            //Future - API_BASE_URI may change to whatever Uri is built with user/config given info
            return API_BASE_URI + endpoint;
        }

        /// <summary>
        /// Send a POST to /auth to receive authorization token for other calls
        /// </summary>
        public bool Authenticate()
        {            
            try
            {
                string authUri = BuildRestUri(CADRestAPI.AUTHENTICATION);
                HttpWebRequest request = WebRequest.CreateHttp(authUri);

                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                
                //Create credentials for body, encode it to byte
                string stringData = string.Format("{{\"username\":\"{0}\",\"password\":\"{1}\"}}", USERNAME, PASSWORD);
                var data = Encoding.ASCII.GetBytes(stringData);
                //Add to Request body
                request.ContentLength = data.Length;                
                var newStream = request.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                //Take response as stream and read it
                string response = "";
                using (StreamReader readStream = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    response = readStream.ReadToEnd();
                }
                
                //Deserialize response into dynamic object and get ssoTokenId
                dynamic auth = JsonConvert.DeserializeObject(response);                
                string authToken = auth.ssoTokenId;

                //Send
                if (Boolean.TryParse(TestAuthentication(authToken), out bool isAuth))
                    return isAuth;
                
                
                return false;
                
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }

            return false;
        }

        /// <summary>
        /// Send a GET to /auth to test that authentication token works
        /// </summary>
        private string TestAuthentication(string authToken)
        {
            string authUri = BuildRestUri(CADRestAPI.AUTHENTICATION);
            HttpWebRequest request = WebRequest.CreateHttp(authUri);

            request.Method = "GET";

            request.Headers.Add("Authorization", authToken);
            request.ContentType = "application/json";
            request.Accept = "application/json";
                        
            string response = "";
            using (StreamReader readStream = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                response = readStream.ReadToEnd();
            }

            authenticationToken = authToken;

            return response;

        }


    }
}
