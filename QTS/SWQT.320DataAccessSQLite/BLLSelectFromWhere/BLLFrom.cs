using SWQT._768ConstantValue.ListTableDatabase;

namespace SWQT._320DataAccessSQLite.BLLSelectFromWhere
{
    internal class BLLFrom
    {

        private readonly BLLClass _bllClass = new BLLClass();

        internal void GetQueryLayAllIdOrder_From(ref string strFrom)
        {
            strFrom += $" {Table_BangDanhSachDonHang.NAME} {Table_BangDanhSachDonHang.NAME} ";

            {
                string strJoin2Table = "";
                _bllClass.GetStringJoin2Table(ref strJoin2Table, "\nINNER JOIN"
                  , new Tuple<string, string>(Table_BangKhachHang.NAME
                  , Table_BangKhachHang.Col_IdBangKhachHang.NAME)
                  , new Tuple<string, string>(Table_BangDanhSachDonHang.NAME
                  , Table_BangDanhSachDonHang.Col_IdBangKhachHang.NAME));
                strFrom += strJoin2Table;
            }

        }

        internal void GetQueryLayDetailOrderByListId_From(ref string strFrom)
        {
            string strNameTable1 = Table_BangChiTietDonHang.NAME;
            strFrom += $" {strNameTable1} {strNameTable1} ";

            {
                string strJoin2Table = "";
                _bllClass.GetStringJoin2Table(ref strJoin2Table, "\nINNER JOIN"
                  , new Tuple<string, string>(Table_BangGiaViThuoc.NAME
                  , Table_BangGiaViThuoc.Col_MaGiaThuoc.NAME)
                  , new Tuple<string, string>(strNameTable1
                  , Table_BangChiTietDonHang.Col_MaGiaThuoc.NAME));
                strFrom += strJoin2Table;
            }

            {
                string strJoin2Table = "";
                _bllClass.GetStringJoin2Table(ref strJoin2Table, "\nINNER JOIN"
                  , new Tuple<string, string>(Table_BangViThuoc.NAME
                  , Table_BangViThuoc.Col_MaViThuoc.NAME)
                  , new Tuple<string, string>(Table_BangGiaViThuoc.NAME
                  , Table_BangGiaViThuoc.Col_MaViThuoc.NAME));
                strFrom += strJoin2Table;
            }

        }

        internal void GetQueryLayListDonGiaByListId_From(ref string strFrom)
        {
            string strNameTable1 = Table_BangChiTietDonHang.NAME;
            strFrom += $" {strNameTable1} {strNameTable1} ";

            {
                string strJoin2Table = "";
                _bllClass.GetStringJoin2Table(ref strJoin2Table, "\nINNER JOIN"
                  , new Tuple<string, string>(Table_BangGiaViThuoc.NAME
                  , Table_BangGiaViThuoc.Col_MaGiaThuoc.NAME)
                  , new Tuple<string, string>(strNameTable1
                  , Table_BangChiTietDonHang.Col_MaGiaThuoc.NAME));
                strFrom += strJoin2Table;
            }

            {
                string strJoin2Table = "";
                _bllClass.GetStringJoin2Table(ref strJoin2Table, "\nINNER JOIN"
                  , new Tuple<string, string>(Table_BangDanhSachDonHang.NAME
                  , Table_BangDanhSachDonHang.Col_MaDonHang.NAME)
                  , new Tuple<string, string>(strNameTable1
                  , Table_BangChiTietDonHang.Col_MaDonHang.NAME));
                strFrom += strJoin2Table;
            }

            {
                string strJoin2Table = "";
                _bllClass.GetStringJoin2Table(ref strJoin2Table, "\nINNER JOIN"
                  , new Tuple<string, string>(Table_BangKhachHang.NAME
                  , Table_BangKhachHang.Col_IdBangKhachHang.NAME)
                  , new Tuple<string, string>(Table_BangDanhSachDonHang.NAME
                  , Table_BangDanhSachDonHang.Col_IdBangKhachHang.NAME));
                strFrom += strJoin2Table;
            }

            {
                string strJoin2Table = "";
                _bllClass.GetStringJoin2Table(ref strJoin2Table, "\nINNER JOIN"
                  , new Tuple<string, string>(Table_BangViThuoc.NAME
                  , Table_BangViThuoc.Col_MaViThuoc.NAME)
                  , new Tuple<string, string>(Table_BangGiaViThuoc.NAME
                  , Table_BangGiaViThuoc.Col_MaViThuoc.NAME));
                strFrom += strJoin2Table;
            }

        }

        internal void GetQueryLayListOrderByListId_From(ref string strFrom)
        {
            string strNameTable1 = Table_BangChiTietDonHang.NAME;
            strFrom += $" {strNameTable1} {strNameTable1} ";

            {
                string strJoin2Table = "";
                _bllClass.GetStringJoin2Table(ref strJoin2Table, "\nINNER JOIN"
                  , new Tuple<string, string>(Table_BangGiaViThuoc.NAME
                  , Table_BangGiaViThuoc.Col_MaGiaThuoc.NAME)
                  , new Tuple<string, string>(strNameTable1
                  , Table_BangChiTietDonHang.Col_MaGiaThuoc.NAME));
                strFrom += strJoin2Table;
            }

            {
                string strJoin2Table = "";
                _bllClass.GetStringJoin2Table(ref strJoin2Table, "\nINNER JOIN"
                  , new Tuple<string, string>(Table_BangViThuoc.NAME
                  , Table_BangViThuoc.Col_MaViThuoc.NAME)
                  , new Tuple<string, string>(Table_BangGiaViThuoc.NAME
                  , Table_BangGiaViThuoc.Col_MaViThuoc.NAME));
                strFrom += strJoin2Table;
            }

        }

    }
}
