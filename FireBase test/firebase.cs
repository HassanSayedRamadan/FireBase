using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FireBase_test
{
    public class firebase
    {
        public firebase()
        {

        }
        public void SendNotification()
        {
            try
            {
                var tokenList = new List<string>()
                {
                    //List of client tokens
                };

                string json, sResponseFromServer;
                Byte[] byteArray;
                WebRequest tRequest;
                Stream dataStream;
                WebResponse tResponse;
                StreamReader tReader;

                foreach (var token in tokenList)
                {
                    dynamic data = new
                    {
                        to = token, // Uncoment this if you want to test for single device
                                    // registration_ids = singlebatch, // this is for multiple user 
                        notification = new
                        {
                            title = "Notification Title",     // 
                            body = "Notification Body",    // Notification body data
                        }
                    };


                    json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    byteArray = System.Text.Encoding.UTF8.GetBytes(json);

                    string SERVER_API_KEY = "Your API Key";
                    string SENDER_ID = "Your Sender Id";

                    tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = "application/json";
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));

                    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                    tRequest.ContentLength = byteArray.Length;
                    dataStream = tRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();

                    tResponse = tRequest.GetResponse();

                    dataStream = tResponse.GetResponseStream();

                    tReader = new StreamReader(dataStream);

                    sResponseFromServer = tReader.ReadToEnd();

                    tReader.Close();
                    dataStream.Close();
                    tResponse.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
