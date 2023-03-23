using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using System.Configuration;

public partial class CHART_GoogleLineChart_WithDB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static List<object> GetChartData()
    {
        // string query = "SELECT ZEILE , Count(ZEILE) as cnt  FROM [ExPle].[mesuser].[IF_PROD_RES] GROUP by ZEILE";
        string query = "SELECT ERNam, count(ERNAM)+3 as ERNAMCnt, count(PosNR) as PosNR from[mesuser].[IF_SO] GRoup by ERNAM";
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        List<object> chartData = new List<object>();
        chartData.Add(new object[]
        {
        "ERNam", "ERNAMCnt", "PosNR"
        });
        using(SqlConnection con = new SqlConnection(constr))
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
                        sdr["ERNam"], sdr["ERNAMCnt"], sdr["PosNR"]
                        });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

}