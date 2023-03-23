using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Diagnostics;

public partial class FCM_FCM_TS01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SendNotification("123456789", "test Msg");
    }
    protected string SendNotification(string deviceId, string message)
    {
        string resultStr = "";
       
            //string SERVER_API_KEY = "API KEY STRING";
            string SERVER_API_KEY = "AAAAU4M_kRI:APA91bHx6SVffGd-4AABBKK5b3gsQNzAtlfzl-p_4rCfZE0YnXbBk0f2fWZxHdbNbL_IapMg5XVBsqFQG1Wnrt8tR-lX2R10mTeUaIIOr6xT8fd0DmGa6T6EePEHrfsUKeaPJ-ZccMLH";
            var value = message;
           

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8;";
            request.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));

            var postData =
                 new
                 {
                     data = new
                     {
                         title = "TEST AS APP",
                         body = message,
                     },

                 // FCM allows 1000 connections in parallel.
                 to = deviceId
                 };

            //Linq to json
            string contentMsg = JsonConvert.SerializeObject(postData);
            Debug.WriteLine("contentMsg = " + contentMsg);

            Byte[] byteArray = Encoding.UTF8.GetBytes(contentMsg);
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            try
            {
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                resultStr = reader.ReadToEnd();
                Debug.WriteLine("response: " + resultStr);
                reader.Close();
                responseStream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                resultStr = "";
                Debug.WriteLine(e.Message);
            }

            return resultStr;
       
      

    }
}