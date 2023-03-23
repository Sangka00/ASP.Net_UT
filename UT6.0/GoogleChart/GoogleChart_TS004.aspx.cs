using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using Newtonsoft.Json.Linq;

public partial class GoogleChart_GoogleChart_TS004 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string GetData()
    {
        // 여기에서 db 데이터 가져와서 문자열 조합하시면 될것 같습니다.
        string str = string.Empty;
        str += "[";
        str += "['Menu', 'TotalOrders', { role: 'style' }, { role: 'annotation' }],";
        str += "['설치', 20, '#b87333', 30],";
        str += "['업데이트', 30, 'silver', 10.49],";

        str += "['구매 및 AS', 30, 'silver', 10.49],";
        str += "['원격지원', 30, 'silver', 30],";
        str += "['자주하는 질문', 10.5, 'silver', 10.5],";
        str += "['동영상가이드', 25, 'silver', 25],";
        str += "['문의하기', 10, 'blue', 10],";
        str += "['아이디/비밀번호', 40, 'blue', 40]";
        str += "]";

        var arr = JArray.Parse(str);

        return arr.ToString();
    }

}