using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// StringBase64의 요약 설명입니다.
/// </summary>
public class StringBase64
{
    public StringBase64()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }
    public static string DecodeBase64(object _str)
    {
        try
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(WSF.Helper.StringUtil.GetString(_str)));
        }
        catch
        {
            return string.Empty;
        }
    }
    public static string EncodeBase64(object _str)
    {
        try
        {

            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(WSF.Helper.StringUtil.GetString(_str)));
        }
        catch
        {
            return string.Empty;
        }
    }
}

