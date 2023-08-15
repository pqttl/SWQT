using SWQT._320DataAccessSQLite.BLLSelectFromWhere;
using SWQT._768ConstantValue.ListTableDatabase;

namespace SWQT._320DataAccessSQLite
{
    internal class BLLQuery
    {
        private readonly BLLClass _bllClass = new BLLClass();
        private readonly BLLSelect _bllSelect = new BLLSelect();
        private readonly BLLFrom _bllFrom = new BLLFrom();

        internal void GetQueryLayAllIdOrder(ref string strQuery, string strWhere)
        {
            string strSelect = "";
            _bllSelect.GetQueryLayAllIdOrder_Select(ref strSelect);

            string strFrom = "";
            _bllFrom.GetQueryLayAllIdOrder_From(ref strFrom);

            strQuery = $"SELECT \n{strSelect} \nFROM {strFrom} \n{strWhere} ;";
        }

        internal void GetQueryLayAllProductByListName(ref string strQuery, List<string> lstStringName)
        {
            string strOrderBy = "";
            strOrderBy += $"\n {Table_BangViThuoc.Col_TenViThuoc.NAME} ";

            if (lstStringName.Count > 0)
            {
                string strWhere = "";

                string strList = "";
                _bllClass.GetStringJoinSplitCharNotDot(ref strList, lstStringName, ",", "", "'");

                strWhere += $"\n {Table_BangViThuoc.Col_TenViThuoc.NAME} IN ({strList}) ";

                strQuery = $"SELECT MaViThuoc,TenViThuoc FROM BangViThuoc \nWHERE {strWhere} \nORDER BY {strOrderBy} ;";
                return;
            }

            strQuery = $"SELECT MaViThuoc,TenViThuoc FROM BangViThuoc \nORDER BY {strOrderBy} ;";

        }

        internal void GetQueryLayDetailOrderByListId(ref string strQuery, List<string> lstStringId)
        {
            string strSelect = "";
            _bllSelect.GetQueryLayDetailOrderByListId_Select(ref strSelect);

            string strFrom = "";
            _bllFrom.GetQueryLayDetailOrderByListId_From(ref strFrom);

            string strWhere = "";

            string strListId = "";
            _bllClass.GetStringJoinSplitChar(ref strListId, lstStringId, ",", "");

            strWhere += $"\n {Table_BangChiTietDonHang.NAME}.{Table_BangChiTietDonHang.Col_MaDonHang.NAME} IN ({strListId}) ";

            string strOrderBy = "";
            strOrderBy += $"\n {Table_BangChiTietDonHang.NAME}.{Table_BangChiTietDonHang.Col_MaChiTietDonHang.NAME} ";

            strQuery = $"SELECT \n{strSelect} \nFROM {strFrom} \nWHERE {strWhere} \nORDER BY {strOrderBy} ;";
        }

        internal void DeleteOrderDetailByListId(ref string strQuery, List<string> lstStringId)
        {

            string strWhere = "";

            string strListId = "";
            _bllClass.GetStringJoinSplitChar(ref strListId, lstStringId, ",", "");

            strWhere += $"\n {Table_BangChiTietDonHang.Col_MaChiTietDonHang.NAME} IN ({strListId}) ";

            strQuery = $"DELETE FROM \n{Table_BangChiTietDonHang.NAME} \nWHERE {strWhere} ;";
        }

        internal void GetQueryLayListDonGiaByListId(ref string strQuery, List<string> lstStringId)
        {
            string strSelect = "";
            _bllSelect.GetQueryLayListDonGiaByListId_Select(ref strSelect);

            string strFrom = "";
            _bllFrom.GetQueryLayListDonGiaByListId_From(ref strFrom);

            string strWhere = "";

            string strListId = "";
            _bllClass.GetStringJoinSplitChar(ref strListId, lstStringId, ",", "");

            strWhere += $"\n {Table_BangViThuoc.NAME}.{Table_BangViThuoc.Col_MaViThuoc.NAME} IN ({strListId}) ";

            strQuery = $"SELECT \n{strSelect} \nFROM {strFrom} \nWHERE {strWhere} ;";
        }

        internal void GetQueryLayListOrderByListId(ref string strQuery, List<string> lstStringId)
        {
            string strSelect = "";
            _bllSelect.GetQueryLayListOrderByListId_Select(ref strSelect);

            string strFrom = "";
            _bllFrom.GetQueryLayListOrderByListId_From(ref strFrom);

            string strWhere = "";

            string strListId = "";
            _bllClass.GetStringJoinSplitChar(ref strListId, lstStringId, ",", "");

            strWhere += $"\n {Table_BangViThuoc.NAME}.{Table_BangViThuoc.Col_MaViThuoc.NAME} IN ({strListId}) ";

            strQuery = $"SELECT \n{strSelect} \nFROM {strFrom} \nWHERE {strWhere} ;";
        }

    }
}
