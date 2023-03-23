using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System;

public partial class CHART_GoogleTableCharts01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //[WebMethod]
    //public static List<object> GetChartData2()
    //{
    //    try
    //    {
    //        //DataList m = new DataList();
    //        //List<object> chartData = new List<object>();
    //        //chartData.Add(new object[]
    //        //{
    //        //    "Name", "Salary","Check","1월"
    //        //});
    //        //chartData.Add(new object[]
    //        //{
    //        //   "1월", 1000, 400
    //        //});
            
    //    }
    //    catch(Exception ex)
    //    {
            
    //    }
    


    //}
    [WebMethod]
    public static List<object> GetChartData()
    {
        DataList m = new DataList();

        List<object> chartData = new List<object>();
        //항목정의 첫번째 데이터
        chartData.Add(new object[]
        {
          
        });
        chartData.Add(new object[]
        {
           "Mike",
           "$10,000",
            "Check",
            "300"
        });
        chartData.Add(new object[]
        {
           "Jim",
           "$10,000",
            "Check",
            "390"
        });
        chartData.Add(new object[]
        {
           "Alice",
           "$10,000",
            "Check",
            "200"
        });
        chartData.Add(new object[]
        {
           "Bob",
           "$10,000",
            "Check",
            "500"
        });
        return chartData;
    }
}