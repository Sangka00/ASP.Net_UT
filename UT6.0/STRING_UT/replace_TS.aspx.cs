using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class STRING_UT_replace_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string re_str = "NHK1-P0DC-78BX-GYQG";

        string re2 = re_str.Replace("-", "");
        Response.Write(re2);
    }
}