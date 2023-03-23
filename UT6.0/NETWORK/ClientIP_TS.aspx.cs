using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NETWORK_ClientIP_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_IP_Click(object sender, EventArgs e)
    {         
        string IP_str = IP();
        string IP_sub = IP_str.Substring(0, 9).ToString();
        //GIT 내부 아이디  "58.87.61.201" VPN 아이디  10.99.208  10.99.209
        if (IP_str == "58.87.61.201" || IP_sub == "10.99.208" || IP_sub == "10.99.209")
        {
            lbl_IP.Text = IP_str + "사용가능";
        }
        else
        {
            lbl_IP.Text = IP_str + "사용불가능";
        }
        
    }

    protected string IP()
    {
        string ip = WSF.Helper.StringUtil.GetString(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
        if (ip == string.Empty)
        {
            ip = HttpContext.Current.Request.UserHostAddress;
        }
        return ip;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        UnCheckSSL();
    }

    protected void UnCheckSSL()
    {

        if (!HttpContext.Current.Request.IsSecureConnection)
        {
            string protocol, serverName, url, queryString;
            protocol = "http://";
            serverName = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            url = HttpContext.Current.Request.ServerVariables["URL"];
            queryString = HttpContext.Current.Request.ServerVariables["QUERY_STRING"];
            HttpContext.Current.Response.Write(protocol + serverName + url + queryString);
        }


    }
}