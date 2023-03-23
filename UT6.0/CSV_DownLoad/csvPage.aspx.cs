using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CSV_DownLoad_csvPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.ContentType = "application/CSV";

            Response.Charset = "utf-8";
            Session.CodePage = 949;//65001;

            // attachment 넣으면 다운로드됨
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "exportFileName" + ".csv");
            WriteCsv(Request["userName"], Request["date"]);

            Response.Flush();
            Response.SuppressContent = true;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch(Exception ex){
            throw ex;
        }
    }

    public void WriteCsv(string userName, string date)
    {
       // DataTable dt = new DataTable();

        //DataTable에 전달 받은 매개변수를 통해 추출할 목록을 DB에서 가져온다.
       // dt = GetTableList(string userName, string date);
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(string));
        dt.Columns.Add("subject", typeof(string));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("AGE", typeof(string));
       
        for (int i=0; i< 10000; i++)
        {
            DataRow dr = dt.NewRow();
            dr["ID"] = "ID1";
            dr["subject"] = "subject1";
            dr["NAME"] = "111";
            dr["AGE"] = 1;
            dt.Rows.Add(dr);
        }
        //DataRow dr = dt.NewRow();
        //dr["ID"] = "ID1";
        //dr["subject"] = "subject1";
        //dr["NAME"] = "111";
        //dr["AGE"] = 1;
        //dt.Rows.Add(dr);

        //DataRow dr2 = dt.NewRow();
        //dr2["ID"] = "ID2";
        //dr2["subject"] = "subject2";
        //dr2["NAME"] = "222";
        //dr2["AGE"] = 2;
        //dt.Rows.Add(dr2);

        //DataRow dr3 = dt.NewRow();
        //dr3["ID"] = "ID3";
        //dr3["subject"] = "subject3";
        //dr3["NAME"] = "333";
        //dr3["AGE"] = 3;
        //dt.Rows.Add(dr3);

        if (dt != null)
        {
            //헤더라인
            HttpContext.Current.Response.Write(string.Format("{0},{1},{2},{3}", "아이디", "subject", "Name", "AGE"));
            HttpContext.Current.Response.Write(Environment.NewLine);

            //내용
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    HttpContext.Current.Response.Write(Convert.ToString(row[col]).Replace(",", "\",\"") + ",");
                }
                HttpContext.Current.Response.Write(Environment.NewLine);
            }
        }
    }
}