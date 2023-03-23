using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Newtonsoft.Json;
using System.Text;
public partial class JSON_Class2JSON : System.Web.UI.Page
{
    class Feedback
    {
        public string Dealer_Code;
        public string Sender_Name;
        public string Sender_E_mail;
        public string Vin;
        public string Model;
        public string Model_year;
        public string Engine;
        public string Auto_manual;
        public string WD_2_4;
        public string System;
        public string Subject;
        public string Description;
        public string Attachment;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_Class2JSON_Click(object sender, EventArgs e)
    {
        string json = json_return();

        Response.Write(json);
    }

    private string json_return()
    {
        Feedback fd = new Feedback();
        fd.Dealer_Code = "Dealer1";
        fd.Sender_Name = "sangka";
        fd.Sender_E_mail = "sangka@gitauto.com";
        fd.Vin = "Vin12345678901";
        fd.Model = "MD12";
        fd.Model_year = "2019";
        fd.Engine = "engin";
        fd.Auto_manual = "a_manual";
        fd.WD_2_4 = "4";
        fd.Subject = "subject";
        fd.Description = "description";
        fd.Attachment = "attach";

        string json = JsonConvert.SerializeObject(fd);

        return json;
    }
}