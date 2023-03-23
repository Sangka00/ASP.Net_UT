using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Web.UI.WebControls;
using System.Web.UI;

using System.IO;

/// <summary>
/// Google_Chart_DB의 요약 설명입니다.
/// </summary>
public class Google_Chart_DB
{
    public static Database Db = DatabaseFactory.CreateDatabase("ConnectDB2");
    public Google_Chart_DB()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }
    public static DataSet GetNewID(string sDate, string eDate, string Product)
    {
        // 1. 기간내 신규 가입자, 2. UUID 중복제거한 접속횟수 3. UUID 접속횟수
        string SQL = string.Empty;

        SQL = "SELECT ";
        SQL += "  ( ";
        SQL += " SELECT Count(Distinct(a.UUID))  ";
        SQL += " FROM  [ASAPP].[dbo].[ASAPP_UUID_TBL] A , [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] B ";
        SQL += " Where A.UUID = B.UUID ";
        SQL += "  AND A.Inputdate >= @sDate And A.Inputdate <= @eDate ";
        if( Product !="ALL")
        {
            SQL += " AND B.PRODUCT=@Product ";
        }
        SQL += " ) as NewUUID_CnT,";

        SQL += "  ( ";
        SQL += " SELECT COUNT( Distinct(a.UUID) ) ";
        SQL += " FROM [ASAPP].[dbo].[ASAPP_USE_MenuHISTORY]  A , [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] B ";
        SQL += "  Where A.UUID = B.UUID ";
        SQL += "  AND A.Inputdate >= @sDate And A.Inputdate <= @eDate ";
        if (Product != "ALL")
        {
            SQL += " AND B.PRODUCT=@Product ";
        }
        SQL += " ) AS Session_CnT, ";

        SQL += " ( ";
        SQL += " SELECT COUNT( a.UUID )  ";
        SQL += " FROM [ASAPP].[dbo].[ASAPP_USE_MenuHISTORY]  A , [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] B ";
        SQL += "  Where A.UUID = B.UUID ";
        SQL += " AND A.Inputdate >= @sDate And A.Inputdate <= @eDate ";
        if (Product != "ALL")
        {
            SQL += " AND B.PRODUCT=@Product ";
        }
        SQL += " ) AS Connect_Cnt ";

        DataSet dsResult = new DataSet();

        try
        {
            using (DbCommand cmd = Db.GetSqlStringCommand(SQL))
            {
                cmd.CommandTimeout = 3000;
                Db.AddInParameter(cmd, "@sDate", DbType.String, sDate);
                Db.AddInParameter(cmd, "@eDate", DbType.String, eDate);
                Db.AddInParameter(cmd, "@Product", DbType.String, Product);

                dsResult = Db.ExecuteDataSet(cmd);

                return dsResult;
            }
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex);
        }
        return dsResult;

    }
    public static DataSet GetDB_Select(string sDate, string eDate, string Product)
    {
        string SQL = string.Empty;

        SQL = " select ";
        SQL += " ( ";
        SQL += " SELECT    count(b.uuid)  FRom  [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] a,  [ASAPP].[dbo].[ASAPP_USE_MenuHISTORY] b ";
        SQL += " Where a.UUID = b.uuid ";
        if( Product != "ALL")
        {
            SQL += " AND a.PRODUCT = @Product ";
        }       
        
        SQL += " AND b.USE_Menu = '설치' ";
        SQL += "  AND b.Inputdate >= CONVERT (DATE, @sDate)  And b.Inputdate <= CONVERT (DATE, @eDate)  ";
        SQL += " ) as install , ";

        SQL += " ( ";
        
        SQL += "  SELECT    count(b.uuid) FRom  [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] a,  [ASAPP].[dbo].[ASAPP_USE_MenuHISTORY] b ";
        SQL += " Where a.UUID = b.uuid ";
        if (Product != "ALL")
        {
            SQL += " AND a.PRODUCT = @Product ";
        }
        SQL += " AND b.USE_Menu='업데이트'";
        SQL += " AND b.Inputdate >= CONVERT (DATE, @sDate)  And b.Inputdate <= CONVERT (DATE, @eDate) ";
        SQL += " ) as Updatee, ";

        SQL += " ( ";
        SQL += "  SELECT    count(b.uuid) FRom  [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] a,  [ASAPP].[dbo].[ASAPP_USE_MenuHISTORY] b ";
        SQL += " Where a.UUID = b.uuid ";
        if (Product != "ALL")
        {
            SQL += " AND a.PRODUCT = @Product ";
        }
        SQL += " AND b.USE_Menu='구매 및 AS'";
        SQL += " AND b.Inputdate >= CONVERT (DATE, @sDate)  And b.Inputdate <= CONVERT (DATE, @eDate) ";
        SQL += " ) as [AS], ";

        SQL += " ( ";
        SQL += "  SELECT    count(b.uuid) FRom  [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] a,  [ASAPP].[dbo].[ASAPP_USE_MenuHISTORY] b ";
        SQL += " Where a.UUID = b.uuid ";
        if (Product != "ALL")
        {
            SQL += " AND a.PRODUCT = @Product ";
        }
        SQL += " AND b.USE_Menu='원격지원'";
        SQL += " AND b.Inputdate >= CONVERT (DATE, @sDate)  And b.Inputdate <= CONVERT (DATE, @eDate) ";
        SQL += " ) as Remote, ";

        SQL += " ( ";
        SQL += "  SELECT    count(b.uuid) FRom  [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] a,  [ASAPP].[dbo].[ASAPP_USE_MenuHISTORY] b ";
        SQL += " Where a.UUID = b.uuid ";
        if (Product != "ALL")
        {
            SQL += " AND a.PRODUCT = @Product ";
        }
        SQL += " AND b.USE_Menu='자주하는 질문'";
        SQL += " AND b.Inputdate >= CONVERT (DATE, @sDate)  And b.Inputdate <= CONVERT (DATE, @eDate) ";
        SQL += " ) as FAQ, ";

        SQL += " ( ";
        SQL += "  SELECT    count(b.uuid) FRom  [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] a,  [ASAPP].[dbo].[ASAPP_USE_MenuHISTORY] b ";
        SQL += " Where a.UUID = b.uuid ";
        if (Product != "ALL")
        {
            SQL += " AND a.PRODUCT = @Product ";
        }
        SQL += " AND b.USE_Menu='동영상가이드'";
        SQL += " AND b.Inputdate >= CONVERT (DATE, @sDate)  And b.Inputdate <= CONVERT (DATE, @eDate) ";
        SQL += " ) as MV, ";

        SQL += " ( ";
        SQL += "  SELECT    count(b.uuid) FRom  [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] a,  [ASAPP].[dbo].[ASAPP_USE_MenuHISTORY] b ";
        SQL += " Where a.UUID = b.uuid ";
        if (Product != "ALL")
        {
            SQL += " AND a.PRODUCT = @Product ";
        }
        SQL += " AND b.USE_Menu='문의하기'";
        SQL += " AND b.Inputdate >= CONVERT (DATE, @sDate)  And b.Inputdate <= CONVERT (DATE, @eDate) ";
        SQL += " ) as QNA, ";

        SQL += " ( ";
        SQL += " SELECT count(b.uuid) FRom  [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] a,  [ASAPP].[dbo].[ASAPP_USE_MenuHISTORY] b ";
        SQL += " Where a.UUID = b.uuid ";
        if (Product != "ALL")
        {
            SQL += " AND a.PRODUCT = @Product ";
        }
        SQL += " AND b.USE_Menu='아이디/비밀번호'";
        SQL += " AND b.Inputdate >= CONVERT (DATE, @sDate)  And b.Inputdate <= CONVERT (DATE, @eDate) ";
        SQL += " ) as ID ";

        DataSet dsResult = new DataSet();

        try
        {
            using (DbCommand cmd = Db.GetSqlStringCommand(SQL))
            {
                cmd.CommandTimeout = 3000;
                Db.AddInParameter(cmd, "@sDate", DbType.String, sDate);
                Db.AddInParameter(cmd, "@eDate", DbType.String, eDate);                
                Db.AddInParameter(cmd, "@Product", DbType.String, Product);                

                dsResult = Db.ExecuteDataSet(cmd);
              
                return dsResult;
            }
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex);
        }
        return dsResult;
    }

    public static DataSet GetASAPP_Count(string Area)
    {
        string SQL = string.Empty;

        SQL = @" SELECT 
              ( SELECT  COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_UUID_TBL] ) AS UUID_CNT, 
              (	SELECT COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Where PRODUCT ='GDS Mobile / KDS' ) as GDS_M_CNT,
              (	SELECT COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Where PRODUCT ='G-scan M'  ) as GSCAN_M_CNT, 
              (	SELECT COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Where PRODUCT ='G-scan 2' ) as GSCAN_2_CNT,
              (	SELECT COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Where PRODUCT ='GDS')  as GDS_CNT ,
              (	SELECT COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Where PRODUCT ='HI-DS Premium') as HIDS_Premium_CNT,
              (	SELECT COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Where PRODUCT ='HI-DS Scanner Gold' ) as HIDS_Scanner_Gold_CNT,
              (	SELECT COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Where PRODUCT ='Smart D-logger') as Smart_Dlogger_CNT,
              (	SELECT COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Where PRODUCT ='KOTSA') as KOTSA_CNT,
              (	SELECT COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Where PRODUCT ='EDR') as EDR_CNT,
              (	SELECT COUNT(Distinct(UUID))  FROM [ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Where PRODUCT ='Trigger') as Trigger_CNT";
        DataSet dsResult = new DataSet();

        try
        {
            using (DbCommand cmd = Db.GetSqlStringCommand(SQL))
            {
                cmd.CommandTimeout = 3000;               

                dsResult = Db.ExecuteDataSet(cmd);

                return dsResult;
            }
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex);
        }
        return dsResult;

    }

    public static DataSet GetProduct()
    {
        String SQL = string.Empty;
        SQL = " SELECT Distinct(Product) as Product FROM[ASAPP].[dbo].[ASAPP_PRODUCT_TBL] Order by Product asc";
        DataSet dsResult = new DataSet();
        try
        {
            using (DbCommand cmd = Db.GetSqlStringCommand(SQL))
            {
                //  전체 버전 한 번에 읽기
                cmd.CommandTimeout = 3000;
                dsResult = Db.ExecuteDataSet(cmd);
                return dsResult;
            }

        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex);
        }
        return dsResult;

    }


    public class AsAppClass
    {
        public string NewUUID_CnT; // 신규가입자 수
        public string Session_CnT; // 중복제거 사용 수
        public string Connect_Cnt; // 중복 포한 사용 수
    }
}