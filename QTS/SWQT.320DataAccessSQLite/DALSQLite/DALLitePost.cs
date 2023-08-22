using SWQT._512ViewModels.Admin.Post;
using SWQT._768ConstantValue;
using SWQT._768ConstantValue.ListTableDatabase;
using System.Data;
using System.Data.SQLite;

namespace SWQT._320DataAccessSQLite.DALSQLite
{
    public class DALLitePost : DALBase
    {
        private readonly BLLQuery _bllQuery = new BLLQuery();
        private readonly BLLClass _bllClass = new BLLClass();

        public void AddList(ref string strError
            , ref Exception? exOutput, List<VMAddPostRequest> lstInput)
        {
            try
            {
                int intMaxIdCurrent = -1;
                GetMaxIdFromTable(ref intMaxIdCurrent, "Id", "TblListPost");

                using (var con = new SQLiteConnection(StrConnectionString))
                {
                    con.Open();
                    using (var transaction = con.BeginTransaction())
                    {
                        try
                        {
                            int intIdIncrease = intMaxIdCurrent;
                            foreach (var item in lstInput)
                            {
                                string strTitle = item.StrTitle!.Trim();
                                string strTextTrimNoUnicode = BLLTools.RemoveUnicode(strTitle);
                                string strMetaTitle = strTextTrimNoUnicode.Replace("  ", " ").Replace(" ", "-");

                                string strDescription = "Truy cập trang để xem chi tiết nội dung này ...";
                                try
                                {
                                    string strPlainTextTrim = BLLTools.GetPlainTextFromHtml(item.StrDetail!);
                                    strPlainTextTrim = System.Net.WebUtility.HtmlDecode(strPlainTextTrim);
                                    strDescription = strPlainTextTrim.Replace("  ", " ");
                                }
                                catch (Exception et)
                                {
                                    string str = et.Message;
                                }

                                strDescription = (strDescription.Length > 240) ? (strDescription.Substring(0, 240) + "...") : strDescription;

                                InsertBangTblListPost(con, ++intIdIncrease, strTitle, strMetaTitle
                                    , strDescription, item.StrDetail!
                                  , DateTime.Now, DateTime.Now, "adminqt",true);

                            }

                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            strError = ex.ToString();
                            exOutput = ex;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                strError = ex.ToString();
                exOutput = ex;
            }
        }

        public void GetDTAllIdPost(ref DataTable dtOutput, ref Exception exDAL)
        {
            try
            {
                string strQuery = "SELECT Id FROM TblListPost";
                //_bllQuery.GetQueryLayAllIdOrder(ref strQuery, "");

                var dtTemp = new DataTable();
                GetDataTableFromQueryWithoutTableName(ref dtTemp, strQuery);
          //      GetDataTableWithChangeTypeColumnDateTime(ref dtOutput, dtTemp, new List<string>() {
          //"ThoiGianVietDonHangNay"});
                dtOutput = dtTemp.Copy();
            }
            catch (Exception ex)
            {
                exDAL = ex;
            }
        }

        public void GetDTDetailOrderByListIdOrder(ref DataTable dtOutput, ref Exception exDAL
            , List<string> lstStringId)
        {
            try
            {
                string strQuery = "";
                //_bllQuery.GetQueryLayDetailOrderByListId(ref strQuery, lstStringId);
                //string strSelect = "";
                //_bllSelect.GetQueryLayDetailOrderByListId_Select(ref strSelect);

                //string strFrom = "";
                //_bllFrom.GetQueryLayDetailOrderByListId_From(ref strFrom);

                string strWhere = "";

                string strListId = "";
                _bllClass.GetStringJoinSplitChar(ref strListId, lstStringId, ",", "");

                strWhere += $"\n Id IN ({strListId}) ";

                string strOrderBy = "";
                strOrderBy += $"\n {Table_BangChiTietDonHang.NAME}.{Table_BangChiTietDonHang.Col_MaChiTietDonHang.NAME} ";

                strQuery = $"SELECT * \nFROM TblListPost \nWHERE {strWhere} ;";

                GetDataTableFromQueryWithoutTableName(ref dtOutput, strQuery);
            }
            catch (Exception ex)
            {
                exDAL = ex;
            }
        }

        private void InsertBangTblListPost(SQLiteConnection con, int intIdNew, string strTitle
            , string strMetaTitle, string strDescription, string strDetail, DateTime dtCreateTime
            , DateTime dtModifiedTime, string strUsername, bool blnShow)
        {
            var lstColName = new List<string>();
            var cmSql = new SQLiteCommand(con);
            {
                string strColName = "Id";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intIdNew;
            }

            {
                string strColName = "Name";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = "";
            }
            {
                string strColName = "Json";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = "";
            }
            {
                string strColName = "Title";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = strTitle;
            }
            {
                string strColName = "MetaTitle";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = strMetaTitle;
            }
            {
                string strColName = "Description";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = strDescription;
            }
            {
                string strColName = "Detail";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = strDetail;
            }

            {
                string strColName = "CreatedDate";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = dtCreateTime.ToString(QTFormat.STR_DATETIME_SQLITE.STR);
            }
            {
                string strColName = "CreatedBy";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = strUsername;
            }
            {
                string strColName = "ModifiedDate";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = dtModifiedTime.ToString(QTFormat.STR_DATETIME_SQLITE.STR);
            }
            {
                string strColName = "ModifiedBy";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = strUsername;
            }
            {
                string strColName = "Status";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = blnShow?1:0;
            }

            string strQuery = "";
            CreateQueryInsert(ref strQuery, "TblListPost", lstColName);

            cmSql.CommandText = strQuery;

            cmSql.ExecuteNonQuery();

        }
    }
}
