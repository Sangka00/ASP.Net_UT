using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;


public partial class DATETIME_DateTime_TS : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsYYYYMMDD("2004-09-14"))
        {
            Response.Write("날짜형식");
        }else
        {
            Response.Write("날짜형식 아닙니다.");
        }   
    }

    /// <summary>
    /// 날짜 문자열이 YYYYMMDD 형식인지 검사한다.
    /// </summary>
    /// <param date="YYYYMMDD or YYYY-MM-DD"></param>
    /// <returns></returns>
    /// 
    private static bool IsYYYYMMDD(string date)
    {
        bool result = false;
        result = Regex.IsMatch(date, @"^(19|20)\d{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[0-1])$");
        if (!result) result = Regex.IsMatch(date, @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[0-1])$");

        return result;
    }


}