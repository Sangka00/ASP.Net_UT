using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.IO;


/// <summary>
/// LOG_WT의 요약 설명입니다.
/// </summary>
public class LOG_WT
{
    public LOG_WT()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }

    public static void Log(string str)
    {
        string temp = string.Empty;
        string defaultPath = HttpContext.Current.Request.PhysicalApplicationPath;


        string FilePath = defaultPath + DateTime.Today.ToString("yyyyMMdd") + ".log";
        //Response.Write(FilePath);
        HttpContext.Current.Response.Write(HttpContext.Current.Request.PhysicalApplicationPath);
        using (StreamWriter sw = new StreamWriter(FilePath))
        {
            temp = string.Format("[{0}] : {1}", GetDateTime(), str);
            sw.WriteLine(temp);
            sw.Close();
        }
    }

    public static string GetDateTime()
    {
        DateTime NowDate = DateTime.Now;
        return NowDate.ToString("yyyy-MM-dd HH:mm:ss") + ":" + NowDate.Millisecond.ToString("000");
    }
}