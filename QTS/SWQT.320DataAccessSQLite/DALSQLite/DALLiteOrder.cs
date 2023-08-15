using SWQT._768ConstantValue;
using System.Data;
using System.Data.SQLite;

namespace SWQT._320DataAccessSQLite.DALSQLite
{
    public class DALLiteOrder : DALBase
    {
        private readonly BLLQuery _bllQuery = new BLLQuery();

        public void GetDTAllIdOrder(ref DataTable dtOutput, ref Exception exDAL)
        {
            try
            {
                string strQuery = "";
                _bllQuery.GetQueryLayAllIdOrder(ref strQuery, "");

                var dtTemp = new DataTable();
                GetDataTableFromQueryWithoutTableName(ref dtTemp, strQuery);
                GetDataTableWithChangeTypeColumnDateTime(ref dtOutput, dtTemp, new List<string>() {
          "ThoiGianVietDonHangNay"});
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
                _bllQuery.GetQueryLayDetailOrderByListId(ref strQuery, lstStringId);

                GetDataTableFromQueryWithoutTableName(ref dtOutput, strQuery);
            }
            catch (Exception ex)
            {
                exDAL = ex;
            }
        }

        public void DeleteOrderDetailByListId(ref bool blnSuccess, ref string strError, ref Exception exOutput
          , List<string> lstStringId)
        {
            try
            {
                blnSuccess = false;

                string strQuery = "";
                _bllQuery.DeleteOrderDetailByListId(ref strQuery, lstStringId);

                //blnSuccess=blnThucThiNonQuery(strQuery,CommandType.Text,ref strError,null);

                using (var con = new SQLiteConnection(StrConnectionString))
                {
                    con.Open();
                    var cmSql = new SQLiteCommand(con);

                    cmSql.CommandText = strQuery;

                    cmSql.ExecuteNonQuery();
                }

                blnSuccess = true;
            }
            catch (Exception ex)
            {
                exOutput = ex;
                strError = ex.Message;
            }
        }

        public void AddProductExistToOrderDetail(ref Dictionary<string, object> dicOutput, ref Exception exOutput
          , Dictionary<string, object> dicInput)
        {
            try
            {
                int intMaxIdCurrent = -1;
                GetMaxIdFromTable(ref intMaxIdCurrent, "MaGiaThuoc", "BangGiaViThuoc");

                int intMaGiaThuocVuaThem = intMaxIdCurrent + 1;

                intMaxIdCurrent = -1;
                GetMaxIdFromTable(ref intMaxIdCurrent, "MaChiTietDonHang", "BangChiTietDonHang");
                int intMaxIdCurrentBangChiTietDonHang = intMaxIdCurrent;

                using (var con = new SQLiteConnection(StrConnectionString))
                {
                    con.Open();
                    using (var transaction = con.BeginTransaction())
                    {
                        try
                        {
                            int intIdProduct = Convert.ToInt32(dicInput["string.strIdProduct"] as string);
                            decimal decGiaVithuoc = (decimal)dicInput["decimal.decDonGia"];
                            InsertBangGiaViThuoc(con, intMaGiaThuocVuaThem, intIdProduct, decGiaVithuoc, "Kg"
                              , DateTime.Now, DateTime.Now, "");

                            int intIdOrder = Convert.ToInt32(dicInput["string.strIdOrder"] as string);
                            decimal decSoLuong = (decimal)dicInput["decimal.decSoLuong"];
                            decimal decThanhTien = (decimal)dicInput["decimal.decThanhTien"];
                            InsertBangChiTietDonHang(con, intMaxIdCurrentBangChiTietDonHang + 1, intIdOrder
                              , intMaGiaThuocVuaThem, decSoLuong, decThanhTien);

                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            dicOutput["string"] = ex.Message;
                            exOutput = ex;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                dicOutput["string"] = ex.ToString();
                exOutput = ex;
            }
        }

        private void InsertBangChiTietDonHang(SQLiteConnection con, int intIdNew, int intIdOrder
          , int intMaGiaThuocVuaThem, decimal decSoLuong, decimal decThanhTien)
        {
            var lstColName = new List<string>();
            var cmSql = new SQLiteCommand(con);
            {
                string strColName = "MaChiTietDonHang";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intIdNew;
            }
            {
                string strColName = "MaDonHang";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intIdOrder;
            }
            {
                string strColName = "MaGiaThuoc";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intMaGiaThuocVuaThem;
            }
            {
                string strColName = "SoLuongViThuoc";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.Decimal).Value = decSoLuong;
            }
            {
                string strColName = "ThanhTienTamThoi";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.Decimal).Value = decThanhTien;
            }

            string strQuery = "";
            CreateQueryInsert(ref strQuery, "BangChiTietDonHang", lstColName);

            cmSql.CommandText = strQuery;

            cmSql.ExecuteNonQuery();

        }

        private void InsertBangGiaViThuoc(SQLiteConnection con, int intIdNew, int intIdProduct
          , decimal decGiaVithuoc, string strDonVi, DateTime dtStartTime, DateTime dtEndTime, string strGhiChu)
        {
            var lstColName = new List<string>();
            var cmSql = new SQLiteCommand(con);
            {
                string strColName = "MaGiaThuoc";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intIdNew;
            }
            {
                string strColName = "MaViThuoc";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intIdProduct;
            }
            {
                string strColName = "GiaViThuoc";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.Decimal).Value = decGiaVithuoc;
            }
            {
                string strColName = "DonViGiaThuoc";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = strDonVi;
            }
            {
                string strColName = "ThoiGianBatDauCoGiaNay";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = dtStartTime.ToString(QTFormat.STR_DATETIME_SQLITE.STR);
            }
            {
                string strColName = "ThoiGianKetThucGiaNay";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = dtEndTime.ToString(QTFormat.STR_DATETIME_SQLITE.STR);
            }
            {
                string strColName = "GhiChuGiaThuoc";
                lstColName.Add(strColName);
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = strGhiChu;
            }

            string strQuery = "";
            CreateQueryInsert(ref strQuery, "BangGiaViThuoc", lstColName);

            cmSql.CommandText = strQuery;

            cmSql.ExecuteNonQuery();

        }

        public void UpdateOrderDetail(ref Dictionary<string, object> dicOutput, ref Exception exOutput
          , Dictionary<string, object> dicInput)
        {
            try
            {
                string strIdDetailOrder = dicInput["string.strIdDetailOrder"] as string;
                DataTable dtTemp = null;
                GetDataTableFromQueryWithoutTableName(ref dtTemp
                  , $"select MaGiaThuoc from BangChiTietDonHang  where MaChiTietDonHang={strIdDetailOrder} ;");
                int intMaGiaThuoc = Convert.ToInt32(dtTemp.Rows[0]["MaGiaThuoc"]);

                using (var con = new SQLiteConnection(StrConnectionString))
                {
                    con.Open();
                    using (var transaction = con.BeginTransaction())
                    {
                        try
                        {
                            decimal decDonGia = (decimal)dicInput["decimal.decDonGia"];
                            UpdatePriceBangGiaViThuoc(con, decDonGia, intMaGiaThuoc);

                            decimal decSoLuong = (decimal)dicInput["decimal.decSoLuong"];
                            decimal decThanhTien = (decimal)dicInput["decimal.decThanhTien"];
                            UpdateQuantityThanhTienBangChiTietDonHang(con, decSoLuong, decThanhTien, strIdDetailOrder);

                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            dicOutput["string"] = ex.Message;
                            exOutput = ex;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                dicOutput["string"] = ex.Message;
                exOutput = ex;
            }
        }

        #region Update data on 1 table

        private void UpdateQuantityThanhTienBangChiTietDonHang(SQLiteConnection con, decimal decSoLuong
          , decimal decThanhTien, string strIdDetailOrder)
        {
            var cmSql = new SQLiteCommand(con);
            {
                string strColName = "SoLuongViThuoc";
                cmSql.Parameters.Add("@" + strColName, DbType.Decimal).Value = decSoLuong;
            }
            {
                string strColName = "ThanhTienTamThoi";
                cmSql.Parameters.Add("@" + strColName, DbType.Decimal).Value = decThanhTien;
            }
            {
                string strColName = "MaChiTietDonHang";
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = Convert.ToInt32(strIdDetailOrder);
            }

            string strQuery = @"update BangChiTietDonHang"
      + " set SoLuongViThuoc=@SoLuongViThuoc,ThanhTienTamThoi=@ThanhTienTamThoi"
      + " where MaChiTietDonHang=@MaChiTietDonHang;";

            cmSql.CommandText = strQuery;

            cmSql.ExecuteNonQuery();

        }

        private void UpdatePriceBangGiaViThuoc(SQLiteConnection con, decimal decDonGia, int intMaGiaThuoc)
        {
            var cmSql = new SQLiteCommand(con);
            {
                string strColName = "GiaViThuoc";
                cmSql.Parameters.Add("@" + strColName, DbType.Decimal).Value = decDonGia;
            }
            {
                string strColName = "ThoiGianBatDauCoGiaNay";
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = DateTime.Now.ToString(QTFormat.STR_DATETIME_SQLITE.STR);
            }
            {
                string strColName = "MaGiaThuoc";
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intMaGiaThuoc;
            }

            string strQuery = @"update BangGiaViThuoc"
      + " set GiaViThuoc=@GiaViThuoc,ThoiGianBatDauCoGiaNay=@ThoiGianBatDauCoGiaNay where MaGiaThuoc=@MaGiaThuoc;";

            cmSql.CommandText = strQuery;

            cmSql.ExecuteNonQuery();

        }

        private void UpdateIdKhachHangBangDanhSachDonHang(SQLiteConnection con, string strIdCustomer, string strIdOrder)
        {
            var cmSql = new SQLiteCommand(con);
            {
                string strColName = "IdBangKhachHang";
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = strIdCustomer;
            }
            {
                string strColName = "MaDonHang";
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = strIdOrder;
            }

            string strQuery = @"update BangDanhSachDonHang set IdBangKhachHang=@IdBangKhachHang  where MaDonHang=@MaDonHang";

            cmSql.CommandText = strQuery;

            cmSql.ExecuteNonQuery();

        }

        #endregion

        public void GetDTAllIdOrderByTime(ref DataTable dtOutput, ref Exception exDAL, DateTime dtimeStart, DateTime dtimeEnd)
        {
            try
            {
                //string strTemp = "";
                //strTemp+=$" BangDanhSachDonHang.ThoiGianVietDonHangNay>='{dtimeStart.ToString("yyyy/MM/dd")}' ";
                //strTemp+=$" and BangDanhSachDonHang.ThoiGianVietDonHangNay<='{dtimeEnd.AddDays(1).Date.ToString("yyyy/MM/dd")}' ";

                //string strWhere = " WHERE "+strTemp+" order by BangDanhSachDonHang.ThoiGianVietDonHangNay ";
                string strWhere = " order by BangDanhSachDonHang.ThoiGianVietDonHangNay ";

                string strQuery = "";
                _bllQuery.GetQueryLayAllIdOrder(ref strQuery, strWhere);

                var dtTemp = new DataTable();
                GetDataTableFromQueryWithoutTableName(ref dtTemp, strQuery);

                DataTable dtTempLocTheoTime = null;
                GetDataTableWithChangeTypeColumnDateTime(ref dtTempLocTheoTime, dtTemp, new List<string>() {
          "ThoiGianVietDonHangNay"});
                int intSumRow = dtTempLocTheoTime.Rows.Count;
                for (int i = intSumRow - 1; i >= 0; i--)
                {
                    DateTime dateSoSanh = (DateTime)dtTempLocTheoTime.Rows[i]["ThoiGianVietDonHangNay"];
                    if (dateSoSanh < dtimeStart || dateSoSanh > dtimeEnd.AddDays(1).Date)
                    {
                        dtTempLocTheoTime.Rows.RemoveAt(i);
                    }
                }

                dtOutput = dtTempLocTheoTime.Copy();
            }
            catch (Exception ex)
            {
                exDAL = ex;
            }
        }

        public void AddNewOrder(ref Dictionary<string, object> dicOutput, ref Exception exOutput
          , Dictionary<string, object> dicInput)
        {
            try
            {
                int intMaxIdCurrent = -1;
                GetMaxIdFromTable(ref intMaxIdCurrent, "MaDonHang", "BangDanhSachDonHang");

                using (var con = new SQLiteConnection(StrConnectionString))
                {
                    con.Open();
                    InsertBangDanhSachDonHang(con, intMaxIdCurrent + 1);
                }

            }
            catch (Exception ex)
            {
                exOutput = ex;
            }
        }

        private void InsertBangDanhSachDonHang(SQLiteConnection con, int intIdNew)
        {
            var cmSql = new SQLiteCommand(con);
            {
                string strColName = "MaDonHang";
                cmSql.Parameters.Add("@" + strColName, DbType.Int32).Value = intIdNew;
            }
            {
                string strColName = "ThoiGianVietDonHangNay";
                cmSql.Parameters.Add("@" + strColName, DbType.String).Value = DateTime.Now.ToString(QTFormat.STR_DATETIME_SQLITE.STR);
            }
            string strDaCapNhatTienNoChua = "Chưa cập nhật";
            string strQuery = @"insert into BangDanhSachDonHang(MaDonHang,ThoiGianVietDonHangNay,TongViThuoc,TongKhoiLuong,TongGiaTriDonHang,IdBangKhachHang,SDTKhachHang,TienNoCu,CapNhatTienNoChua) values (@MaDonHang,@ThoiGianVietDonHangNay,0,0,0,1,'',0,'" + strDaCapNhatTienNoChua + @"'); 
			";

            cmSql.CommandText = strQuery;

            cmSql.ExecuteNonQuery();
        }

    }
}
