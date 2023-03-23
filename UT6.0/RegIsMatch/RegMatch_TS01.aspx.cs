using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegIsMatch_RegMatch_TS01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_int_Click(object sender, EventArgs e)
    {
        //string str1 = "asdfsfsf";
  
        try
        {
            if(Regex.IsMatch(Txt_IN.Text, @"[0-9]")) // 전체에서 0~9 사이에 아무 숫자 '하나' 찾음 range를 표현하며 x ~ z 사이의 문자를 의미한다.           
            {
                Response.Write("true :: 전체에서 0~9 숫자가 있음");
            }
            else
            {
                Response.Write("false :: 전체에서 0~9 숫자가 없음");
            }

            if(Regex.IsMatch(Txt_IN.Text, @"^[0-9/-]"))
            {
                Response.Write("<BR>");
                Response.Write("true :: 날자값 맞음");
            }
            else
            {
                Response.Write("<BR>");
                Response.Write("false :: 날자값 틀림");
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}