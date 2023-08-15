using SWQT._768ConstantValue.ListTableDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWQT._320DataAccessSQLite.BLLSelectFromWhere
{
    internal class BLLSelect
    {

        private readonly BLLClass _bllClass = new BLLClass();

        internal void GetQueryLayAllIdOrder_Select(ref string strSelect)
        {
            string strListColumnJoinTable1 = "";
            {
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangDanhSachDonHang.Col_MaDonHang.NAME);
                lstColumnTable.Add(Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable1
                  , lstColumnTable, ",", Table_BangDanhSachDonHang.NAME);
            }

            string strListColumnJoinTable2 = "";
            {
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangKhachHang.Col_TenKhachHang.NAME);
                lstColumnTable.Add(Table_BangKhachHang.Col_IdBangKhachHang.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable2
                  , lstColumnTable, ",", Table_BangKhachHang.NAME);
            }

            var lstStringInput = new List<string>();
            lstStringInput.Add(strListColumnJoinTable1);
            lstStringInput.Add(strListColumnJoinTable2);

            _bllClass.GetStringJoinSplitChar(ref strSelect, lstStringInput, "\n,", "");

        }

        internal void GetQueryLayDetailOrderByListId_Select(ref string strSelect)
        {
            var lstStringInput = new List<string>();

            {
                string strListColumnJoinTable = "";
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangChiTietDonHang.Col_MaDonHang.NAME);
                lstColumnTable.Add(Table_BangChiTietDonHang.Col_MaChiTietDonHang.NAME);
                lstColumnTable.Add(Table_BangChiTietDonHang.Col_SoLuongViThuoc.NAME);
                lstColumnTable.Add(Table_BangChiTietDonHang.Col_ThanhTienTamThoi.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable
                  , lstColumnTable, ",", Table_BangChiTietDonHang.NAME);
                lstStringInput.Add(strListColumnJoinTable);
            }

            {
                string strListColumnJoinTable = "";
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangViThuoc.Col_MaViThuoc.NAME);
                lstColumnTable.Add(Table_BangViThuoc.Col_TenViThuoc.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable
                  , lstColumnTable, ",", Table_BangViThuoc.NAME);
                lstStringInput.Add(strListColumnJoinTable);
            }

            {
                string strListColumnJoinTable = "";
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangGiaViThuoc.Col_DonViGiaThuoc.NAME);
                lstColumnTable.Add(Table_BangGiaViThuoc.Col_GiaViThuoc.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable
                  , lstColumnTable, ",", Table_BangGiaViThuoc.NAME);
                lstStringInput.Add(strListColumnJoinTable);
            }

            _bllClass.GetStringJoinSplitChar(ref strSelect, lstStringInput, "\n,", "");

        }

        internal void GetQueryLayListDonGiaByListId_Select(ref string strSelect)
        {
            var lstStringInput = new List<string>();

            {
                string strListColumnJoinTable = "";
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangDanhSachDonHang.Col_MaDonHang.NAME);
                lstColumnTable.Add(Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable
                  , lstColumnTable, ",", Table_BangDanhSachDonHang.NAME);
                lstStringInput.Add(strListColumnJoinTable);
            }

            {
                string strListColumnJoinTable = "";
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangKhachHang.Col_TenKhachHang.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable
                  , lstColumnTable, ",", Table_BangKhachHang.NAME);
                lstStringInput.Add(strListColumnJoinTable);
            }

            {
                string strListColumnJoinTable = "";
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangChiTietDonHang.Col_SoLuongViThuoc.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable
                  , lstColumnTable, ",", Table_BangChiTietDonHang.NAME);
                lstStringInput.Add(strListColumnJoinTable);
            }

            {
                string strListColumnJoinTable = "";
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangViThuoc.Col_MaViThuoc.NAME);
                lstColumnTable.Add(Table_BangViThuoc.Col_TenViThuoc.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable
                  , lstColumnTable, ",", Table_BangViThuoc.NAME);
                lstStringInput.Add(strListColumnJoinTable);
            }

            {
                string strListColumnJoinTable = "";
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangGiaViThuoc.Col_DonViGiaThuoc.NAME);
                lstColumnTable.Add(Table_BangGiaViThuoc.Col_GiaViThuoc.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable
                  , lstColumnTable, ",", Table_BangGiaViThuoc.NAME);
                lstStringInput.Add(strListColumnJoinTable);
            }

            _bllClass.GetStringJoinSplitChar(ref strSelect, lstStringInput, "\n,", "");

        }

        internal void GetQueryLayListOrderByListId_Select(ref string strSelect)
        {
            var lstStringInput = new List<string>();

            {
                string strListColumnJoinTable = "";
                var lstColumnTable = new List<string>();
                //lstColumnTable.Add(Table_BangChiTietDonHang.Col_MaDonHang.NAME);
                lstColumnTable.Add("*");

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable
                  , lstColumnTable, ",", Table_BangChiTietDonHang.NAME);
                lstStringInput.Add(strListColumnJoinTable);
            }

            {
                string strListColumnJoinTable = "";
                var lstColumnTable = new List<string>();
                lstColumnTable.Add(Table_BangViThuoc.Col_MaViThuoc.NAME);
                lstColumnTable.Add(Table_BangViThuoc.Col_TenViThuoc.NAME);

                _bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable
                  , lstColumnTable, ",", Table_BangViThuoc.NAME);
                lstStringInput.Add(strListColumnJoinTable);
            }

            _bllClass.GetStringJoinSplitChar(ref strSelect, lstStringInput, "\n,", "");

        }

    }
}
