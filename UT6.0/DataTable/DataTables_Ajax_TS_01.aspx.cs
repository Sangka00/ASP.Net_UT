using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Script.Serialization;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json.Linq;
public partial class DataTable_DataTables_Ajax_TS_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var json = new JObject();
        json.Add("id", "1");
        json.Add("name", "Tiger Nixon");
        json.Add("position", "System Architect");
        json.Add("salary", "$320,800");
        json.Add("start_date", "2011/04/25");
        json.Add("office", "Edinburgh");
        json.Add("extn", "5421");


        var json1 = new JObject();
        json1.Add("id", "2");
        json1.Add("name", "Garrett Winter");
        json1.Add("position", "Accountant");
        json1.Add("salary", "$170,750");
        json1.Add("start_date", "2011/07/25");
        json1.Add("office", "Tokyo");
        json1.Add("extn", "8422");

        var json2 = new JObject();
        json2.Add("id", "3");
        json2.Add("name", "Ashton");
        json2.Add("position", "Junior Technical Author");
        json2.Add("salary", "$86,000");
        json2.Add("start_date", "2009/01/12");
        json2.Add("office", "San Francisco");
        json2.Add("extn", "1562");

        var j = new JArray();
        j.Add(json);
        j.Add(json1);
        j.Add(json2);
        var jj = new JObject();
        jj.Add("data", j);
        //  Response.Write(jj.ToString());
    }
    [WebMethod]
    public static string GetList()
    {
        try
        {
            string returnValue = string.Empty;
            List<object> obj = new List<object>();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("position", typeof(string));
            dt.Columns.Add("salary", typeof(string));
            dt.Columns.Add("start_date", typeof(string));
            dt.Columns.Add("office", typeof(string));
            dt.Columns.Add("extn", typeof(string));

            Random rnd = new Random();

            DataRow dr = dt.NewRow();
            for (int i = 1; i < 100; i++)
            {
                dr = dt.NewRow();
                dr["id"] = i.ToString();
                dr["Name"] = "Tiger Nixon";
                dr["position"] = "System Architect" + i.ToString();
                dr["salary"] = rnd.Next(100, 10000).ToString();
                dr["start_date"] = "2011/04/25" + i.ToString();
                dr["office"] = "Edinburgh";
                dr["extn"] = rnd.Next(10, 1000).ToString();
                dt.Rows.Add(dr);
            }



            int nCount = dt.Rows.Count;
            if (nCount > 0)
            {
                for (int i = 0; i < nCount; i++)
                {
                    obj.Add(new
                    {
                        // 여기에서 정의한, NAME, AGE는 자바스크립에서 사용될 변수입니다.
                        // dt.Rows[i]["NAME"].ToString() --> 이거는 DB 컬럼명입니다.
                        id = dt.Rows[i]["id"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        position = dt.Rows[i]["position"].ToString(),
                        salary = dt.Rows[i]["salary"].ToString(),
                        start_date = dt.Rows[i]["start_date"].ToString(),
                        office = dt.Rows[i]["office"].ToString(),
                        extn = dt.Rows[i]["extn"].ToString()
                    });
                }
                string temp = new JavaScriptSerializer().Serialize(obj);
                return (new JavaScriptSerializer().Serialize(obj));
            }

            return returnValue;
        }
        catch (Exception ex)
        {
            return (new JavaScriptSerializer().Serialize(ex.ToString()));
        }
    }
}