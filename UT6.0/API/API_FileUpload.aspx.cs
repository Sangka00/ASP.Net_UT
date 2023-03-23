using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;

/// <summary>
/// //////////////////////
/// 
/// </summary>
public partial class API_API_FileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int fileCount = 0;
        string FileName = string.Empty;
        #region Fiel UoLoad
        try
        {
            // 해당 폴더가 없으면 폴더 만들기 // 예) z:\Upload\20190401           
            string directoryPath = "z:\\Upload\\" + DateTime.Now.ToString("yyyyMMdd") + "\\";
            DirectoryInfo di = new DirectoryInfo(directoryPath);
            if (di.Exists == false) di.Create();

            // 첨부파일이 있으면 저장하기.      
            HttpFileCollection uploadFiles = HttpContext.Current.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    FileName = postedFile.FileName;
                    FileName = postedFile.FileName.Substring(FileName.LastIndexOf("\\") + 1);
                    int indexOfDot = FileName.LastIndexOf(".");
                    string strName = FileName.Substring(0, indexOfDot);
                    string strExt = FileName.Substring(indexOfDot + 1);


                    if (File.Exists(Path.Combine(directoryPath, FileName)))
                    {
                        fileCount++;
                        FileName = strName + "(" + fileCount + ")." + strExt;
                    }

                    postedFile.SaveAs(directoryPath + FileName); //  파일 저장하기.



                    // db에 저장
                }
                Response.Write(FileName + "저장성공");
            }
            
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        #endregion
    }
}