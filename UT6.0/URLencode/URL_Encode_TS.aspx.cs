using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class URLencode_URL_Encode_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //한글 처리
        //인코딩 처리
        string encodeName = HttpUtility.UrlEncode("테스트", Encoding.UTF8);

        //디코딩 처리
        string originalName = HttpUtility.UrlDecode(encodeName, Encoding.UTF8);

        Response.Write(originalName);
    }
}