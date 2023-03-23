using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Xml;
using System.IO;
using System.Text;

public partial class FILE_API_ExcelUpLoad_TS : WSF.Web.Page
{
    string MID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        SetNoCachePage();
        MID = GetForm("mid");
        try
        {
            using (MemoryStream MS = new MemoryStream())
            {
                XmlWriterSettings Setting = new XmlWriterSettings();
                Setting.Encoding = Encoding.UTF8;
                //UTF8 인코딩

                using (XmlWriter XW = XmlWriter.Create(MS, Setting))
                {
                    XW.WriteStartDocument();
                    XW.WriteStartElement("Data");

                    string code = string.Empty;
                    string key = string.Empty;
                    string message = string.Empty;

                    ProcessAjaxCommand(ref code, ref key, ref message);

                    XW.WriteStartElement("Result");
                    XW.WriteAttributeString("code", code);
                    XW.WriteAttributeString("key", key);
                    XW.WriteAttributeString("message", message);
                    XW.WriteEndElement();

                    XW.WriteEndElement();
                    XW.WriteEndDocument();
                    XW.Flush();
                    XW.Close();
                }

                Response.ContentType = "text/xml";
                Response.Write(Encoding.UTF8.GetString(MS.ToArray()));

                MS.Close();
            }
        }
        catch (Exception ex)
        {
            WSF.Debug.Trace.Warn(ref ex);
            Response.ClearContent();
            Response.Write(@"<Data><Result code=""9999"" key=""ERR"" message=""시스템 오류""></Result></Data>");
        }
    }
    /// <summary>
    /// 실행 cmd에 따라서 분리 및 결과 처리 리턴
    /// </summary>
    /// <param name="code">코드값</param>
    /// <param name="key">키값</param>
    /// <param name="message">메시지</param>
    protected void ProcessAjaxCommand(ref string code, ref string key, ref string message)
    {
        string cmd = GetQuery("cmd");

        Response.ContentType = "text/json";

        switch (cmd.ToLower())
        {
         //   case "chk": CheckOEMSerialNumber(ref code, ref key, ref message); break; // 시리얼 번호 체크
            case "upxls": UploadExcelFile(ref code, ref key, ref message); break;
        //    case "uplog": UpdateHistory(ref code, ref key, ref message); break;
            default:
                {
                    code = "9";
                    key = "NOARGS";
                    message = "입력 파라미터 없음";
                }
                break;
        }
    }
    /// <summary>
    /// 시리얼 관리를 위한 엑셀 파일 업로드
    /// </summary>
    /// <param name="code">리턴될 코드값</param>
    /// <param name="key">리턴될 키값</param>
    /// <param name="message">리턴될 메시지</param>
    protected void UploadExcelFile(ref string code, ref string key, ref string message)
    {
     //   WSF.Debug.Trace.Debug("UploadExcelFile");
        string xlsFileInfo = GetForm("xf");

     //   WSF.Debug.Trace.Debug("Check auth");
        // 미로그인 시 정보 없이 리턴
        if (string.IsNullOrEmpty(MID))
        {
            code = "8888";
            key = "NOAUTH";
            message = "권한이 없거나 로그인 상태가 아님";
            return;
        }

     //   WSF.Debug.Trace.Debug("Log function");
        string reqip = string.Empty;
       
     //   WSF.Debug.Trace.Debug("Check args");
        if (string.IsNullOrEmpty(xlsFileInfo))
        {
            code = "999";
            key = "NOARGS";
            message = "입력 파라미터 부족 또는 없음";
            return;
        }

        WSF.Web.FileUploadHelper fu = new WSF.Web.FileUploadHelper(xlsFileInfo);
        if (fu.Count != 1)
        {
            code = "999";
            key = "NOARGS";
            message = "입력 파라미터 오류(1)";
            return;
        }

        WSF.Debug.Trace.Debug("Prepare data dir");
        string temppath = System.IO.Path.Combine(WSF.Web.FileUploadHelper.UploadTempPath, WSF.Helper.StringUtil.RandomNumberString(7));
        try
        {
            System.IO.Directory.CreateDirectory(temppath);
        }
        catch
        {
        }

        WSF.Web.FileUploadItem itm = fu[0];

        string sourcefile = System.IO.Path.Combine(WSF.Web.FileUploadHelper.UploadTempPath, itm.FileName);
        string targetfile = System.IO.Path.Combine(temppath, "GScan_OEM_SerialNumer_List" + System.IO.Path.GetExtension(itm.FileName));

       // WSF.Debug.Trace.Debug("Move excel file");
        try
        {
            System.IO.File.Move(sourcefile, targetfile);
        }
        catch (Exception ex)
        {
           // WSF.Debug.Trace.Error(ref ex);
            code = "9999";
            key = "ERR";
            message = "엑셀 파일 조작 오류";
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
        /// <param name="sqlInsertQuery">*필수* 엑셀에서 한개의 row 당 실행되는 insert query 구분(입력되는 파라메터는 dbColumnName에 지정된 명칭으로 사용. ex) @ColumnName)</param>
        /// <param name="sqlUpdateQuery">*옵션* 엑셀에서 한개의 row 당 실행되는 update query 구분(입력되는 파라메터는 dbColumnName에 지정된 명칭으로 사용. ex) @ColumnName)</param>
        /// <param name="sqlDeleteQuery">*옵션* 엑셀에서 한개의 row 당 실행되는 dlete query 구분(입력되는 파라메터는 dbColumnName에 지정된 명칭으로 사용. ex) @ColumnName)</param>
        /// <param name="addQuery">한 row단 추가적으로 실행하는 sql query(insert/update/delete 와 관계 없이 실행되는 query)</param>
        /// <returns></returns>
        //   WSF.Debug.Trace.Debug("Import excel file");
        if (WSF.Helper.ExcelHelper.UpdateExcelDataToDB(
                targetfile
                , "GSODB"
                , new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }
                , new string[] { "SNo", "Maker", "RegionName", "NationName", "CorpName", "ReleaseDT", "SerialNumber", "UseYN" }
                , new string[] {
                    "INSERT INTO [dbo].[TP_KR_GSCANOEM_SERIALNUMBER](Maker,RegionName,NationName,CorpName,SerialNumber,ReleaseDT,UseYN,CreateDT,UpdateDT) VALUES(@Maker,@RegionName,@NationName,@CorpName,@SerialNumber,@ReleaseDT,@UseYN,getdate(),getdate())"}
                , new string[] {
                    "UPDATE [dbo].[TP_KR_GSCANOEM_SERIALNUMBER] SET Maker=@Maker,RegionName=@RegionName,NationName=@NationName,CorpName=@CorpName,SerialNumber=@SerialNumber,ReleaseDT=@ReleaseDT,UseYN=@UseYN WHERE SNo = @SNo"}
                , new string[] {
                    "DELETE FROM [dbo].[TP_KR_GSCANOEM_SERIALNUMBER] WHERE SNo = @SNo"}
                 , new WSF.Helper.ExcelHelper.ExecAddtionalQuery(ExecAddLogQuery)
                ))
        {
           // WSF.Debug.Trace.Debug("Succeed");
            code = "1";
            key = "SUCC";
            message = "엑셀 업로드 성공";
        }
        else
        {
          //  WSF.Debug.Trace.Debug("Failed");
            code = "4";
            key = "FAIL";
            message = "엑셀 업로드 실패";
        }

        WSF.Debug.Trace.Debug("Cleanup dir");
        try
        {
            System.IO.File.Delete(targetfile);
            System.IO.File.Delete(sourcefile);
        }
        catch
        {
        }
        try
        {
            System.IO.Directory.Delete(temppath, true);
        }
        catch
        {
        }

    }
    public void ExecAddLogQuery(DataRow dr, Database dbTarget, DbConnection connTarget, DbTransaction tranTarget)
    {
        System.Text.StringBuilder sbLog = new System.Text.StringBuilder(512);

        sbLog.Append(WSF.Helper.StringUtil.GetString(dr[0]).Trim());
        sbLog.AppendFormat(" : {0} , {1} , {2} , {3}, {4}, {5}, {6}", dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);

     /*
        using (DbCommand cmdTarget = dbTarget.GetSqlStringCommand(GscanOEM.DSL.GScanOEMAuth.SQL_INSERTLOG))
        {
            // 해당 컬럼이 존재함
            dbTarget.AddInParameter(cmdTarget, "@SNo", DbType.Int64, WSF.Helper.StringUtil.GetInt64(dr[1], -1));
            dbTarget.AddInParameter(cmdTarget, "@MemberId", DbType.String, MID);
            dbTarget.AddInParameter(cmdTarget, "@LogText", DbType.String, sbLog.ToString());
            cmdTarget.Connection = connTarget;
            cmdTarget.Transaction = tranTarget;

            cmdTarget.ExecuteNonQuery();
        } // cmdTarget
       */
    }
}