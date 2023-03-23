using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using Newtonsoft.Json.Linq;
public partial class GoogleChart_GoogleChart_TS005 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
   
    [WebMethod]
    public static string GetData(string sDate, string eDate, string Product)
    {
       
        string str = string.Empty;
        using (DataSet ds = Google_Chart_DB.GetDB_Select(sDate, eDate, Product))
        {
            // 여기에서 db 데이터 가져와서 문자열 조합하시면 될것 같습니다.
          
            str += "[";
            str += "['Menu', 'TotalOrders', { role: 'style' }, { role: 'annotation' }],";
            str += "['설치', "+ds.Tables[0].Rows[0]["install"].ToString() + ", '#b87333', " + ds.Tables[0].Rows[0]["install"].ToString() + "],";
            str += "['업데이트', " + ds.Tables[0].Rows[0]["Updatee"].ToString() + ", 'silver', " + ds.Tables[0].Rows[0]["Updatee"].ToString() + "],";

            str += "['구매 및 AS', " + ds.Tables[0].Rows[0]["install"].ToString() + ", 'silver', " + ds.Tables[0].Rows[0]["install"].ToString() + "],";
            str += "['원격지원', " + ds.Tables[0].Rows[0]["install"].ToString() + ", 'silver', " + ds.Tables[0].Rows[0]["install"].ToString() + "],";
            str += "['자주하는 질문', " + ds.Tables[0].Rows[0]["install"].ToString() + ", 'silver', " + ds.Tables[0].Rows[0]["install"].ToString() + "],";
            str += "['동영상가이드', " + ds.Tables[0].Rows[0]["install"].ToString() + ", 'silver', " + ds.Tables[0].Rows[0]["install"].ToString() + "],";
            str += "['문의하기', " + ds.Tables[0].Rows[0]["install"].ToString() + ", 'blue', " + ds.Tables[0].Rows[0]["install"].ToString() + "],";
            str += "['아이디/비밀번호', " + ds.Tables[0].Rows[0]["ID"].ToString() + ", 'blue', " + ds.Tables[0].Rows[0]["ID"].ToString() + "]";
            str += "]";
        }


           

        var arr = JArray.Parse(str);

        return arr.ToString();
    }
}