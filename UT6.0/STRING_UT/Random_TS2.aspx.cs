using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class STRING_UT_Random_TS2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(rm());
    }


    protected string rm()
    {
        string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        char[] charArray = chars.ToCharArray();

        int numPasswd = 10;

        string newPasswd = string.Empty;

        int seed = Environment.TickCount;

        Random rd = new Random(seed);
        int tempNum = 0;



        for (int j = 0; j < numPasswd; j++)
        {
            tempNum = rd.Next(0, charArray.Length - 1);
            newPasswd += charArray[tempNum];
        }

        return newPasswd;
    }
}