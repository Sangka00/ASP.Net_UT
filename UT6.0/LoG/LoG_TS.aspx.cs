using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.IO;

public partial class LoG_LoG_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Log("TEST2");
    }

    public void Log(string str)
    {
        string temp = string.Empty;
        string defaultPath = Server.MapPath(ConfigurationManager.AppSettings["./"]);


        string FilePath = defaultPath + DateTime.Today.ToString("yyyyMMdd") + ".log";
        Response.Write(FilePath);

        using (StreamWriter sw = new StreamWriter(FilePath))
        {
            temp = string.Format("[{0}] : {1}", GetDateTime(), str);
            sw.WriteLine(temp);
            sw.Close();
        }

    }

    public string GetDateTime()
    {
        DateTime NowDate = DateTime.Now;
        return NowDate.ToString("yyyy-MM-dd HH:mm:ss") + ":" + NowDate.Millisecond.ToString("000");
    }

}