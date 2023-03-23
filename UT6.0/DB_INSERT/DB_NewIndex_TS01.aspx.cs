using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DB_INSERT_DB_NewIndex_TS01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_Insert_Click(object sender, EventArgs e)
    {
        string idx = DB.DBINSERT.DB_NewIndex("snasss", "2334");
            
        Response.Write(idx);
    }
}