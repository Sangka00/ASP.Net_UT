using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class DataTable_DataSET_TS01 : System.Web.UI.Page
{
    static  DataSet DS = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void But_DataSET01_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DT = new DataTable("TradeList");
            DT.Columns.Add(new DataColumn("MaterialCode", typeof(string))); //코드
            DT.Columns.Add(new DataColumn("UnitName", typeof(string))); //단위명
            DT.Columns.Add(new DataColumn("Quantity", typeof(int))); //수량
            DT.Columns.Add(new DataColumn("BuyCost", typeof(decimal)));//단가
            DT.Columns.Add(new DataColumn("State", typeof(int)));//단가
            DT.Columns.Add(new DataColumn("Remark", typeof(string))); //단위명
            DataRow row = null;
            for (int i = 0; i < 1000; i++)
            {
                row = DT.NewRow(); //행 추가
                row["MaterialCode"] = "MaterialCode" + i.ToString();
                row["UnitName"] = "UnitName" + i.ToString();
                row["Quantity"] = i;
                row["BuyCost"] = i; ;
                row["State"] = i;
                row["Remark"] = "Remark" + i.ToString();
                DT.Rows.Add(row);
            }
          
            Response.Write(DT.Rows[0][1].ToString());
            DS.Tables.Add(DT);
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
       
            

    }
    /// <summary>
    /// 그룹핑과 서브토탈을 지원하는 엑셀 출력 및 다운로드 헬퍼
    /// </summary>
    /// <param name="donwloadFileName">다운로드할 파일명</param>
    /// <param name="ds">데이타셋</param>
    /// <param name="tableNo">해당 테이블 인텍스(0부터)</param>
    /// <param name="columnList">출력 컬럼명 목록</param>
    /// <param name="headerText">출력 컬럼명의 제목 텍스트, 없으면 빈 배열</param>
    /// <param name="startGroupColNo">그룹핑 시작 컬럼 번호(columnList의 인덱스), -1이면 미사용</param>
    /// <param name="endGroupColNo">그룹핑 종료 컬럼 번호(columnList의 인덱스), startGroupColNo랑 같거나 커야함</param>
    /// <param name="startGroupTotalColNo">그룹핑 컬럼 내에서의 서브토탈 컬럼 시작 컬럼 번호(columnList의 인덱스), -1 이면 미사용</param>
    /// <param name="endGroupTotalColNo">그룹핑 컬럼 내에서의 서브토탈 컬럼 종료 컬럼 번호(columnList의 인덱스), startGroupTotalColNo 보다 같거나 커야함</param>
    /// <param name="listGroupTotal">총합을 표시할 컬럼 인덱스 번호(columnList의 인덱스), 없으면 빈 배열</param>
    /// <returns>성공하면 true</returns>
    protected void Btn_ExcelDown_Click(object sender, EventArgs e)
    {
        
        foreach (DataRow rowa in DS.Tables[0].Rows)
        {
        //    Response.Write("<BR>" + rowa["MaterialCode"] + "::" + rowa["UnitName"] + "::" + rowa["Quantity"]);
        }
        // Response.Write("<BR>");

        try
        {
            this.EnableViewState = false;

            if (!WSF.Helper.ExcelHelper.DownloadExcelFromDataSet("Search.xls", DS, 0,
                new string[] { "MaterialCode", "UnitName", "Quantity", "BuyCost", "State", "Remark" },
                new string[] { "M1", "U1", "Q1", "B1", "S1", "R1" },
                -1, -1,  //엑셀안에서 그룹핑하는거 그룹핑 할 경우 시작열번호,마지막열번호 (그룹핑 하지 않을 경우 -1, -1)
                -1, -1,
                new int[] { }
                ))
            {
                Response.Write("오류");
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
        
    }
}