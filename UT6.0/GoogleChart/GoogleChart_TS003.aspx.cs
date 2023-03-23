using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GoogleChart_GoogleChart_TS003 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static List<object> GetChartData()
    {
        string query = "SELECT ShipCity, COUNT(orderid) TotalOrders";
        query += " FROM Orders WHERE ShipCountry = 'USA' GROUP BY ShipCity";
     //   string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
        {
            "PRoc", "TotalOrders", "annotation"
        });

        chartData.Add(new object[] {"설치",20,"20"});
        chartData.Add(new object[] { "업데이트", 30 ,  "20" });
        chartData.Add(new object[] { "아이디/비밀번호", 40, "20" });
        chartData.Add(new object[] { "구매 및 AS", 50,  "20" });
        chartData.Add(new object[] { "원격지원", 60 ,  "20" });
        chartData.Add(new object[] { "자주하는 질문", 60 ,  "20" });
        chartData.Add(new object[] { "동영상가이드", 60,  "20" });
        chartData.Add(new object[] { "문의하기", 60 ,  "20" });
        

        // using (SqlConnection con = new SqlConnection(constr))
        // {
        //    using (SqlCommand cmd = new SqlCommand(query))
        //   {
        //     cmd.CommandType = CommandType.Text;
        //   cmd.Connection = con;
        // con.Open();
        // using (SqlDataReader sdr = cmd.ExecuteReader())
        // {
        //   while (sdr.Read())
        // {
        //   chartData.Add(new object[]
        // {
        // sdr["ShipCity"], sdr["TotalOrders"]
        // });
        // }
        //  }
        // con.Close();
        return chartData;
           // }
      //  }
    }


    [WebMethod]
    public static string  GetChartData2()
    {
        string query = "SELECT ShipCity, COUNT(orderid) TotalOrders";
        query += " FROM Orders WHERE ShipCountry = 'USA' GROUP BY ShipCity";
        //   string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        string result = "[[\"Element\", \"Density\", { \"role\": \"annotation\" }],[\"Copper\", 8.94, \"8.94\"], [\"Silver\",10.49, \"10.49\"],[\"Gold\", 19.30, \"19.30\"],[\"Platinum\", 21.45,\"21.45\"]]";
                
        // using (SqlConnection con = new SqlConnection(constr))
        // {
        //    using (SqlCommand cmd = new SqlCommand(query))
        //   {
        //     cmd.CommandType = CommandType.Text;
        //   cmd.Connection = con;
        // con.Open();
        // using (SqlDataReader sdr = cmd.ExecuteReader())
        // {
        //   while (sdr.Read())
        // {
        //   chartData.Add(new object[]
        // {
        // sdr["ShipCity"], sdr["TotalOrders"]
        // });
        // }
        //  }
        // con.Close();
        return result;
        // }
        //  }
    }
}