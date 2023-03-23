using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aSIMS;
public partial class Encryption_Sam_TS01 : System.Web.UI.Page
{

    const string KEY = "nfactor!planemo!nfactor!planemo!";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string x = SecurityHelper.AES256Encrypt(TextBox1.Text.Trim(), KEY);
        lbl_encoding.Text = HttpUtility.UrlEncode(x);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        lbl_decoding.Text = SecurityHelper.AES256Decrypt(HttpUtility.UrlDecode(TextBox2.Text.Trim()), KEY);
    }
}