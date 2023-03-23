using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DropDownList_DropdwonList_ts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DropDownList1.Items.Clear();

            ListItem lt_upVer = new ListItem();
            lt_upVer.Text = "a";
            lt_upVer.Value = "a";
            DropDownList1.Items.Add(lt_upVer);

            ListItem lt_upVer2 = new ListItem();
            lt_upVer2.Text = "b";
            lt_upVer2.Value = "b";
            DropDownList1.Items.Add(lt_upVer2);

            ListItem lt_upVer3 = new ListItem();
            lt_upVer3.Text = "c";
            lt_upVer3.Value = "c";
            DropDownList1.Items.Add(lt_upVer3);

        }


    }
    protected void ListADD(DropDownList DL, ListItem lt)
    {
       
      
        DL.Items.Add(lt);
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Response.Write(DropDownList1.SelectedValue);
      //  Response.Write("<BR>");
       // Response.Write(DropDownList1.SelectedIndex.ToString());

        ListItem lt_upVer = new ListItem();
        lt_upVer.Text = "a1";
        lt_upVer.Value = "a1";
        DropDownList2.Items.Add(lt_upVer);

        ListItem lt_upVer2 = new ListItem();
        lt_upVer2.Text = "b1";
        lt_upVer2.Value = "b1";
        DropDownList2.Items.Add(lt_upVer2);

        ListItem lt_upVer3 = new ListItem();
        lt_upVer3.Text = "c1";
        lt_upVer3.Value = "c1";
        DropDownList2.Items.Add(lt_upVer3);
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem lt_upVer = new ListItem();
        lt_upVer.Text = "a11";
        lt_upVer.Value = "a11";
        DropDownList3.Items.Add(lt_upVer);

        ListItem lt_upVer2 = new ListItem();
        lt_upVer2.Text = "b11";
        lt_upVer2.Value = "b11";
        DropDownList3.Items.Add(lt_upVer2);

        ListItem lt_upVer3 = new ListItem();
        lt_upVer3.Text = "c11";
        lt_upVer3.Value = "c11";
        DropDownList3.Items.Add(lt_upVer3);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write(DropDownList1.SelectedValue + "-" + DropDownList2.SelectedValue + "-" + DropDownList3.SelectedValue);
    }
}