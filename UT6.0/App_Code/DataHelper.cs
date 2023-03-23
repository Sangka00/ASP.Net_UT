using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Net.Json;
using System.Text;
/// <summary>
/// DataHelper의 요약 설명입니다.
/// </summary>
public class DataHelper
{
    public DataHelper()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }
    /// <summary>
    /// DataSet을 Json 스트링으로 생성
    /// </summary>
    /// <param name="ds">DataSet</param>
    /// <returns>Json 스트링</returns>
    public static string JsonStringDataSet(DataSet ds)
    {
        try
        {
            if (!WSF.Data.DBHelper.HasTable(ds))
            {
                return "[]";
            }
            if (ds.Tables.Count == 1)
            {
                return JsonStringDataTable(WSF.Data.DBHelper.GetTable(ds, 0));
            }
            JsonArrayCollection jsonFullColl = new JsonArrayCollection();

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                using (DataTable dt = WSF.Data.DBHelper.GetTable(ds, i))
                {
                    JsonTextParser jtp = new JsonTextParser();
                    JsonArrayCollection jsonColl = new JsonArrayCollection(dt.TableName, (JsonArrayCollection)jtp.Parse(JsonStringDataTable(dt)));
                    JsonObjectCollection jjc = new JsonObjectCollection();
                    jjc.Add(jsonColl);
                    jsonFullColl.Add(jjc);
                }
            }
            return jsonFullColl.ToString();
        }
        catch
        {
            return "[]";
        }
    }

    /// <summary>
    /// DataTable을 Json 스트링으로 생성
    /// </summary>
    /// <param name="dt">DataTable</param>
    /// <returns>Json 스트링</returns>
    public static string JsonStringDataTable(DataTable dt)
    {
        try
        {
            if (dt == null || dt.Rows == null || dt.Rows.Count < 1)
            {
                return "[]";
            }

            JsonArrayCollection JsonArray = new JsonArrayCollection();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JsonObjectCollection jsonColl = new JsonObjectCollection();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    switch (dt.Columns[j].DataType.FullName)
                    {
                        case "System.Double": jsonColl.Add(new JsonNumericValue(dt.Columns[j].ColumnName, WSF.Data.DBHelper.GetDoubleFromTable(dt, i, j))); break;
                        case "System.Int64": jsonColl.Add(new JsonNumericValue(dt.Columns[j].ColumnName, WSF.Data.DBHelper.GetInt64FromTable(dt, i, j))); break;
                        case "System.Int32": jsonColl.Add(new JsonNumericValue(dt.Columns[j].ColumnName, WSF.Data.DBHelper.GetIntFromTable(dt, i, j))); break;
                        case "System.Byte": jsonColl.Add(new JsonNumericValue(dt.Columns[j].ColumnName, WSF.Data.DBHelper.GetIntFromTable(dt, i, j))); break;
                        case "System.DateTime": jsonColl.Add(new JsonStringValue(dt.Columns[j].ColumnName, WSF.Data.DBHelper.GetStringFromTable(dt, i, j))); break;
                        case "System.String": jsonColl.Add(new JsonStringValue(dt.Columns[j].ColumnName, WSF.Data.DBHelper.GetStringFromTable(dt, i, j))); break;
                        default: jsonColl.Add(new JsonStringValue(dt.Columns[j].ColumnName, WSF.Data.DBHelper.GetStringFromTable(dt, i, j))); break;
                    }
                }
                JsonArray.Add(jsonColl);
            }
            return JsonArray.ToString();
        }
        catch
        {
            return "[]";
        }
    }

    /// <summary>
    /// DataSet을 XML 형태의 문자열 변환
    /// </summary>
    /// <param name="ds">데이터셋</param>
    /// <param name="RootElementName">루트XML노드명</param>
    /// <returns>XML</returns>
    public static string XmlDataSet(DataSet ds, string RootElementName)
    {
        if (WSF.Data.DBHelper.HasTable(ds))
        {
            StringBuilder xmlsb = new StringBuilder(1024);
            xmlsb.AppendFormat("<{0}>", RootElementName);
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                if (WSF.Data.DBHelper.HasTable(ds, i))
                {
                    using (DataTable dt = WSF.Data.DBHelper.GetTable(ds, i))
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            xmlsb.AppendFormat("<{0}>", dt.TableName);
                            for (int k = 0; k < dt.Columns.Count; k++)
                            {
                                string CN = dt.Columns[k].ColumnName;
                                xmlsb.AppendFormat("<{0}>", CN);
                                xmlsb.AppendFormat("<![CDATA[{0}]]>", WSF.Data.DBHelper.GetStringFromTable(ds, i, j, k));
                                xmlsb.AppendFormat("</{0}>", CN);
                            }
                            xmlsb.AppendFormat("</{0}>", dt.TableName);
                        }
                    }
                }
            }
            xmlsb.AppendFormat("</{0}>", RootElementName);
            ds.Dispose();
            return xmlsb.ToString();
        }
        else
        {
            ds.Dispose();
            return string.Format("<{0}></{0}>", RootElementName);
        }
    }

    /// <summary>
    /// XML을 DataSet으로 변환
    /// </summary>
    /// <param name="XmlString">XML 문자열</param>
    /// <param name="ds">DataTable 스키마 설정이 완료된 DataSet, 반환 시 결과값으로 받을 DataSet</param>
    /// <returns>DataSet (XML 데이터가 담겨져 반환)</returns>
    public static DataSet DataSetXml(string XmlString, DataSet ds)
    {
        try
        {
            StringReader xmlSR = new StringReader(XmlString);
            ds.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);
        }
        catch
        {
        }
        return ds;
    }
}