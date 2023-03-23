using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DAY_Day_Time_TS01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Today_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Today;
        Response.Clear();
        Response.Write(today.ToString("yyy-MM-dd"));
          //3일 뒤 날짜
        // Response.Write(today.AddDays(3).ToString());
    }
}