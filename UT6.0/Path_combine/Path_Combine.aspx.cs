using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Path_combine_Path_Combine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string filePath = Path.Combine(Txt_Domain.Text.Trim(), Txt_URL.Text.Trim());
        Lbl_Rs.Text = filePath;

    }
}