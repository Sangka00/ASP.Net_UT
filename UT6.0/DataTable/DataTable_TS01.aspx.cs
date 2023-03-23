using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataTable_DataTable_TS01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //DataTable 필드 단위입력
        DataTable table = new DataTable();
        DataRow row = null;

        //Field define
        table.Columns.Add(new DataColumn("Name", typeof(string)));
        table.Columns.Add(new DataColumn("AGE", typeof(int)));

        for(int i =0; i <1000; i++)
        {
            row = table.NewRow(); //행 추가
            row["Name"] = "홍길동"+ i.ToString();
            row["AGE"] = i;
            table.Rows.Add(row);
        }

        foreach (DataRow rowa in table.Rows)
        {
            Response.Write("<BR>" + rowa["Name"] + "::" + rowa["AGE"]);
        }
        Response.Write("<BR>");
        Response.Write(table.Rows[0][1].ToString());


    }
    //Object 배열로 밀어 넣기
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable table = new DataTable();
        DataRow row = null;
        //field define
        table.Columns.Add(new DataColumn("Name", typeof(string)));
        table.Columns.Add(new DataColumn("AGE", typeof(int)));

        row = table.NewRow();
        row.ItemArray = new object[] { "홍길동", 10 };

        row = table.NewRow();
        row.ItemArray = new object[] { "둘리", 20 };
        table.Rows.Add(row);

        Response.Write(table.Rows[0][1].ToString());
    }

    //GetInputParamDataTable
    protected void Button3_Click(object sender, EventArgs e)
    {
        DataTable inputParamTable = GetInputParamDataTable();
        inputParamTable.Rows.Add("memu_id", "", 10);
        inputParamTable.Rows.Add("group", "alphanum", 8);
        inputParamTable.Rows.Add("search_param", "json", 512);
        inputParamTable.Rows.Add("modelcd", "alphanum", 6);
        inputParamTable.Rows.Add("modelyr", "alphanum", 4);
        inputParamTable.Rows.Add("enginecd", "alphanum", 6);
        // set json input param table
        DataTable inputJsonParamTable = GetInputParamDataTable();
        inputJsonParamTable.Rows.Add("search_text", "", 128);
        inputJsonParamTable.Rows.Add("modelsn", "", 10);
        inputJsonParamTable.Rows.Add("modelyr", "", 4);
    }

    private DataTable GetInputParamDataTable()
    {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("name", typeof(string));
        dataTable.Columns.Add("type", typeof(string));
        dataTable.Columns.Add("size", typeof(int));

        return dataTable;
    }
}