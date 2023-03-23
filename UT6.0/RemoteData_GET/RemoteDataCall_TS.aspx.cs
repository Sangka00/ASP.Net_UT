using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RemoteData_GET_RemoteDataCall_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string Get_SAM(string key, string SAM_STR)
    {
        string _str = string.Empty;
        string returnValue = string.Empty;
        string url = "http://gsup.gitauto.com/ASIMS/sam_auth.aspx?K=" + key + "&SAM_STR=" + SAM_STR;
        //  string url = "http://localhost:49867/Category/Equipment/Mobis/Mobis_WebService.aspx?K=" + key + "&SAM_STR=" + SAM_STR;
        HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
        httpRequest.Method = "GET";

        using (HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse())
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader responseReader = new StreamReader(responseStream))
                {
                    _str = responseReader.ReadToEnd();
                }
            }
        }
        return _str;
    }
}