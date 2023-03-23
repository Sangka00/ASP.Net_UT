using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;

public partial class FILE_File_Write_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FileInfo fInfo = new FileInfo("z:\\xxx.evt");
        StreamWriter sw = fInfo.AppendText();
        sw.WriteLine("출력 할 글의 내용");
        sw.Flush();
        sw.Close();

    }
}