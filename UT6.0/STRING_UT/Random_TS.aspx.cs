using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class STRING_UT_Random_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string aa = GetRandomPassword(10);
        Response.Write(aa);
    }

    public static string GetRandomPassword(int _totLen)
    {
        Random rand = new Random();
        string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        var chars = Enumerable.Range(0, _totLen)
                                      .Select(x => input[rand.Next(0, input.Length)]);
        return new string(chars.ToArray());
    }

}