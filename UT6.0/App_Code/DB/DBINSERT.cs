using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

/// <summary>
/// DBINSERT의 요약 설명입니다.
/// </summary>
/// 
namespace DB
{
    
    public class DBINSERT
    {
        public static Database _db = DatabaseFactory.CreateDatabase("ConnectDB3");
        public DBINSERT()
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //
        }

        public static string DB_NewIndex(string _name, string _code)
        {
            string newIndex = string.Empty;
            try
            {
                using(DbConnection conn = _db.CreateConnection())
                {
                    conn.Open();
                    using (DbTransaction tran = conn.BeginTransaction())
                    {
                        //execute query
                        string sql = "Insert Into DB_Index([name],[code]) values( @name, @code)";
                        using (DbCommand cmd = _db.GetSqlStringCommand(sql))
                        {
                            _db.AddInParameter(cmd, "@name", DbType.String, _name);
                            _db.AddInParameter(cmd, "@code", DbType.String, _code);

                            if (_db.ExecuteNonQuery(cmd, tran) > 0)
                            {
                                //get new index
                                newIndex = common.GetStrVal(_db.ExecuteScalar(tran, CommandType.Text, "Select @@Identity"), "STR");
                                tran.Commit();
                            }
                            else
                            {
                                tran.Rollback();
                            }
                        }

                    }
                    conn.Close();
                }
                return newIndex;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
