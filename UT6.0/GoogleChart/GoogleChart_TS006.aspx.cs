using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GoogleChart_GoogleChart_TS006 : WSF.Web.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Product_Init();
        }
    }
    protected void Product_Init()
    {
        #region 제품 리스트 받기
        try
        {
            ddl_Product.Items.Clear();

            using (DataSet ds =  Google_Chart_DB.GetProduct())
            {
                ListItem lt_upVer = new ListItem();
                lt_upVer.Text = "ALL";
                lt_upVer.Value = "ALL";
                ddl_Product.Items.Add(lt_upVer);
                ddl_Product.AppendDataBoundItems = true;
                ddl_Product.DataTextField = "Product";
                ddl_Product.DataValueField = "Product";

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddl_Product.DataSource = ds.Tables[0];
                    ddl_Product.DataBind();

                }
                ddl_Product.SelectedIndex = -1;
            }

        }
        catch (Exception ex)
        {

        }
        #endregion
    }

    [WebMethod]
    public static Google_Chart_DB.AsAppClass GetNewID(string sDate, string eDate, string Product)
    {
        Google_Chart_DB.AsAppClass obj = new Google_Chart_DB.AsAppClass();
        string list = string.Empty;
        using (DataSet ds = Google_Chart_DB.GetNewID(sDate,eDate,Product))
        {
            int nCount = ds.Tables[0].Rows.Count;
            if(nCount >0)
            {
                StringBuilder sb = new StringBuilder();
                obj.NewUUID_CnT = ds.Tables[0].Rows[0]["NewUUID_CnT"].ToString();
                obj.Session_CnT = ds.Tables[0].Rows[0]["Session_CnT"].ToString();
                obj.Connect_Cnt = ds.Tables[0].Rows[0]["Connect_Cnt"].ToString();
            }
            else
            {
                obj.NewUUID_CnT = "0";
                obj.Session_CnT = "0";
                obj.Connect_Cnt = "0";
            }
        }
        return obj;
    }
    
    [WebMethod]
    public static string GetList_ALL(string agc)
    {
        #region 제품별 누적 가입자 수(제품별 누적 가입자 수)
        StringBuilder sb = new StringBuilder();
       
       using ( DataSet ds = Google_Chart_DB.GetASAPP_Count("a"))
        {
            int nCount = ds.Tables[0].Rows.Count;
            if (nCount > 0)
            {
                sb.Append("<table style='width: 100 %; ' border='1'>");
                sb.Append("<tr>");
                sb.Append("<td> GDS Mobile / KDS </td><td> G - scan M </td><td>G-Scan 2</td><td> GDS </td><td> Hi-DS Preimium</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + ds.Tables[0].Rows[0]["GDS_M_CNT"].ToString() + "</td>");
                sb.Append("<td>" + ds.Tables[0].Rows[0]["GSCAN_M_CNT"].ToString() + "</td>");
                sb.Append("<td>" + ds.Tables[0].Rows[0]["GSCAN_2_CNT"].ToString() + "</td>");
                sb.Append("<td>" + ds.Tables[0].Rows[0]["GDS_CNT"].ToString() + "</td>");
                sb.Append("<td>" + ds.Tables[0].Rows[0]["HIDS_Premium_CNT"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td> Hi-DS Scanner Gold</td><td> Smart D-logger </td><td>KOTSA</td><td>EDR</td><td>Trigger</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + ds.Tables[0].Rows[0]["HIDS_Scanner_Gold_CNT"].ToString() + "</td>");
                sb.Append("<td>" + ds.Tables[0].Rows[0]["Smart_Dlogger_CNT"].ToString() + "</td>");
                sb.Append("<td>" + ds.Tables[0].Rows[0]["KOTSA_CNT"].ToString() + "</td>");
                sb.Append("<td>" + ds.Tables[0].Rows[0]["EDR_CNT"].ToString() + "</td>");
                sb.Append("<td>" + ds.Tables[0].Rows[0]["Trigger_CNT"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("</table>");
            }
            else
            {
                sb.Append("<table style='width: 100 %; ' border='1'>");
                sb.Append("<tr><td>데이터가 없습니다.</td></tr>");
                sb.Append("</table>");
            }
        }    

        return sb.ToString();
        #endregion
    }


    [WebMethod]
    public static string GetData(string sDate, string eDate, string Product)
    {

        string str = string.Empty;
        using (DataSet ds = Google_Chart_DB.GetDB_Select(sDate, eDate, Product))
        {
            // 여기에서 db 데이터 가져와서 문자열 조합하시면 될것 같습니다.

            str += "[";
            str += "['Menu', '사용이력', { role: 'style' }, { role: 'annotation' }],";
            str += "['설치', " + ds.Tables[0].Rows[0]["install"].ToString() + ", 'blue', " + ds.Tables[0].Rows[0]["install"].ToString() + "],";
            str += "['업데이트', " + ds.Tables[0].Rows[0]["Updatee"].ToString() + ", 'blue', " + ds.Tables[0].Rows[0]["Updatee"].ToString() + "],";

            str += "['구매 및 AS', " + ds.Tables[0].Rows[0]["AS"].ToString() + ", 'blue', " + ds.Tables[0].Rows[0]["AS"].ToString() + "],";
            str += "['원격지원', " + ds.Tables[0].Rows[0]["Remote"].ToString() + ", 'blue', " + ds.Tables[0].Rows[0]["Remote"].ToString() + "],";
            str += "['자주하는 질문', " + ds.Tables[0].Rows[0]["FAQ"].ToString() + ", 'blue', " + ds.Tables[0].Rows[0]["FAQ"].ToString() + "],";
            str += "['동영상가이드', " + ds.Tables[0].Rows[0]["MV"].ToString() + ", 'blue', " + ds.Tables[0].Rows[0]["MV"].ToString() + "],";
            str += "['문의하기', " + ds.Tables[0].Rows[0]["QNA"].ToString() + ", 'blue', " + ds.Tables[0].Rows[0]["QNA"].ToString() + "],";
            str += "['아이디/비밀번호', " + ds.Tables[0].Rows[0]["ID"].ToString() + ", 'blue', " + ds.Tables[0].Rows[0]["ID"].ToString() + "]";
            str += "]";
        }

        var arr = JArray.Parse(str);

        return arr.ToString();
    }

   
}