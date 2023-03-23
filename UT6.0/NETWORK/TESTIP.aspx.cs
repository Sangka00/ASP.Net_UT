using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NETWORK_TESTIP : System.Web.UI.Page
{
    string getip = string.Empty;
    string Return_Str = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string sStr = string.Empty;
        sStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        sStr += "<node>";

        sStr = Check_List();
        sStr += "</node>";
        Response.Write(sStr);
    }
    private string Check_List() // 북미 EDR 사용
    {

        getip = aIp();
        Response.Write(" client IP ::" + getip + "<BR>");
        Response.Write("Area :: " + ReturnData(getip).ToString() + "<BR>");

        string temp = ReturnData(getip).ToString();
        //2012.09.20 국가별 IP 체크하여 접속 허용 구분. 테스트를 위해 한국과 미국에서 접속 시 로그인 허용
        //if (ReturnData(getip).ToString() == "US" || ReturnData(getip).ToString() == "KR")
        if (temp == "US" || temp == "CA" || temp == "PR")
        {
            Return_Str += "<Result result=\"1\" message=\" EXIST.\"/>";
        }
        else if (ReturnData(getip).ToString() == "KR")
        {
            Response.Write("<Result result=\"1\" message=\" EXIST.\"/>");
            if (getip.Substring(0, 5) == "58.87" || getip.Substring(0, 10) == "10.206.213" || getip.Substring(0, 10) == "10.206.214" || getip.Substring(0, 10) == "10.206.215" || getip.Substring(0, 10) == "220.118.96" || getip.Substring(0, 10) == "192.168.12")//getip.Substring(0, 11) == "112.169.142"
            {
                Return_Str += "<Result result=\"1\" message=\" EXIST.\"/>";
                Response.Write("1111111");
            }
            else
            {
                Return_Str += "<Result result=\"6\" message=\" TEST NOT ACCESS.\"/>";
            }
        }
        else
        {
            Return_Str += "<Result result=\"0\" message=\" NOT ACCESS.\"/>";
        }
        return Return_Str;
    }


    private static string aIp()
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