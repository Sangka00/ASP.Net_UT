using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AuthCheck의 요약 설명입니다.
/// </summary>
public class AuthCheck
{
    public AuthCheck()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }
    public static string UserId(string _auString)
    {
        try
        {
            string De_auString = WSF.Security.CryptoHelper.DecryptString2(_auString, WSF.Configuration.ConfigHelper.GetAppConfig("ecykey"));
            System.Collections.Specialized.NameValueCollection nvcValue = HttpUtility.ParseQueryString(De_auString);
            return nvcValue["id"];
        }
        catch
        {
            return string.Empty;
        }
    }
    public static bool ReferCheck()
    {
        bool result = false;
        string[] referUri = WSF.Configuration.ConfigHelper.GetAppConfig("referer").Split(',');
        string realReferer = GetCurrentReferString();
        if (realReferer != string.Empty)
        {
            for (int i = 0; i < referUri.Length; i++)
            {
                if (realReferer.StartsWith(referUri[i]))
                {
                    result = true;
                    break;
                }
            }
        }
        return result;
    }
    protected static string GetCurrentReferString()
    {
        try
        {
            return null != HttpContext.Current.Request.UrlReferrer ? Convert.ToString(HttpContext.Current.Request.UrlReferrer) : string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }
    public static bool PopupCheck(string _auString)
    {
        if (UserId(_auString) != string.Empty && ReferCheck())
        {
            return true;
        }
        else return false;
    }
}
