using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using aSIMS;

public partial class RemoteData_GET_Remote_Ts01 : System.Web.UI.Page
{
    const string KEY = "nfactor!planemo!nfactor!planemo!";
    public static string RequestBody()
    {
        StreamReader bodyStream = new StreamReader(HttpContext.Current.Request.InputStream);
        bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
        string bodyText = bodyStream.ReadToEnd();
        return bodyText;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        String requestData = RequestBody();
        string Message = string.Empty;

        requestData = SecurityHelper.AES256Decrypt(HttpUtility.UrlDecode(requestData), KEY);
        StringBuilder inputData = new StringBuilder(requestData);
        if (requestData != string.Empty && requestData != "")
        {
            SAMAuthData_Param_ConnVO tokenCheck = JsonHelper.Deserialize<SAMAuthData_Param_ConnVO>(requestData);

            if (string.IsNullOrEmpty(tokenCheck.USERID) || string.IsNullOrEmpty(tokenCheck.TIMESTAMP) || tokenCheck.USERID != "GIT")
                Response.Write(SecurityHelper.AES256Encrypt("reader.parser. error : ", KEY));
            else
            {
                if (tokenCheck.cmd == "2")
                {
                    //requestData = SecurityHelper.AES256Decrypt(requestData, KEY);
                    Log(requestData);

                    // Create a request using a URL that can receive a post.
                    //  WebRequest request = WebRequest.Create("http://gsup.gitauto.com/ASIMS/sam_auth.aspx");
                    WebRequest request = WebRequest.Create("http://172.27.122.196:8080/ASIMS/sam_auth.aspx");
                    // Set the Method property of the request to POST.
                    request.Method = "POST";

                    // Create POST data and convert it to a byte array.
                    string postData = "YwNrvHaIgQuOYXwPIdHYqxG0uLTttmKMTVTAPEiTtEUK9cDgcNaG%2B7RYqbUFdh%2Fo4L2zosSImj6T%0AAuIou7da1w%3D%3D%0A";//"This is a test that posts this string to a Web server.";
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                    // Set the ContentType property of the WebRequest.
                    request.ContentType = "application/x-www-form-urlencoded";
                    // Set the ContentLength property of the WebRequest.
                    request.ContentLength = byteArray.Length;

                    // Get the request stream.
                    Stream dataStream = request.GetRequestStream();
                    // Write the data to the request stream.
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    // Close the Stream object.
                    dataStream.Close();

                    // Get the response.
                    WebResponse response = request.GetResponse();
                    // Display the status.
                    Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                    string result = string.Empty;

                    // Get the stream containing content returned by the server.
                    // The using block ensures the stream is automatically closed.
                    using (dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.
                        Console.WriteLine(responseFromServer);
                        result = responseFromServer;
                    }

                    // Close the response.
                    response.Close();
                    HttpContext.Current.Response.Write(result);
                    Log(result);
                }
            }
        }
        else
            Response.Write(SecurityHelper.AES256Encrypt("reader.parser. error : ", KEY));





        
    }

    public void Log(string str)
    {
        string logPath = GDSCommon.Common.getStrVal(System.Configuration.ConfigurationManager.AppSettings["LogPath"]);
        string FilePath = Path.Combine(logPath, "Gscan3_Auth_" + DateTime.Today.ToString("yyyyMMdd") + ".log");
        string DirPath = logPath;
        string temp;

        DirectoryInfo di = new DirectoryInfo(DirPath);
        FileInfo fi = new FileInfo(FilePath);

        try
        {
            if (di.Exists != true) Directory.CreateDirectory(DirPath);

            if (fi.Exists != true)
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    temp = string.Format("[{0}] : {1}", GetDateTime(), str);
                    sw.WriteLine(temp);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    temp = string.Format("[{0}] : {1}", GetDateTime(), str);
                    sw.WriteLine(temp);
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Response.Write("reader.parse error:");
        }
    }
    public string GetDateTime()
    {
        DateTime NowDate = DateTime.Now;
        return NowDate.ToString("yyyy-MM-dd HH:mm:ss") + ":" + NowDate.Millisecond.ToString("000");
    }

}