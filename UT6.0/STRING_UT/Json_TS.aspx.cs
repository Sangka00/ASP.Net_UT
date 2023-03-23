using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

public partial class Sting_UT_Json_TS : System.Web.UI.Page
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
        product.Sizes = new string[] { "small","Large" };

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
        arrary.Add("Man3");
        arrary.Add(new DateTime(2002, 3, 22));

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
        lbl_Re3.Text= json.ToString();
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
        lbl_Re11.Text = DataHelper.JsonStringDataSet(a);

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
        lbl_Re12.Text = DataHelper.JsonStringDataTable(dt);
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
        result = DataHelper.XmlDataSet(a, "Root");
        lbl_Re13.Text = result;


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //JSON Array
        string json = "{   'squadName': 'Super hero squad', " +
                    "  'homeTown': 'Metro City', " +
                    "  'active': true, " +
                    "  'members': [ " +
                    "               { 'name': 'Molecule Man', " +
                    "                 'age': 29, " +
                    "                 'powers': [ " +
                    "                             'Radiation resistance', " +
                    "                             'Turning tiny', " +
                    "                           ] " +
                    "               }, " +
                    "               { " +
                    "                 'name': 'Madame Uppercut', " +
                    "                 'age': 39, " +
                    "                 'powers': [ " +
                    "                             'Million tonne punch', " +
                    "                           ] " +
                    "               }, " +
                    "               { " +
                    "                 'name': 'Eternal Flame', " +
                    "                 'age': 1000000, " +
                    "                 'powers': [ " +
                    "                             'Immortality', " +
                    "                             'Heat Immunity', " +
                    "                           ] " +
                    "               } " +
                    "             ] " +
                    "}";

        // Native Object 사용 방법
        JObject jObject = JObject.Parse(json);
    
        Response.Write(jObject["squadName"]+"<br>");
        Response.Write(jObject["homeTown"] + "<br>");
        Response.Write(jObject["active"] + "<br>");
        JToken jToken = jObject["members"];
        Response.Write(jToken.Count().ToString());
        for(int i =0; i< jToken.Count(); i++)
        {
            Response.Write("name ::" +jToken[i]["name"] +"<br>");
            Response.Write("age ::" + jToken[i]["age"] + "<br>");
            Response.Write("powers ::" + jToken[i]["powers"] + "<br>");
        }
        //for (int i =0; i < jObject.Count; i++)
        //{   

        //   // Response.Write(jObject["members"][i]);
        //}

        // Json Data 전체 출력
        //  Response.Write(jObject.ToString());

        // JSON 데이터 중 'Radiation resistance' 데이터까지 접근하는 방법
        //  Response.Write(jObject["members"][0]["powers"][0]);

        // JSON 데이터 하위 객체인 members 객체의 name 값을 반복적으로 접근하는 방법
        //JToken jToken = jObject["members"];
        //foreach (JToken members in jToken)
        //{
        //  //  Response.Write(members["name"]+"<br>");
        //  //  Response.Write(members["powers"] + "<br>");

        //}


        /////////////////////////////////////////////////
        // 역직렬화(Deserialize) 방법
        /////////////////////////////////////////////////

        //// 역직렬화 수행 후 미리 선언한 클래스에 저장
        //Root rootObject = JsonConvert.DeserializeObject<Root>(json);

        //// JSON 데이터 중 'Radiation resistance' 데이터까지 접근하는 방법
        //Console.WriteLine(rootObject.members[0].powers[0]);

        //// JSON 데이터 하위 객체인 members 객체의 name 값을 반복적으로 접근하는 방법
        //foreach (Members members in rootObject.members)
        //{
        //    Console.WriteLine(members.name);
        //}

        ///////////////////////////////////////////////////
        //// 직렬화(Serialize) 방법
        ///////////////////////////////////////////////////

        //// 직렬화 수행 후 string 변수에 저장
        //string serializeResult = JsonConvert.SerializeObject(rootObject);

        //// Json Data 전체 출력
        //Console.WriteLine(serializeResult)

    }


    // 역직렬화를 위한 클래스 선언
    public class Root
    {
        public string squadName;
        public string homeTown;
        public string active;
        public List<Members> members;
    }
    public class Members
    {
        public string name;
        public string age;
        public List<string> powers;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        //JSON Array
        string json = "{ \"Device\": \"ComputerName\",\"IP\": \"127.0.0.1\", ";
               json = json + " \"PP\": [{ ";
               json = json + " \"IFNUM\": \"IRV-0009\", ";
               json = json + " \"ZFLAG\": \"I\", ";
               json = json + " \"RSDAT\": \"2022-10-06\",";
               json = json + " \"BWART\": \"311\",";
               json = json + " \"UMWRK\": \"5201\",";
               json = json + " \"UMLGO\": \"2102\",";
               json = json + " \"WEMPF\": \"admin\",";
               json = json + " \"MATNR\": \"7297983\",";
               json = json + " \"BDMNG\": 100,";
               json = json + " \"MEINS\": \"EA\",";
               json = json + " \"WERKS\": \"5201\",";
               json = json + " \"LGORT\": \"1100\",";
               json = json + " \"CHARG\": \"1013202710\",";
               json = json + " \"ERSDA\": \"2022-10-06\",";
               json = json + " \"ERNAM\": \"user\"";
               json = json + " }, ";
               json = json + "{";
                json = json + " \"IFNUM\": \"IRV -0009\",";
                json = json + " \"ZFLAG\": \"I\",";
                json = json + " \"RSDAT\": \"2022 -10-06\",";
                json = json + " \"BWART\": \"311\",";
                json = json + " \"UMWRK\": \"5201\",";
                json = json + " \"UMLGO\": \"2102\",";
                json = json + " \"WEMPF\": \"admin\",";
                json = json + " \"MATNR\": \"7297983\",";
                json = json + " \"BDMNG\": 100,";
                json = json + " \"MEINS\": \"EA\",";
                json = json + " \"WERKS\": \"5201\",";
                json = json + " \"LGORT\": \"1100\",";
                json = json + " \"CHARG\": \"1013202710\",";
                json = json + " \"ERSDA\": \"2022 -10-06\",";
                json = json + " \"ERNAM\": \"user\" ";
                json = json + "}";
                json = json + "]";
                json = json + "}";


        JObject jObject = JObject.Parse(json);

        Response.Write(jObject["Device"] + "<br>");
        Response.Write(jObject["IP"] + "<br>");
     
        JToken jToken = jObject["PP"];
        Response.Write(jToken.Count().ToString());
        for (int i = 0; i < jToken.Count(); i++)
        {
            Response.Write("name ::" + jToken[i]["IFNUM"] + "<br>");
            Response.Write("age ::" + jToken[i]["ZFLAG"] + "<br>");
            Response.Write("powers ::" + jToken[i]["RSDAT"] + "<br>");
        }
    }
}