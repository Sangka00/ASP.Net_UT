using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eMail_eMail_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string sEmailResult = string.Empty;
        //send email
        string padMac = "00:11:A0:12:AA:B0:CC:16";
        string sEmailFrom = "sangka@gitauto.com";
        string sEmailTo = "sangka@gitauto.com";
        string sEmailBcc = string.Empty;
        string sEmailCc = "sangka@gitauto.com";
        string sEmailSubject = " Pad Mac : " + padMac;
        string sEmailBody = " Pad Mac "
                + "<br> PAD Mac : " + padMac
                + "<br> Check Date :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        sEmailResult = email.SendMailMessage(sEmailFrom, sEmailTo, sEmailBcc, sEmailCc, sEmailSubject, sEmailBody);

        if (sEmailResult == "")
        {
            Response.Write("SUCESS");
        }
        else
        {
            Response.Write(sEmailResult);
        }
    }
}