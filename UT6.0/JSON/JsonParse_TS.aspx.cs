using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

public partial class JSON_JsonParse_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string sJson = "{\"multicast_id\":2172596731824641480,\"success\":0,\"failure\":1,\"canonical_ids\":0,\"results\":[{\"error\":\"NotRegistered\"}]}";
        JObject jsonData = JObject.Parse(sJson); //문자를 객체화
        string failure = NullCheck(jsonData["failure"].ToString());
        string success = NullCheck(jsonData["success"].ToString());
        string results = NullCheck(jsonData["results"]);

        Response.Write(failure+"<BR>");

        Response.Write(success + "<BR>");

        Response.Write(results + "<BR>");
    }

    public static string NullCheck(Object str)
    {
        string sResult = string.Empty;

        if (str == null)
        {
            sResult = "";
        }
        else
        {
            sResult = str.ToString();
        }

        return sResult;
    }
}