using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

public partial class JSON_JSON_ProC : System.Web.UI.Page
{
    class Product
    {
        public string name;
        public DateTime Expiry;
        public string[] Sizes;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Bnt_Serialize_Click(object sender, EventArgs e)
    {
        // Serialize (객체 -> JSON 문자열)
        Product product = new Product();
        product.name = "Apple";
        product.Expiry = new DateTime(2009, 12, 12);
        product.Sizes = new string[] { "small", "Large" };

        string json = JsonConvert.SerializeObject(product);
        lbl_Re.Text = json;
    }
    class Movie
    {
        public string name;
        public DateTime ReleaseDate;
        public string[] Genres;
    }
    protected void Bnt_Deserialize_Click(object sender, EventArgs e)
    { // Deserialize (JSON 문자열 -> 객체)
        string json = @"{   'Name': 'Bad Boys', 
                            'ReleaseDate': '1995-4-7T00:00:00', 
                            'Genres': [     'Action',     'Comedy'   ] }";
        Movie m = JsonConvert.DeserializeObject<Movie>(json);
        lbl_Re1.Text = m.name;

    }
    protected void Bnt_LinQtoJSON_Click(object sender, EventArgs e)
    {
        JArray arrary = new JArray();
        arrary.Add("Manual Text");
        arrary.Add(new DateTime(2000, 5, 23));
        arrary.Add("Man2");
        arrary.Add(new DateTime(2001, 1, 22));

        JObject o = new JObject();
        o["myArray"] = arrary;
        string json = o.ToString();
        lbl_Re2.Text = json;
    }
    protected void Bnt_JObject_Click(object sender, EventArgs e)
    {
        var json = new JObject();
        json.Add("id", "Luna");
        json.Add("name", "Luna");
        json.Add("age", 19);
        lbl_Re3.Text = json.ToString();
    }
    protected void Bnt_JObjectParse_Click(object sender, EventArgs e)
    {
        // JSON 형식의 문자열로 생성
        var json2 = JObject.Parse("{id:\"Luna\",name:\"Silver\", age:19}");
        json2.Add("blog", "devluna.blogspot.kr");
        lbl_Re4.Text = json2.ToString();
    }
    protected void Bnt_JOBjectFromOject_Click(object sender, EventArgs e)
    { //무형식으로 생성
        var json4 = JObject.FromObject(new { id = "101", name = "June", age = 23 });
        lbl_Re5.Text = json4.ToString();
    }

    protected void Bnt_JObjectElement_Click(object sender, EventArgs e)
    {
        // 다른 JObject를 Element 추가
        var json4 = JObject.FromObject(new { id = "101", name = "June", age = 23 });
        var json5 = JObject.Parse("{ id : \"sjy\" , name : \"seok-joon\" , age : 27 }");
        json5.Add("friend1", json4);
        lbl_Re6.Text = json5.ToString();
    }

    protected void Bnt_JObjectElement_Read_Del_Click(object sender, EventArgs e)
    {
        //Element Read , Delete
        var json4 = JObject.FromObject(new { id = "101", name = "June", age = 23 });
        var json4_name = json4["name"];
        Response.Write(json4_name + "<br>");
        Response.Write(json4 + "<br>");
        json4.Remove("name");
        lbl_Re7.Text = json4.ToString();
    }

    protected void Bnt_JArray_Click(object sender, EventArgs e)
    {
        // Element 입력시 Key를 가지지 않는 다는 것 빼고 Oject와 비슷함
        JObject json1 = JObject.FromObject(new { id = "101", name = "June", age = 23 });
        JObject json2 = JObject.FromObject(new { id = "102", name = "Juy", age = 24 });
        JObject json3 = JObject.FromObject(new { id = "103", name = "Jui", age = 25 });
        var jj = new JArray();
        jj.Add(json1);
        jj.Add(json2);
        jj.Add(json3);
        string _s = string.Empty;

        foreach (JObject fe in jj)
        {
            var fname = fe["name"];
            _s = _s + fname;
        }
        lbl_Re8.Text = _s;

    }
    protected void Bnt_parse_count_Click(object sender, EventArgs e)
    {
        JObject json1 = JObject.FromObject(new { id = "101", name = "June", age = 23 });
        JObject json2 = JObject.FromObject(new { id = "102", name = "June", age = 23 });
        int icolcount = json1.Count;
        lbl_Re9.Text = icolcount.ToString();

    }

    protected void Bnt_GetJsonValue_Click(object sender, EventArgs e)
    {
        // json object name to Search Value
        JObject json1 = JObject.FromObject(new { id = "101", name = "June", age = 23 });
        string sResult = string.Empty;

        sResult = json1.GetValue("id").ToString();
        lbl_Re10.Text = sResult;
    }
    protected void bnt_JsonStringDataSet_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("AGE", typeof(string));

        DataRow dr = dt.NewRow();
        dr["Name"] = "sangka";
        dr["AGE"] = "100";
        dt.Rows.Add(dr);

        DataRow dr2 = dt.NewRow();
        dr2["Name"] = "kkkg";
        dr2["AGE"] = "70";
        dt.Rows.Add(dr2);

        DataRow dr3 = dt.NewRow();
        dr3["NAME"] = "333";
        dr3["AGE"] = "3";
        dt.Rows.Add(dr3);

        int nCount = dt.Rows.Count;
        DataSet a = new DataSet();
        a.Tables.Add(dt);
        lbl_Re11.Text = JsonHelper.JsonStringDataSet(a);

    }

    protected void bnt_JsonStringDataTable_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("AGE", typeof(string));

        DataRow dr = dt.NewRow();
        dr["Name"] = "sangka";
        dr["AGE"] = "100";
        dt.Rows.Add(dr);

        DataRow dr2 = dt.NewRow();
        dr2["Name"] = "kkkg";
        dr2["AGE"] = "70";
        dt.Rows.Add(dr2);

        DataRow dr3 = dt.NewRow();
        dr3["NAME"] = "333q";
        dr3["AGE"] = "3";
        dt.Rows.Add(dr3);
        lbl_Re12.Text = JsonHelper.JsonStringDataTable(dt);
    }

    protected void Bnt_XmlDataSet_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("AGE", typeof(string));

        DataRow dr = dt.NewRow();
        dr["Name"] = "sangka";
        dr["AGE"] = "100";
        dt.Rows.Add(dr);

        DataRow dr2 = dt.NewRow();
        dr2["Name"] = "kkkg";
        dr2["AGE"] = "70";
        dt.Rows.Add(dr2);

        DataRow dr3 = dt.NewRow();
        dr3["NAME"] = "333";
        dr3["AGE"] = "3";
        dt.Rows.Add(dr3);

        int nCount = dt.Rows.Count;

        DataSet a = new DataSet();
        a.Tables.Add(dt);
        string result = string.Empty;
        result = JsonHelper.XmlDataSet(a, "Root");
        lbl_Re13.Text = result;


    }


    protected void Button1_Click(object sender, EventArgs e)
    {
       // string str = "{\"ContentEncoding\":null,\"ContentType\":null,\"Data\":{\"error\":false,\"model\":10},\"JsonRequestBehavior\":1,\"MaxJsonLength\":null,\"RecursionLimit\":null}";

        var json5 = JObject.Parse("{\"ContentEncoding\":22,\"ContentType\":null,\"Data\":{\"error\":false,\"model\":10},\"JsonRequestBehavior\":1,\"MaxJsonLength\":null,\"RecursionLimit\":null}");



        string sResult = json5.GetValue("ContentEncoding").ToString();
       string ss =   sResult;
    }
}