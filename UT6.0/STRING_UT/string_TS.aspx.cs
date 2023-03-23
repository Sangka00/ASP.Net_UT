using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sting_UT_string_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string _sTemp = string.Empty;
        _sTemp = txt_str.Text;

        //  string s = "Hello World";
        //  bool stringExists = s.Contains("ello");  //stringExists =true as the 

        if (_sTemp.ToUpper().Contains("KDE")) { 
        _sTemp = _sTemp.Substring(0, _sTemp.Length - 2);
        lbl_str.Text = _sTemp + "**";
        }else
        {
            lbl_str.Text = _sTemp;
        }


    }
}