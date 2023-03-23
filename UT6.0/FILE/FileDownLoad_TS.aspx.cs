using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FILE_FileDownLoad_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // File DownLoad
        try
        {
            string filename = "Query_Join.sql"; //다운로드할 파일명

            string path = MapPath("~/Download/" + filename); //프로젝트와 같은 폴더내 Download폴더 
            path = Server.MapPath("./TEMP_Data/Query_Join.sql");
            byte[] bts = System.IO.File.ReadAllBytes(path);

            Response.Clear();

            Response.AddHeader("Content-Type", "Application/octet-stream");

            Response.AddHeader("Content-Length", bts.Length.ToString());

            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);

            Response.BinaryWrite(bts); Response.Flush();
           
            Response.End();           


        }
        catch(Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
}