using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SWQT._768ConstantValue
{
    public static class BLLTools
    {

        //public static void AddItemCbo(int intId, string strName, object objItem,
        //  ref ObservableCollection<ModelItems> lstCbo)
        //{
        //	var mItem = new ModelItems() { ID = intId, Name = strName };
        //	if (objItem != null)
        //	{
        //		mItem.ObjItem = objItem;
        //	}
        //	lstCbo.Add(mItem);
        //}

        public static void GetSumPageBySumItem(ref int intSumPage, int count, int INT_PAGE_SIZE)
        {
            if (count == 0)
            {
                intSumPage = 1;
                return;
            }

            intSumPage = count % INT_PAGE_SIZE != 0 ?
              count / INT_PAGE_SIZE + 1 : count / INT_PAGE_SIZE;
        }

        #region Function for DeepCopy cho Dictionary

        //public static void AddDeepModelToDictionary<T>(ref Dictionary<string, object> dicSubInput, string strKey, T objItem)
        //{
        //	T mitem = Helpers.Helpers.DeepCopy<T>(objItem);
        //	dicSubInput.Add(strKey, mitem);
        //}

        public static void AddDeepListModelToDictionary<T>(ref Dictionary<string, object> dicSubInput,
          string strKey, List<T> lstObject)
        {
            List<T> lstTemp = new List<T>();
            if (lstObject == null)
            {
                dicSubInput.Add(strKey, null!);
                return;
            }
            lstTemp.AddRange(lstObject);
            dicSubInput.Add(strKey, lstTemp);
        }

        //public static void AddDeepListModelToDictionary(ref Dictionary<string,object> dicSubInput,
        //  string strKey,object obj) {
        //  if(obj==null) {
        //	dicSubInput.Add(strKey,null);
        //	return;
        //  }
        //}

        #endregion

        public static void CheckHaveSpaceBetween(ref bool blnHaveChar, string strInput)
        {
            for (int i = 0; i < strInput.Length; i++)
            {
                if (strInput[i].Equals(" "))
                {
                    blnHaveChar = true;
                    return;
                }
            }
        }

        public static void CheckHaveCharVietnamese(ref bool blnHaveChar, string strInput)
        {
            char[] _lstChar = new char[] { 'á', 'à', 'ả', 'ã', 'ạ', 'â', 'ấ', 'ầ', 'ẩ', 'ẫ', 'ậ', 'ă', 'ắ', 'ằ', 'ẳ', 'ẵ', 'ặ',
            'đ',
            'é','è','ẻ','ẽ','ẹ','ê','ế','ề','ể','ễ','ệ',
            'í','ì','ỉ','ĩ','ị',
            'ó','ò','ỏ','õ','ọ','ô','ố','ồ','ổ','ỗ','ộ','ơ','ớ','ờ','ở','ỡ','ợ',
            'ú','ù','ủ','ũ','ụ','ư','ứ','ừ','ử','ữ','ự',
            'ý','ỳ','ỷ','ỹ','ỵ'};
            for (int i = 0; i < strInput.Length; i++)
            {
                if (_lstChar.Contains(strInput[i]))
                {
                    blnHaveChar = true;
                    return;
                }
            }
        }

        public static void ChangeFormatBirthDay(ref string strBirthDay, string strFormat)
        {
            string strTemp = strBirthDay;
            try
            {
                DateTime dt = Convert.ToDateTime(strTemp);
                strBirthDay = dt.ToString(strFormat);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Lấy thông tin về dấu thập phân()
        /// </summary>
        /// <param name="strDauThapPhan">Ví dụ như . hoặc ,</param>
        /// <param name="strChamHayPhay">Trả về 'chấm' hoặc 'phẩy'</param>
        /// <param name="strToolTip">Trả về máy tính đang cài đặt dấu gì ...</param>
        public static void GetInfoPhanThapPhan(ref string strDauThapPhan,
          ref string strChamHayPhay, ref string strToolTip)
        {
            strDauThapPhan =
              System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString();

            strChamHayPhay = (strDauThapPhan.Equals(".")) ? "chấm" : "phẩy";

            strToolTip = $"Máy tính của bạn hiện đang cài đặt ngăn cách phần thập phân bởi dấu {strChamHayPhay} '{strDauThapPhan}'";
            strToolTip += "\nBạn có thể thay đổi bằng cách vào Control Panel --> Clock and Region";
        }

        /// <summary>
        /// Ví dụ list string là a b c 
        /// thì output là "a,b,c" hoặc "t.a,t.b,t.c" với t là tiền tố, dấu phẩy là phân cách
        /// </summary>
        /// <param name="strOutput"></param>
        /// <param name="lstStringInput"></param>
        /// <param name="strCharSplit"></param>
        /// <param name="strTienTo"></param>
        public static void GetStringJoinSplitChar(ref string strOutput
          , List<string> lstStringInput, string strCharSplit, string strTienTo)
        {
            if (lstStringInput.Count == 0)
            {
                return;
            }

            string strThemVao = "";
            if (strTienTo != "")
            {
                strThemVao = $"{strTienTo}.";
            }

            for (int i = 0; i < lstStringInput.Count; i++)
            {
                if (i == 0)
                {
                    strOutput += strThemVao + lstStringInput[i];
                    continue;
                }

                strOutput += strCharSplit + strThemVao + lstStringInput[i];
            }
        }

        /// <summary>
        /// Ví dụ list string là a b c 
        /// thì output là "a,b,c" hoặc "t.a,t.b,t.c" với t là tiền tố, dấu phẩy là phân cách
        /// </summary>
        /// <param name="strOutput"></param>
        /// <param name="lstStringInput"></param>
        /// <param name="strCharSplit"></param>
        /// <param name="strTienTo"></param>
        public static void GetStringJoinSplitChar(ref string strOutput
          , List<int> lstStringInput, string strCharSplit, string strTienTo)
        {
            if (lstStringInput.Count == 0)
            {
                return;
            }

            string strThemVao = "";
            if (strTienTo != "")
            {
                strThemVao = $"{strTienTo}.";
            }

            for (int i = 0; i < lstStringInput.Count; i++)
            {
                if (i == 0)
                {
                    strOutput += strThemVao + lstStringInput[i];
                    continue;
                }

                strOutput += strCharSplit + strThemVao + lstStringInput[i];
            }
        }

        public static void UpperTextStartByQuantity(ref string strOutput, string strInput, int intSoKyTuDauTien)
        {
            if (intSoKyTuDauTien <= 0)
            {
                strOutput = strInput;
                return;
            }

            if (intSoKyTuDauTien >= strInput.Length)
            {
                strOutput = strInput.ToUpper();
                return;
            }

            strOutput = strInput.Substring(0, intSoKyTuDauTien).ToUpper() + strInput.Substring(intSoKyTuDauTien);
        }

        #region Convert object to string theo format

        /// <summary>
        /// Nếu decimal bằng 0 thì trả về 0 vì mặc định nó trả về 00, không thì trả về đúng dạng
        /// </summary>
        /// <param name="strOutput"></param>
        /// <param name="decInput"></param>
        /// <param name="strEndString"></param>
        public static void GetStringFormatTienMat(ref string strOutput, decimal decInput, string strEndString)
        {
            if (decInput < 0)
            {
                return;
            }
            if (decInput == 0)
            {
                strOutput = "0" + strEndString;
                return;
            }

            strOutput = "" + string.Format("{0:0,0}", decInput) + strEndString;
        }

        /// <summary>
        /// mặc định trả về 0 value và "0"+"strEndString" nếu không hợp lệ
        /// </summary>
        /// <param name="decOutput"></param>
        /// <param name="strOutput"></param>
        /// <param name="objInput"></param>
        /// <param name="strEndString"></param>
        public static void GetStringFormatTienMat(ref decimal decOutput, ref string strOutput
          , object objInput, string strEndString)
        {
            decOutput = 0;
            try
            {
                decOutput = Convert.ToDecimal(objInput
                    , new NumberFormatInfo()
                    {
                        NumberDecimalSeparator = "."
                    ,
                        NumberGroupSeparator = ","
                    });
            }
            catch (Exception e)
            {
                string str = e.Message;
            }

            GetStringFormatTienMat(ref strOutput, decOutput, strEndString);
        }

        /// <summary>
        /// nếu không hợp lệ, mặc định sẽ trả về 1993.11.13 và string không thay đổi gì cả
        /// </summary>
        /// <param name="dtOutput"></param>
        /// <param name="strOutput"></param>
        /// <param name="objInput"></param>
        public static void GetStringFormatDateTimeVN(ref DateTime dtOutput, ref string strOutput, object objInput)
        {
            dtOutput = new DateTime(1993, 11, 13);
            try
            {
                dtOutput = Convert.ToDateTime(objInput);
                strOutput = dtOutput.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception e)
            {
                string str = e.Message;
            }
        }

        #endregion

        public static string RemoveUnicode(string s)
        {
            s = s.Trim();
            string normalized = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < normalized.Length; i++)
            {
                Char c = normalized[i];
                if (Convert.ToInt32(c) == 273)
                    sb.Append("d");
                else if (Convert.ToInt32(c) == 208 | Convert.ToInt32(c) == 272)
                    sb.Append("D");
                else if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            string value = sb.ToString().Normalize(NormalizationForm.FormC);
            string _return = "";
            for (int i = 0; i < value.Length - 1; i++)
            {
                string a = value.Substring(i, 2);

                if (a == "  ")
                {
                    _return += "";
                }
                else
                {
                    _return += a.Substring(0, 1);
                }

            }
            string[] dau = new string[] { ":", ",", ".", "!", ";", "?", "'", "-", "`", "~", "@", "#", "$", "%", "^", "&", "*", "(", ")", "/", ",", "\\", "|", "’", "“" };
            if (value.Length > 0)
            {
                _return += value.Substring(value.Length - 1, 1);
            }
            _return = _return.ToLower();
            string _return2 = "";
            for (int i = 0; i < _return.Length; i++)
            {
                bool check = false;
                string a = _return.Substring(i, 1);
                for (int j = 0; j < dau.Length; j++)
                {
                    if (a == dau[j])
                    {
                        check = true;
                        break;
                    }
                }
                if (check == true)
                {
                    a = "";
                }
                _return2 += a;
            }
            _return2 = _return2.Replace("'", "");
            _return2 = _return2.Replace(@"\", "");
            return _return2;
        }

        public static void GetDecimalFromString(ref decimal decOutput, string strInput)
        {
            if (strInput != null)
            {
                try
                {
                    decOutput = Convert.ToDecimal(strInput
                        , new NumberFormatInfo()
                        {
                            NumberDecimalSeparator = "."
                        ,
                            NumberGroupSeparator = ","
                        });
                }
                catch (Exception e)
                {
                    string str = e.Message;
                }
            }
        }

        #region Thao tác với dataTable

        public static void CheckStringExistInDataTable(ref bool blnExistNameInOrder
            , string strInput, DataTable dtInput, string strColumnName)
        {
            blnExistNameInOrder = true;
            string strNameColumnSimilar = "";
            GetNameColumnSimilarFromDataTable(ref strNameColumnSimilar, dtInput, strColumnName);

            if (strNameColumnSimilar == "")
            {
                return;
            }
            foreach (DataRow dRow in dtInput.Rows)
            {
                string strValueCell = dRow[strNameColumnSimilar].ToString()!;
                if (strValueCell.Trim() == strInput.Trim())
                {
                    return;
                }
            }

            blnExistNameInOrder = false;
        }

        public static void GetListStringInColumnDataTable(ref List<string> lstString
            , DataTable dtInput, string strColumnName)
        {
            string strNameColumnSimilar = "";
            GetNameColumnSimilarFromDataTable(ref strNameColumnSimilar, dtInput, strColumnName);

            if (strNameColumnSimilar == "")
            {
                return;
            }

            foreach (DataRow dRow in dtInput.Rows)
            {
                string strValueCell = dRow[strNameColumnSimilar].ToString()!;
                lstString.Add(strValueCell);
            }
        }

        private static void GetNameColumnSimilarFromDataTable(ref string strNameColumnSimilar
            , DataTable dtInput, string strColumnName)
        {
            foreach (DataColumn dCol in dtInput.Columns)
            {
                if (dCol.ColumnName.ToUpper() == strColumnName.ToUpper())
                {
                    strNameColumnSimilar = dCol.ColumnName;
                    break;
                }
            }
        }

        /// <summary>
        /// Lấy ra 1 DataTable con từ 1 DataTable to được phân loại từ cột x với giá trị là y
        /// </summary>
        /// <param name="dtOutput"></param>
        /// <param name="dtInput"></param>
        /// <param name="strColumnName"></param>
        /// <param name="strIdOrder"></param>
        public static void GetDataTableFilterBy1ValueOn1Column(ref DataTable dtOutput, DataTable dtInput
            , string strColumnName, string strValue)
        {
            dtOutput = dtInput.Clone();

            int intStartIndex = 0;
            int intEndIndex = dtInput.Rows.Count;
            for (int i = intStartIndex; i < intEndIndex; i++)
            {
                string strValueInTable = "" + dtInput.Rows[i][strColumnName].ToString();
                if (strValueInTable != strValue)
                {
                    continue;
                }

                DataRow dr = dtInput.Rows[i];
                dtOutput.ImportRow(dr);
            }
        }

        public static void GetListStringIdInDataTable(ref List<string> lstStringId, int intIdPage
          , int CONST_INT_PAGE_SIZE, DataTable dtInput, string strNameColumn)
        {
            lstStringId = new List<string>();

            int intStartIndex = intIdPage * CONST_INT_PAGE_SIZE;
            int intMaxEndIndexByPage = (intIdPage + 1) * CONST_INT_PAGE_SIZE;
            int intEndIndex = dtInput.Rows.Count < intMaxEndIndexByPage ?
              dtInput.Rows.Count : intMaxEndIndexByPage;

            for (int i = intStartIndex; i < intEndIndex; i++)
            {
                lstStringId.Add(dtInput.Rows[i][strNameColumn].ToString()!);
            }
        }

        #endregion

        public static string StrListParameterAJAX(List<string> lstInput)
        {
            if (lstInput.Count == 0)
            {
                return "";
            }

            string strTemp = "" + lstInput[0] + ":" + lstInput[0];
            if (lstInput.Count == 1)
            {
                return strTemp;
            }

            for (int i = 1; i < lstInput.Count; i++)
            {
                strTemp += "," + lstInput[i] + ":" + lstInput[i];
            }

            return strTemp;
        }

        public static List<string> LstStrIdByListKey(string strId, List<string> lstStrKey)
        {
            var lstOutput = new List<string>();
            foreach (var item in lstStrKey)
            {
                lstOutput.Add(strId + "_" + item);
            }
            return lstOutput;
        }

        public static string GetPlainTextFromHtml(string htmlString)
        {
            //string htmlTagPattern = "<.*?>";
            //var regexCss = new Regex("(\\<script(.+?)\\)|(\\<style(.+?)\\)",RegexOptions.Singleline|RegexOptions.IgnoreCase);
            //htmlString=regexCss.Replace(htmlString,string.Empty);
            //htmlString=Regex.Replace(htmlString,htmlTagPattern,string.Empty);
            //htmlString=Regex.Replace(htmlString,@"^\s+$[\r\n]*","",RegexOptions.Multiline);
            //htmlString=htmlString.Replace(" ",string.Empty);

            //return htmlString;

            //Match any Html tag (opening or closing tags) 
            // followed by any successive whitespaces
            //consider the Html text as a single line

            Regex regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);

            // replace all html tags (and consequtive whitespaces) by spaces
            // trim the first and last space

            string resultText = regex.Replace(htmlString, " ").Trim();

            return resultText;

        }

    }
}
