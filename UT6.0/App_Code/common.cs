using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Net;
/// <summary>
/// common의 요약 설명입니다.
/// </summary>
public class common
{
    public common()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }
    /// <summary>
    /// onload input validator
    /// </summary>
    /// <param name="inputParamTable">all request paramerter</param>
    /// <returns>success : true, fail : false</returns>
    /// 
   
    /// <summary>
    /// get session
    /// </summary>
    /// <param name="name">session name</param>
    /// <returns></returns>
    public static string GetSession(string name)
    {
        string result = string.Empty;

        if ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[name] != null))
        {
            result = HttpContext.Current.Session[name].ToString();
        }

        return result;
    }
    public static string GetClientIP()
    {
        string userIp = string.Empty;

        try
        {
            userIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(userIp))
            {
                userIp = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
        }
        catch
        {
            userIp = ":-1";
        }

        return userIp;
    }


    /// <summary>
    /// get string value for any object
    /// </summary>
    /// <param name="objValue">any object</param>
    /// <param name="sOption">default value for blank string</param>
    /// <returns>string result. blank for converting error</returns>
    public static string GetStrVal(object value, string option = "")
    {
        string result = string.Empty;

        try
        {
            result = value.ToString().Trim();
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }

        if (result == string.Empty)
        {
            if (option == "HTML")
            {
                result = "&nbsp;";
            }
            else if (option == "PAGE")
            {
                result = "1";
            }
            else
            {
                result = option;
            }
        }

        return result;
    }

}