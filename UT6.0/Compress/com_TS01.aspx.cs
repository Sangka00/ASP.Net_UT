using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aSIMS;

public partial class Compress_com_TS01 : System.Web.UI.Page
{
    const string KEY = "nfactor!planemo!nfactor!planemo!";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       
        TextBox2.Text = SecurityHelper.AES256Encrypt(TextBox1.Text, KEY);

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
      TextBox4.Text = SecurityHelper.AES256Decrypt(TextBox3.Text.Trim(), KEY);
    }
}