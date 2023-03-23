using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Text;
using System.Data;


public partial class Ajax_Ajax_TS01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string GetList(string aaa, int bbb)
    {
        string returnValue = string.Empty;
        List<object> obj = new List<object>();

        // 주석처리 한 부분은 현재 사용 있는 코드입니다. 참고하세요.
        /*
        using (DataSet ds = MenuInfo.SelectMenuInfoView(menuID))
        {
            int nCount = ds.Tables[0].Rows.Count;
            if (nCount > 0)
            {
                obj.Add(new
                {
                    MENUID = ds.Tables[0].Rows[0]["MENUID"].ToString(),
                    PARENTMENUID = ds.Tables[0].Rows[0]["PARENTMENUID"].ToString(),
                    MENUNAME = ds.Tables[0].Rows[0]["MENUNAME"].ToString(),
                    MENUNAME_ENG = ds.Tables[0].Rows[0]["MENUNAME_ENG"].ToString(),
                    MENUNAME_CHI = ds.Tables[0].Rows[0]["MENUNAME_CHI"].ToString(),
                    MENUURL = ds.Tables[0].Rows[0]["MENUURL"].ToString(),
                    MENUTYPE = ds.Tables[0].Rows[0]["MENUTYPE"].ToString(),
                    MENULVL = ds.Tables[0].Rows[0]["MENULVL"].ToString()
                });

                return (new JavaScriptSerializer().Serialize(obj));
            }
        }
        */

        // 여기에서 db 연결을 통해서 데이터를 불러오시면 됩니다.
        // 이건 그냥 예제입니다.
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("AGE", typeof(string));

        DataRow dr = dt.NewRow();
        dr["NAME"] = "111";
        dr["AGE"] = 1;
        dt.Rows.Add(dr);

        DataRow dr2 = dt.NewRow();
        dr2["NAME"] = "222";
        dr2["AGE"] = 2;
        dt.Rows.Add(dr2);

        DataRow dr3 = dt.NewRow();
        dr3["NAME"] = "333";
        dr3["AGE"] = 3;
        dt.Rows.Add(dr3);

        int nCount = dt.Rows.Count;
        if (nCount > 0)
        {
            for (int i = 0; i < nCount; i++)
            {
                obj.Add(new
                {
                    // 여기에서 정의한, NAME, AGE는 자바스크립에서 사용될 변수입니다.
                    // dt.Rows[i]["NAME"].ToString() --> 이거는 DB 컬럼명입니다.
                    NAME = dt.Rows[i]["NAME"].ToString(),
                    AGE = dt.Rows[i]["AGE"].ToString()
                });
            }
            string temp = new JavaScriptSerializer().Serialize(obj);
            return (new JavaScriptSerializer().Serialize(obj));
        }

        return returnValue;
    }

    [WebMethod]
    public static string GetList2(string aaa, int bbb)
    {
        StringBuilder sb = new StringBuilder();

        // 여기에서 db 연결을 통해서 데이터를 불러오시면 됩니다.
        // 이건 그냥 예제입니다.
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("AGE", typeof(string));

        DataRow dr = dt.NewRow();
        dr["NAME"] = "111";
        dr["AGE"] = 1;
        dt.Rows.Add(dr);

        DataRow dr2 = dt.NewRow();
        dr2["NAME"] = "222";
        dr2["AGE"] = 2;
        dt.Rows.Add(dr2);

        DataRow dr3 = dt.NewRow();
        dr3["NAME"] = "333";
        dr3["AGE"] = 3;
        dt.Rows.Add(dr3);

        int nCount = dt.Rows.Count;
        if (nCount > 0)
        {
            for (int i = 0; i < nCount; i++)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + dt.Rows[i]["NAME"].ToString() + "</td>");
                sb.AppendLine("<td>" + dt.Rows[i]["AGE"].ToString() + "</td>");
                sb.AppendLine("</tr>");
            }
        }
        else
        {
            // 데이터가 없는 경우의 처리
            sb.AppendLine("<tr><td colspan=\"2\">데이터가 없습니다.</td></tr>");
        }

        return sb.ToString();
    }

    [WebMethod]
    public static string GetView(string aaa, int bbb)
    {
        string returnValue = string.Empty;
        List<object> obj = new List<object>();

        // 여기에서 db 연결을 통해서 데이터를 불러오시면 됩니다.
        // 이건 그냥 예제입니다.
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("AGE", typeof(string));

        DataRow dr = dt.NewRow();
        dr["NAME"] = aaa;
        dr["AGE"] = bbb.ToString();
        dt.Rows.Add(dr);

        int nCount = dt.Rows.Count;
        if (nCount > 0)
        {
            obj.Add(new
            {
                // 여기에서 정의한, NAME, AGE는 자바스크립에서 사용될 변수입니다.(변수명은 아무거나 사용해도 됩니다.)
                // dt.Rows[i]["NAME"].ToString() --> 이거는 DB 컬럼명입니다.
                NAME = dt.Rows[0]["NAME"].ToString(),
                AGE = dt.Rows[0]["AGE"].ToString()
            });

            return (new JavaScriptSerializer().Serialize(obj));
        }

        return returnValue;
    }
}