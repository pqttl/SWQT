using Microsoft.Extensions.Configuration;
using SWQT._768ConstantValue;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWQT._320DataAccessSQLite.DALSQLite
{
    public class DALBase
    {

        internal string StrConnectionString { get; set; }

        public DALBase()
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            StrConnectionString = configuration.GetSection("ConnectionStrings")["DNQTSolutionDb"];
        }

        internal void ChangeTypeColumnDateTime(ref DataTable dtOutput, List<string> lstColName)
        {
            if (lstColName.Count == 0)
            {
                return;
            }

            foreach (var item in lstColName)
            {
                ConvertColumnType(ref dtOutput, item, typeof(DateTime));
            }

        }

        internal void GetDataTableWithChangeTypeColumnDateTime(ref DataTable dtOutput, DataTable dtInput
          , List<string> lstColName)
        {
            dtOutput = dtInput.Copy();
            if (lstColName.Count == 0)
            {
                return;
            }

            foreach (var item in lstColName)
            {
                ConvertColumnType(ref dtOutput, item, typeof(DateTime));
            }

        }

        internal void ConvertColumnType(ref DataTable dtOutput, string columnName, Type newType)
        {
            using (DataColumn dcNew = new DataColumn(columnName + "_new", newType))
            {
                // Add the new column which has the new type, and move it to the ordinal of the old column
                int ordinal = dtOutput.Columns[columnName].Ordinal;
                dtOutput.Columns.Add(dcNew);
                dcNew.SetOrdinal(ordinal);

                // Get and convert the values of the old column, and insert them into the new
                foreach (DataRow dr in dtOutput.Rows)
                {
                    //dr[dcNew.ColumnName]=Convert.ChangeType(dr[columnName],newType);
                    // dr[dcNew.ColumnName]=DateTime.ParseExact(dr[columnName].ToString()
                    //,QTFormat.STR_DATETIME_SQLITE.STR,null);

                    string strTime = dr[columnName].ToString();
                    if (strTime == "")
                    {
                        dr[dcNew.ColumnName] = new DateTime(1900, 01, 13);
                        continue;
                    }
                    dr[dcNew.ColumnName] = DateTime.ParseExact(dr[columnName].ToString()
                      , QTFormat.STR_DATETIME_SQLITE.STR, null);
                }

                // Remove the old column
                dtOutput.Columns.Remove(columnName);

                // Give the new column the old column's name
                dcNew.ColumnName = columnName;
            }
        }

        internal void CreateQueryInsert(ref string strQuery, string strTableName, List<string> lstStrColumn)
        {
            string strOne = "";
            string strTwo = "";
            for (int i = 0; i < lstStrColumn.Count; i++)
            {
                if (i > 0)
                {
                    strOne += ",";
                    strTwo += ",";
                }

                strOne += lstStrColumn[i];
                strTwo += "@" + lstStrColumn[i];
            }

            strQuery = $"Insert into {strTableName}"
      + $"({strOne}) "
      + $" values ({strTwo});";
        }

        internal void GetMaxIdFromTable(ref int intMaxIdCurrent, string strColName, string strTableName)
        {
            using (var con = new SQLiteConnection(StrConnectionString))
            {
                DataTable dt = null;
                GetDataTableFromQuery(ref dt, con, strTableName
                  , $"SELECT * FROM {strTableName} WHERE rowid = (SELECT max(rowid) from {strTableName}) ");

                if (dt == null || dt.Rows.Count == 0)
                {
                    intMaxIdCurrent = 0;
                }
                else
                {
                    var dr = dt.Rows[0];
                    intMaxIdCurrent = Convert.ToInt32(dr[strColName].ToString());
                }
            }

        }

        internal void GetDataTableFromQuery(ref DataTable dt, SQLiteConnection con, string strTableName
            , string strQuery)
        {
            var ds = new DataSet();
            using (var da = new SQLiteDataAdapter(strQuery, con))
            {
                using (new SQLiteCommandBuilder(da))
                {
                    da.Fill(ds, strTableName);
                    dt = ds.Tables[strTableName];
                }
            }
        }

        internal void GetDataTableFromQueryWithoutTableName(ref DataTable dtOutput, string strQuery)
        {
            using (var con = new SQLiteConnection(StrConnectionString))
            {
                con.Open();
                var cmSql = new SQLiteCommand(con);
                cmSql.CommandText = strQuery;

                SQLiteDataReader reader = cmSql.ExecuteReader();
                dtOutput = new DataTable();
                try
                {
                    dtOutput.Load(reader);
                }
                catch (Exception e)
                {
                    string str = e.Message;
                }

                //using(var dr = cmSql.ExecuteReader()) {
                //  dtOutput=new DataTable();

                //  using(var ds = new DataSet() { EnforceConstraints=false }) {
                //	ds.Tables.Add(dtOutput);
                //	dtOutput.BeginLoadData();
                //	dtOutput.Load(dr);
                //	dtOutput.EndLoadData();
                //	ds.Tables.Remove(dtOutput);
                //  }
                //}

            }
        }

        internal void GetDataTableFromQuery(ref DataTable dtOutput, string strTableName, string strQuery)
        {
            using (var con = new SQLiteConnection(StrConnectionString))
            {
                con.Open();
                var ds = new DataSet();
                using (var da = new SQLiteDataAdapter(strQuery, con))
                {
                    using (new SQLiteCommandBuilder(da))
                    {
                        da.Fill(ds, strTableName);
                        dtOutput = ds.Tables[strTableName];
                    }
                }
            }
        }

    }
}
