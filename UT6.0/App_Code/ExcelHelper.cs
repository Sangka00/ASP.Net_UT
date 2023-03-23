using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using WSF.Data;
using WSF.Debug;
using WSF.Helper;

/// <summary>
/// ExcelHelper의 요약 설명입니다.
/// </summary>
public class ExcelHelper
{
    /// <summary>
    /// Excel ole db import connection string
    /// </summary>
    public const string xlsConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES;\"";

    public const string xlsConnectionStringImex = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";

    public ExcelHelper()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }

    /// <summary>
    /// Import Excel file 
    /// 엑셀 파일은 "Excel 97-2003 형식의 엑셀 파일만 가져오기 가능하며
    /// 엑셀파일에서 첫번째 컬럼(0번 인덱스)는 추가/수정/삭제 중에 하나여야 하며, 이 중 값이 지정되어 있지 않으면 해당 row는 패스함
    /// </summary>
    /// <param name="pathExcelFile">가져오려는 엑셀파일 경로</param>
    /// <param name="targetDBConnectionNam">대상 DB 연결 문자열 키(web.config 키)</param>
    /// <param name="xlsColumnIndex">엑셀 파일의 가져오려는 컬럼 인덱스(0부터 시작)</param>
    /// <param name="dbColumnName">xlsColumnIndex에 해당 하는 DB에 맵핑되는 컬럼명(실제 DB의 컬럼)</param>
    /// <param name="dbColumnType">xlsColumnIndex에 해당 하는 DB에 맵핑되는 컬럼 타입(실제 DB의 컬럼)</param>
    /// <param name="sqlInsertQuery">*필수* 엑셀에서 한개의 row 당 실행되는 insert query 구분(입력되는 파라메터는 dbColumnName에 지정된 명칭으로 사용. ex) @ColumnName)</param>
    /// <param name="sqlUpdateQuery">*옵션* 엑셀에서 한개의 row 당 실행되는 update query 구분(입력되는 파라메터는 dbColumnName에 지정된 명칭으로 사용. ex) @ColumnName)</param>
    /// <param name="sqlDeleteQuery">*옵션* 엑셀에서 한개의 row 당 실행되는 dlete query 구분(입력되는 파라메터는 dbColumnName에 지정된 명칭으로 사용. ex) @ColumnName)</param>
    /// <param name="addQuery">한 row단 추가적으로 실행하는 sql query(insert/update/delete 와 관계 없이 실행되는 query)</param>
    /// <returns></returns>
    public static bool UpdateExcelDataToDB(string pathExcelFile, string targetDBConnectionNam, int[] xlsColumnIndex, string[] dbColumnName, DbType[] dbColumnType, string[] sqlInsertQuery, string[] sqlUpdateQuery, string[] sqlDeleteQuery, ExcelHelper.ExecAddtionalQueryReader addQuery)
    {
        if (string.IsNullOrEmpty(pathExcelFile) || (int)xlsColumnIndex.Length < 1 || (int)dbColumnName.Length < 1 || (int)xlsColumnIndex.Length != (int)dbColumnName.Length || sqlInsertQuery == null || (int)sqlInsertQuery.Length < 1)
        {
            return false;
        }
        try
        {
            int num = 0;
            Trace.Debug("Prepare oledb connection");
            using (DbConnection dbConnection = DbProviderFactories.GetFactory("System.Data.OleDb").CreateConnection())
            {
                dbConnection.ConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"", pathExcelFile);
                Trace.Debug("Prepare target db");
                Database database = DatabaseFactory.CreateDatabase(targetDBConnectionNam);
                using (DbConnection dbConnection1 = database.CreateConnection())
                {
                    dbConnection1.Open();
                    Trace.Debug("Begin tran target db");
                    using (DbTransaction dbTransaction = dbConnection1.BeginTransaction())
                    {
                        try
                        {
                            Trace.Debug("Prepare xls source");
                            using (DbCommand dbCommand = dbConnection.CreateCommand())
                            {
                                dbConnection.Open();
                                dbCommand.CommandText = string.Format("SELECT * FROM [{0}$]", Path.GetFileNameWithoutExtension(pathExcelFile));
                                Trace.Debug("Fetch xls rows");
                                Trace.Debug("Start importing");
                                int num1 = 0;
                                using (DbDataReader dbDataReaders = dbCommand.ExecuteReader())
                                {
                                    while (dbDataReaders.Read())
                                    {
                                        int num2 = 0;
                                        string[] strArrays = null;
                                        if (!dbDataReaders.HasRows || dbDataReaders.IsDBNull(0) || string.IsNullOrEmpty(dbDataReaders.GetString(0)))
                                        {
                                            Trace.Debug("Skip row (NO MANAGE)");
                                        }
                                        else
                                        {
                                            if (dbDataReaders.GetString(0).Trim() == "추가")
                                            {
                                                Trace.Debug("INSERT ROW");
                                                strArrays = sqlInsertQuery;
                                                num1++;
                                            }
                                            else if (dbDataReaders.GetString(0).Trim() == "삭제")
                                            {
                                                Trace.Debug("DELETE ROW");
                                                strArrays = sqlDeleteQuery;
                                                num1++;
                                            }
                                            else if (dbDataReaders.GetString(0).Trim() != "수정")
                                            {
                                                Trace.Debug("Skip row (NO MANAGE)(2)");
                                                continue;
                                            }
                                            else
                                            {
                                                Trace.Debug("UPDATE ROW");
                                                strArrays = sqlUpdateQuery;
                                                num1++;
                                            }
                                            for (int i = 0; i < (int)strArrays.Length; i++)
                                            {
                                                object[] objArray = new object[] { strArrays[i] };
                                                Trace.DebugFormat("Current query : {0}", objArray);
                                                using (DbCommand sqlStringCommand = database.GetSqlStringCommand(strArrays[i]))
                                                {
                                                    for (int j = 0; j < (int)xlsColumnIndex.Length; j++)
                                                    {
                                                        if (strArrays[i].Contains(string.Concat("@", dbColumnName[j])))
                                                        {
                                                            database.AddInParameter(sqlStringCommand, string.Concat("@", dbColumnName[j]), dbColumnType[j], dbDataReaders[xlsColumnIndex[j]]);
                                                            object[] objArray1 = new object[] { dbColumnName[j], dbColumnType[j].ToString(), dbDataReaders[xlsColumnIndex[j]] };
                                                            Trace.DebugFormat("Query param : {0} = {1} = {2}", objArray1);
                                                        }
                                                    }
                                                    sqlStringCommand.Connection = dbConnection1;
                                                    sqlStringCommand.Transaction = dbTransaction;
                                                    num2 += sqlStringCommand.ExecuteNonQuery();
                                                }
                                            }
                                            if (num2 != (int)strArrays.Length)
                                            {
                                                object[] length = new object[] { num2, (int)strArrays.Length };
                                                Trace.DebugFormat("Failed to exec query (ar : {0} , sl : {1})", length);
                                            }
                                            else
                                            {
                                                num++;
                                                Trace.DebugFormat("Check result (rows : {0})", new object[] { num });
                                                if (addQuery == null)
                                                {
                                                    continue;
                                                }
                                                try
                                                {
                                                    addQuery(dbDataReaders, database, dbConnection1, dbTransaction);
                                                }
                                                catch (Exception exception1)
                                                {
                                                    Exception exception = exception1;
                                                    Trace.Debug("Fail to log");
                                                    Trace.Warn(ref exception);
                                                }
                                            }
                                        }
                                    }
                                }
                                Trace.Debug("Check result of importing");
                                if (num != num1)
                                {
                                    throw new Exception(string.Format("Fail to update rows (succeeded {0}/{1})", num, num1));
                                }
                                dbTransaction.Commit();
                                Trace.Debug("Succeed");
                                return true;
                            }
                        }
                        catch (Exception exception3)
                        {
                            Exception exception2 = exception3;
                            Trace.Debug("Fail to import");
                            Trace.Warn(ref exception2);
                        }
                        Trace.Debug("Failed");
                        dbTransaction.Rollback();
                    }
                }
            }
        }
        catch (Exception exception5)
        {
            Exception exception4 = exception5;
            Trace.Error(ref exception4);
        }
        return false;
    }


    /// <summary>
    /// 추가적인 query를 실행하기 위한 대리자
    /// </summary>
    /// <param name="dr">현재 DataRow</param>
    /// <param name="dbTarget">저장될 타겟 DB</param>
    /// <param name="connTarget">저장될 타겟 DB 커넥션</param>
    /// <param name="tranTarget">저장될 타겟 DB 커넥션의 트랜잭션(트랜잭션과 함께 해야될 경우 필수 사용)</param>
    public delegate void ExecAddtionalQuery(DataRow dr, Database dbTarget, DbConnection connTarget, DbTransaction tranTarget);

    /// <summary>
    /// 추가적인 query를 실행하기 위한 대리자
    /// </summary>
    /// <param name="dr">현재 DataRow</param>
    /// <param name="dbTarget">저장될 타겟 DB</param>
    /// <param name="connTarget">저장될 타겟 DB 커넥션</param>
    /// <param name="tranTarget">저장될 타겟 DB 커넥션의 트랜잭션(트랜잭션과 함께 해야될 경우 필수 사용)</param>
    public delegate void ExecAddtionalQueryReader(IDataReader dr, Database dbTarget, DbConnection connTarget, DbTransaction tranTarget);

}