using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace SWQT._128WebApi
{
    public class BLLProject
    {
        #region Encode decode base64

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        #endregion

        //public void CloneAndCopyRowDataTableByPage(ref DataTable dtByPage, PagingRequestBase mRequest
        //    , DataTable dtInput)
        //{
        //    dtByPage = dtInput.Clone();

        //    int intIdPage = mRequest.IntPageIndex;
        //    int CONST_INT_PAGE_SIZE = mRequest.IntPageSize;

        //    int intStartIndex = intIdPage * CONST_INT_PAGE_SIZE;
        //    int intMaxEndIndexByPage = (intIdPage + 1) * CONST_INT_PAGE_SIZE;
        //    int intEndIndex = dtInput.Rows.Count < intMaxEndIndexByPage ?
        //      dtInput.Rows.Count : intMaxEndIndexByPage;

        //    for (int i = intStartIndex; i < intEndIndex; i++)
        //    {
        //        DataRow dr = dtInput.Rows[i];
        //        dtByPage.ImportRow(dr);
        //    }
        //}

        //internal void GetDataTableOrderPaging(ref DataTable dtOutput, DataTable dtByPage
        //    , DataTable dtDetail)
        //{
        //    var mVMDataTable = new OrderPagingMobile_VMDataTable();
        //    var lstStringNameColumn = mVMDataTable.MDisplay.LstStringNameColumn;

        //    foreach (var item in lstStringNameColumn)
        //    {
        //        dtOutput.Columns.Add(item);
        //    }

        //    int intSttIncrease = 0;
        //    foreach (DataRow dRowInput in dtByPage.Rows)
        //    {
        //        int intIndexIncrease = -1;
        //        DataRow dRow = dtOutput.NewRow();

        //        //{
        //        //    string strTemp = "" + (++intSttIncrease);
        //        //    dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        //}

        //        {
        //            string strTemp = "Định dạng TG False";
        //            DateTime objTemp = new DateTime(1993, 11, 13);

        //            BLLTools.GetStringFormatDateTimeVN(ref objTemp, ref strTemp
        //              , dRowInput[Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME]);
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = $"({"" + (++intSttIncrease)}) " + strTemp;
        //        }

        //        string strIdOrder = "" + dRowInput[Table_BangDanhSachDonHang.Col_MaDonHang.NAME].ToString().Trim();

        //        var dtDetailById = new DataTable();
        //        BLLTools.GetDataTableFilterBy1ValueOn1Column(ref dtDetailById, dtDetail
        //            , Table_BangChiTietDonHang.Col_MaDonHang.NAME, strIdOrder);


        //        string strTongVT_KL_GT = "";
        //        {
        //            string strTemp = $"{dtDetailById.Rows.Count} vị thuốc";
        //            //dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //            //strTongVT_KL_GT = $"({strTemp})";
        //            strTongVT_KL_GT = "<p class='classPTongLoai'>" + strTemp + "</p>";
        //        }

        //        float floatSumKg = 0;
        //        decimal decimalSumGiaTri = 0;
        //        foreach (DataRow dRowDetail in dtDetailById.Rows)
        //        {

        //            float floatKg = 0;
        //            {
        //                string strTemp = "Định dạng Float False";
        //                float objTemp = 0;
        //                try
        //                {
        //                    objTemp = Convert.ToSingle(dRowDetail[Table_BangChiTietDonHang.Col_SoLuongViThuoc.NAME]);
        //                    strTemp = string.Format("{0:N3}", objTemp);
        //                }
        //                catch (Exception e)
        //                {
        //                    string str = e.Message;
        //                }
        //                floatKg = objTemp;
        //            }

        //            decimal decimalDonGia = 0;
        //            {
        //                string strTemp = "Định dạng Decimal False";
        //                decimal objTemp = 0;
        //                try
        //                {
        //                    objTemp = Convert.ToDecimal(dRowDetail[Table_BangGiaViThuoc.Col_GiaViThuoc.NAME]
        //                , new NumberFormatInfo()
        //                {
        //                    NumberDecimalSeparator = "."
        //                ,
        //                    NumberGroupSeparator = ","
        //                });
        //                    strTemp = string.Format("{0:0,0}", objTemp) + " đ";
        //                }
        //                catch (Exception e)
        //                {
        //                    string str = e.Message;
        //                }
        //                decimalDonGia = objTemp;
        //            }

        //            floatSumKg += floatKg;
        //            decimalSumGiaTri += (decimal)floatKg * decimalDonGia;

        //        }

        //        {
        //            string strTemp = string.Format("{0:0.###}", floatSumKg) + " Kg";
        //            //dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //            //strTongVT_KL_GT += "<br>" + strTemp;
        //            strTongVT_KL_GT += "<p class='classPQuantity'>" + strTemp + "</p>";
        //        }

        //        {
        //            string strSumGiaTri = "";
        //            //BLLTools.GetStringFormatTienMat(ref strSumGiaTri, decimalSumGiaTri, " đ");
        //            BLLTools.GetStringFormatTienMat(ref strSumGiaTri, decimalSumGiaTri, "(đ)");
        //            string strTemp = strSumGiaTri;
        //            //dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //            //strTongVT_KL_GT += "<br>" + strTemp;
        //            strTongVT_KL_GT += "<p class='classPThanhTien'>" + strTemp + "</p>";
        //        }

        //        dRow[lstStringNameColumn[++intIndexIncrease]] = strTongVT_KL_GT;

        //        {
        //            string strTemp = "" + dRowInput[Table_BangKhachHang.Col_TenKhachHang.NAME].ToString().Trim();
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        {
        //            string strTemp = strIdOrder;
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        dtOutput.Rows.Add(dRow);

        //    }
        //}

        //internal void GetDataTableOrderPagingByPcView(ref DataTable dtOutput, DataTable dtByPage
        //    , DataTable dtDetail)
        //{
        //    var mVMDataTable = new OrderPaging_VMDataTable();
        //    var lstStringNameColumn = mVMDataTable.LstStringNameColumn;

        //    foreach (var item in lstStringNameColumn)
        //    {
        //        dtOutput.Columns.Add(item);
        //    }

        //    int intSttIncrease = 0;
        //    foreach (DataRow dRowInput in dtByPage.Rows)
        //    {
        //        int intIndexIncrease = -1;
        //        DataRow dRow = dtOutput.NewRow();

        //        {
        //            string strTemp = "" + (++intSttIncrease);
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        string strIdOrder = "" + dRowInput[Table_BangDanhSachDonHang.Col_MaDonHang.NAME].ToString().Trim();
        //        {
        //            string strTemp = strIdOrder;
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        {
        //            string strTemp = "Định dạng TG False";
        //            DateTime objTemp = new DateTime(1993, 11, 13);

        //            BLLTools.GetStringFormatDateTimeVN(ref objTemp, ref strTemp
        //              , dRowInput[Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME]);
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        var dtDetailById = new DataTable();
        //        BLLTools.GetDataTableFilterBy1ValueOn1Column(ref dtDetailById, dtDetail
        //            , Table_BangChiTietDonHang.Col_MaDonHang.NAME, strIdOrder);

        //        {
        //            string strTemp = $"{dtDetailById.Rows.Count} vị thuốc";
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        float floatSumKg = 0;
        //        decimal decimalSumGiaTri = 0;
        //        foreach (DataRow dRowDetail in dtDetailById.Rows)
        //        {

        //            float floatKg = 0;
        //            {
        //                string strTemp = "Định dạng Float False";
        //                float objTemp = 0;
        //                try
        //                {
        //                    objTemp = Convert.ToSingle(dRowDetail[Table_BangChiTietDonHang.Col_SoLuongViThuoc.NAME]);
        //                    strTemp = string.Format("{0:N3}", objTemp);
        //                }
        //                catch (Exception e)
        //                {
        //                    string str = e.Message;
        //                }
        //                floatKg = objTemp;
        //            }

        //            decimal decimalDonGia = 0;
        //            {
        //                string strTemp = "Định dạng Decimal False";
        //                decimal objTemp = 0;
        //                try
        //                {
        //                    objTemp = Convert.ToDecimal(dRowDetail[Table_BangGiaViThuoc.Col_GiaViThuoc.NAME]
        //                , new NumberFormatInfo()
        //                {
        //                    NumberDecimalSeparator = "."
        //                ,
        //                    NumberGroupSeparator = ","
        //                });
        //                    strTemp = string.Format("{0:0,0}", objTemp) + " đ";
        //                }
        //                catch (Exception e)
        //                {
        //                    string str = e.Message;
        //                }
        //                decimalDonGia = objTemp;
        //            }

        //            floatSumKg += floatKg;
        //            decimalSumGiaTri += (decimal)floatKg * decimalDonGia;

        //        }

        //        {
        //            string strTemp = string.Format("{0:0.###}", floatSumKg) + " Kg";
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        {
        //            string strSumGiaTri = "";
        //            BLLTools.GetStringFormatTienMat(ref strSumGiaTri, decimalSumGiaTri, " đ");
        //            string strTemp = strSumGiaTri;
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        {
        //            string strTemp = "" + dRowInput[Table_BangKhachHang.Col_TenKhachHang.NAME].ToString().Trim();
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        dtOutput.Rows.Add(dRow);

        //    }
        //}

        //internal void GetDataTableDetailOrder(ref Tuple<string, string> tupleSumSoLuong1GiaTri2
        //    , ref float floatSumSoLuong, ref decimal decimalSumGiaTri
        //    , ref DataTable dtOutput, DataTable dtDetail)
        //{
        //    var mVMDataTable = new DetailOrder_VMDataTable();
        //    var lstStringNameColumn = mVMDataTable.MDisplay.LstStringNameColumn;

        //    for (int i = 0; i < lstStringNameColumn.Count; i++)
        //    {
        //        lstStringNameColumn[i] = lstStringNameColumn[i].ToLower();
        //    }

        //    foreach (var item in lstStringNameColumn)
        //    {
        //        dtOutput.Columns.Add(item);
        //    }

        //    int intSttIncrease = 0;
        //    foreach (DataRow dRowInput in dtDetail.Rows)
        //    {
        //        int intIndexIncrease = -1;
        //        DataRow dRow = dtOutput.NewRow();

        //        {
        //            string strTemp = "" + (++intSttIncrease);
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        {
        //            string strTemp = "" + dRowInput[Table_BangViThuoc.Col_TenViThuoc.NAME].ToString().Trim();
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        {
        //            string strTemp = "Định dạng Float False";
        //            float objTemp = 0;
        //            try
        //            {
        //                objTemp = Convert.ToSingle(dRowInput[Table_BangChiTietDonHang.Col_SoLuongViThuoc.NAME]);
        //                //strTemp = string.Format("{0:N3}", objTemp);
        //                strTemp = string.Format("{0:0.###}", objTemp);
        //            }
        //            catch (Exception e)
        //            {
        //                string str = e.Message;
        //            }
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //            floatSumSoLuong += objTemp;
        //            //mitem.FloatSumKg = objTemp;
        //            //mitem.StrSumKg = strTemp;
        //        }

        //        {
        //            string strTemp = "" + dRowInput[Table_BangGiaViThuoc.Col_DonViGiaThuoc.NAME].ToString().Trim();
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        {
        //            string strTemp = "Định dạng Decimal False";
        //            decimal objTemp = 0;
        //            try
        //            {
        //                objTemp = Convert.ToDecimal(dRowInput[Table_BangGiaViThuoc.Col_GiaViThuoc.NAME]
        //                , new NumberFormatInfo()
        //                {
        //                    NumberDecimalSeparator = "."
        //                ,
        //                    NumberGroupSeparator = ","
        //                });
        //                //strTemp=string.Format("{0:N3}",objTemp);
        //                strTemp = string.Format("{0:0,0}", objTemp) + " đ";
        //                //strTemp=double.Parse(objTemp.ToString()).ToString("#,###",CultureInfo.GetCultureInfo("vi-VN"))+" vnđ";
        //            }
        //            catch (Exception e)
        //            {
        //                string str = e.Message;
        //            }
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //            //mitem.DecimalDonGia = objTemp;
        //            //mitem.StrDonGia = strTemp;
        //        }

        //        {
        //            string strTemp = "Định dạng Decimal False";
        //            decimal objTemp = 0;
        //            try
        //            {
        //                objTemp = Convert.ToDecimal(dRowInput[Table_BangChiTietDonHang.Col_ThanhTienTamThoi.NAME]
        //                , new NumberFormatInfo()
        //                {
        //                    NumberDecimalSeparator = "."
        //                ,
        //                    NumberGroupSeparator = ","
        //                });
        //                //strTemp=string.Format("{0:N3}",objTemp);
        //                strTemp = string.Format("{0:0,0}", objTemp) + " đ";
        //                //strTemp=double.Parse(objTemp.ToString()).ToString("#,###",CultureInfo.GetCultureInfo("vi-VN"))+" vnđ";
        //            }
        //            catch (Exception e)
        //            {
        //                string str = e.Message;
        //            }
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //            decimalSumGiaTri += objTemp;
        //            //mitem.DecimalThanhTien = objTemp;
        //            //mitem.StrThanhTien = strTemp;
        //        }

        //        {
        //            string strTemp = "" + dRowInput[Table_BangChiTietDonHang.Col_MaChiTietDonHang.NAME].ToString().Trim();
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        dtOutput.Rows.Add(dRow);

        //    }

        //    string strSumSoLuong = string.Format("{0:0.###}", floatSumSoLuong);
        //    string strSumGiaTri = string.Format("{0:0,0}", decimalSumGiaTri) + " đ";
        //    tupleSumSoLuong1GiaTri2 = new Tuple<string, string>(strSumSoLuong, strSumGiaTri);
        //}

        //internal void GetDataTableDetailOrderMobile(ref DataTable dtOutput, DataTable dtInput)
        //{
        //    var mVMDataTable = new DetailOrderMobile_VMDataTable();
        //    var lstStringNameColumn = mVMDataTable.MDisplay.LstStringNameColumn;

        //    foreach (var item in lstStringNameColumn)
        //    {
        //        dtOutput.Columns.Add(item);
        //    }

        //    int intSttIncrease = 0;
        //    foreach (DataRow dRowInput in dtInput.Rows)
        //    {
        //        int intIndexIncrease = -1;
        //        DataRow dRow = dtOutput.NewRow();

        //        {
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = "" + (++intSttIncrease);
        //        }

        //        string strTVT_SL = "";
        //        {
        //            string strTemp = dRowInput[DetailOrder_VMDataTable.COL01.STR].ToString();
        //            strTVT_SL += "<p class='classP'>" + strTemp + "</p>";
        //        }
        //        {
        //            string strTemp = "";
        //            strTemp = dRowInput[DetailOrder_VMDataTable.COL02.STR].ToString()
        //                + " " + dRowInput[DetailOrder_VMDataTable.COL03.STR].ToString();
        //            strTVT_SL += "<p class='classPQuantity'>" + strTemp + "</p>";
        //        }
        //        dRow[lstStringNameColumn[++intIndexIncrease]] = strTVT_SL;

        //        string strSL_DG_TT = "";
        //        //{
        //        //    string strTemp = "";
        //        //    strTemp = dRowInput[DetailOrder_VMDataTable.COL02.STR].ToString()
        //        //        +" "+ dRowInput[DetailOrder_VMDataTable.COL03.STR].ToString();
        //        //    strSL_DG_TT += "<p class='classPQuantity'>" + strTemp + "</p>";
        //        //}
        //        {
        //            string strTemp = "";
        //            strTemp = dRowInput[DetailOrder_VMDataTable.COL04.STR].ToString();
        //            strSL_DG_TT += "<p class='classPTongLoai'>" + strTemp + "</p>";
        //        }
        //        {
        //            string strTemp = "";
        //            strTemp = dRowInput[DetailOrder_VMDataTable.COL05.STR].ToString();
        //            strSL_DG_TT += "<p class='classPThanhTien'>" + strTemp + "</p>";
        //        }

        //        //string strStartHtml = "<div class=\"d-flex justify-content-between\"><div class=\"my-auto\"><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"22\" height=\"22\" fill=\"currentColor\" class=\"bi bi-pencil-square\" viewBox=\"0 0 16 16\">  <path d=\"M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z\"></path>  <path fill-rule=\"evenodd\" d=\"M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z\"></path></svg></div>        <div class=\"d-flex justify-content-end\">    <div class=\"mx-2\">";
        //        //string strEndHtml = "</div><div class=\"my-auto\"><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"22\" height=\"22\" fill=\"currentColor\" class=\"bi bi-trash3-fill\" viewBox=\"0 0 16 16\">  <path d=\"M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z\"></path></svg></div></div>    </div>";
        //        dRow[lstStringNameColumn[++intIndexIncrease]] = strSL_DG_TT;
        //        //dRow[lstStringNameColumn[++intIndexIncrease]] = strStartHtml + strSL_DG_TT + strEndHtml;

        //        {
        //            string strTemp = dRowInput[DetailOrder_VMDataTable.COL06.STR].ToString();
        //            dRow[lstStringNameColumn[++intIndexIncrease]] = strTemp;
        //        }

        //        dtOutput.Rows.Add(dRow);

        //    }
        //}
    }
}
