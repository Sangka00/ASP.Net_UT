using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class STRING_UT_combine_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string s1 = "The quick brown fox jumps over the lazy dog";
        string s2 = "fox";
        bool b;
        b = s1.Contains(s2);
       Response.Write( b.ToString());


   
    }
}