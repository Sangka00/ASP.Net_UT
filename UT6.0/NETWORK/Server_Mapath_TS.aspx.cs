using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SERVER_MapPATH_Server_Mapath_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // MapPath : 물리적 경로를 리턴한다.
        //-파일을 다룰 때(저장,삭제등)에 서버의 물리적 주소(절대 주소)를 쓰게 된다.
        // 하지만 서버의 주소는 항상 환경에 따라 변할 수 있다.
        // 그때마다 일일이 주소를 바꾸어 준다는 것은 피곤하다. 따라서 이 메소드를 사용하면 홈 또는 가상디렉토리 이전의ㅣ
        // 물리적 주소는 자동으로 리턴해 주기 때문에 환경이 바뀌더라도 수정없이 사용할 수 있다.
        // 이 메소드를 사용하면 홈 또는 가상디렉토리 이후의 상대주소만 유지하면 된다.

        string Path = Server.MapPath(".");   //현재 페이지의 물리적 디렉토리 경로

        Response.Write(Path);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string Path = Server.MapPath("..");   //현재 페이지의 상위 디렉토리 경로
        Response.Write(Path);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string Path = Server.MapPath("/");   //홈디렉토리 물리적 디렉토리 경로
        Response.Write(Path);
        //Server.MapPath("/가상디렉토리") //가상디렉토리 경로
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string Path = Server.MapPath("./");   //현재 aspx 페이지의 Local root 예) Z:\019년도 10월ProJ\UT_201910\SERVER_MapPATH\ 
        Response.Write(Path);
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        // File 존재 유무 찾기
        string tTemp = getStrVal( System.Configuration.ConfigurationManager.AppSettings["KMEPath"]);
        tTemp = tTemp + "updateIF.aspx";
        bool Flag = IsFileExist(tTemp);
        Response.Write(Flag.ToString());
    }

    private bool IsFileExist(string path)
    {
        if (File.Exists(path))
        {
            return true;
        }else
        {
            return false;
        }
    }
    private static string getStrVal(object objValue)
    {
        return getStrVal(objValue, "");
    }
    public static string getStrVal(object objValue, string sOption)
    {
        string sResult = string.Empty;

        try
        {
            sResult = objValue.ToString().Trim();
        }
        catch (Exception ex)
        {
            string sError = ex.Message;
        }

        if (sResult == string.Empty)
        {
            if (sOption == "HTML")
            {
                sResult = "&nbsp;";
            }
            else if (sOption == "PAGE")
            {
                sResult = "1";
            }
            else
            {
                sResult = sOption;
            }
        }

        return sResult;
    }

}