using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class compress_Compress_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bool FG = false;
            string folderUrl = "z:\\Temp\\";
            string folderNm = "xxx123";
            //이전 작업 폴더 삭제 
           
            //random 함수 만들기
            Random Rand = new Random((int)DateTime.Now.Ticks);
            int Iteration = 0;

            Iteration = Rand.Next(1, 1000);
            string ssfolder = folderUrl + "\\" + folderNm + "_" + Iteration.ToString();
            // 폴더 만들기
            Directory.CreateDirectory(ssfolder);
            File.Copy("z:\\Temp\\check_user.aspx", ssfolder + "\\check_user.aspx");
            File.Copy("z:\\Temp\\check_user.aspx.cs", ssfolder + "\\check_user.aspx.cs");

            FG = Compress.ZipManager.ZipFiles(ssfolder, "z:\\Temp\\Test_2020.zip", "", false);
            //폴더삭제
           // DirectoryInfo dir = new DirectoryInfo("z:\\Temp\\xxx123_66");
          //  dir.Delete(true);
        }
        catch(Exception ex)
        {
           
            Response.Write(ex.ToString());
        }
        
    }
}