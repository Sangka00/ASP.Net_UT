using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class STRING_UT_subString_TS2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = TextBox1.Text.Trim();
        string x_str = string.Empty;
        string x_str0 = str.Substring(1, 1).ToString();
        string x_str1 = str.Substring(2,1).ToString();
        string x_str2 = str.Substring(3, 1).ToString();
        string x_str3 = str.Substring(4, 1).ToString();
        
        x_str = x_str0 + "=====";
        x_str += x_str1 + "=====";
        x_str += x_str2 + "=====";
        x_str += x_str3 + "=====";
       

        Label1.Text = x_str;
    }
}