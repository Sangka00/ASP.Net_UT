using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

public partial class Temp_Temp01 : WSF.Web.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xlsFileInfo = GetForm("xf");
        xlsFileInfo = "avbdse";
        WSF.Web.FileUploadHelper fu = new WSF.Web.FileUploadHelper(xlsFileInfo);

        if (fu.Count != 1)
        {
            Response.Write("Error");
        }
    }
}