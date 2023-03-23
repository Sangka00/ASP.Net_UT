using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Data;


public partial class Chart_GoogleBarChart_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static List<object> GetChartData()
    {
        // string query = "select Country, count(country) as country_Cnt from[dbo].[TP_KR_OVERSEAS_GDSM_SERIAL] ";
        //  query = query + " Group by Country having count(country) > 100 ";
        //    string constr = ConfigurationManager.ConnectionStrings["GDSMConnectDB"].ConnectionString;

        DataList m = new DataList();

         

        List<object> chartData = new List<object>();
        //항목정의 첫번째 데이터
        chartData.Add(new object[]
        {
           "Country", "country Cnt","test","test2"
        });
        chartData.Add(new object[]
        {
           "프랑스",30,20,10
        });
          
           chartData.Add(new object[]
           {
               "영국",90,100,22
           });
           chartData.Add(new object[]
           {
               "한국",100,100,23
           });
           chartData.Add(new object[]
           {
               "일본",15,10,7
           });
           
         return chartData;
        // 항목값 만들기
       /* using (SqlConnection con = new SqlConnection(constr))
           {
               using (SqlCommand cmd = new SqlCommand(query))
               {
                   cmd.CommandType = CommandType.Text;
                   cmd.Connection = con;
                   con.Open();

                   using (SqlDataReader sdr = cmd.ExecuteReader())
                   {

                       while (sdr.Read())
                       {
                           chartData.Add(new object[]
                           {
                           sdr["Country"], sdr["country_Cnt"]
                           });

                       }

                   }
                   con.Close();
                   return chartData;
               }

           }
           */
    }
}