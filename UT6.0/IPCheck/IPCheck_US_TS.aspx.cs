using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IPCheck_IPCheck_US_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string getip = string.Empty;
        getip = Ip();
        Response.Write(getip);

        string aa = ReturnData(getip);

        Response.Write(aa);
    }


    protected static string Ip()
    {
        string ip = WSF.Helper.StringUtil.GetString(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
        if (ip == string.Empty)
        {
            ip = HttpContext.Current.Request.UserHostAddress;
        }
        return ip;
    }

    private string ReturnData(string getip)
    {
        //2012.09.19 미국 이외 국가에서 접속 차단 (geoip에서 던져주는 값이 US가 아닌 이외 국가에서는 접속 차단) 권윤아
        //http://geoip.maxmind.com/a?l=Xs46vYJAccer&i=80.24.24.24 
        string license_key = "Xs46vYJAccer";//"LICENSE_KEY_HERE";
        //TEST :  3.0.0.0 ~ 3.103.8.36 ->US(USA)   |  2.20.179.0 ~ 2.20.179.255    -> ES(Spain)   |   112.144.0.0 ~ 112.191.255.255   ->KR(Korea)      
        //getip = "3.103.8.37";
        System.Uri objUrl = new System.Uri("http://geoip.maxmind.com/a?l=" + license_key + "&i=" + getip.Trim());
        System.Net.WebRequest objWebReq;
        System.Net.WebResponse objResp;
        System.IO.StreamReader sReader;
        string strReturn = string.Empty;

        //Try to connect to the server and retrieve data. 
        try
        {
            objWebReq = System.Net.WebRequest.Create(objUrl);
            objResp = objWebReq.GetResponse();

            //Get the data and store in a return string. 
            sReader = new System.IO.StreamReader(objResp.GetResponseStream());
            strReturn = sReader.ReadToEnd();

            //Close the objects. 
            sReader.Close();
            objResp.Close();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            objWebReq = null;
        }
        return strReturn;
    }
}