using SWQT._320DataAccessSQLite.DALSQLite;
using SWQT._512ViewModels.Common;
using SWQT._768ConstantValue;
using System.Data;

namespace SWQT._128WebApi.Services
{
    public class SStatisticService : IStatisticService
    {
        private readonly DALLiteOrder DAL_Order = new DALLiteOrder();
        //private readonly DALLiteProduct DAL_Product = new DALLiteProduct();
        private readonly BLLProject _bllPlugin = new BLLProject();
        private readonly IConfiguration _iConfig;

        public SStatisticService(IConfiguration config)
        {
            _iConfig = config;
        }

        public ApiResult<bool> GetStatisticOrderByDictionary(
            Dictionary<string, object> dicRequest)
        {
            try
            {
                var apiError = new ApiErrorResult<bool>();
                var dicOutput = new Dictionary<string, object>();

                DateTime dtimeStart = DateTime.ParseExact(dicRequest["strStartDate"].ToString()!
            , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);
                DateTime dtimeEnd = DateTime.ParseExact(dicRequest["strEndDate"].ToString()!
            , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);
                if (dtimeStart > dtimeEnd)
                {
                    string strMess = "Thiết lập thời gian kết thúc phải lớn hơn thời gian bắt đầu, bạn vui lòng thao tác lại!";
                    //dicOutput["strIdFocus"] = nameof(strSpanKg);
                    return apiError.MHaveMessageWithDictionary(strMess, dicOutput, "");
                }

                Exception exOutput = null!;
                DataTable DT_AllIdOrder = null!;
                DAL_Order.GetDTAllIdOrderByTime(ref DT_AllIdOrder!, ref exOutput!, dtimeStart, dtimeEnd);

                if (exOutput != null)
                {
                    //dicOutput["strIdFocus"] = nameof(strSpanDonGia);
                    return apiError.MHaveMessageWithDictionary(exOutput.Message, dicOutput
                        , exOutput.StackTrace!);
                }

                int intPageIndex = Convert.ToInt32(dicRequest["intPageIndex"].ToString());
                int intPageSize = Convert.ToInt32(dicRequest["intPageSize"].ToString());
                var lstStringId = new List<string>();
                BLLTools.GetListStringIdInDataTable(ref lstStringId
                  , intPageIndex, intPageSize, DT_AllIdOrder, "MaDonHang");
                if (lstStringId.Count == 0)
                {
                    return apiError.MHaveMessage("Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
                        , "(lstStringId.Count==0)");
                }

                DataTable DT_AllDetailOrderByListIdOrder = null!;
                DAL_Order.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder, ref exOutput!, lstStringId);
                if (exOutput != null)
                {
                    return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace!);
                }

                if (DT_AllDetailOrderByListIdOrder == null)
                {
                    return apiError.MHaveMessage("Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                        , "(DT_AllDetailOrderByListIdOrder==null)");
                }

                dicOutput = new Dictionary<string, object>();
                dicOutput["DT_AllIdOrder"] = DT_AllIdOrder;
                dicOutput["DT_AllDetailOrderByListIdOrder"] = DT_AllDetailOrderByListIdOrder;
                return new ApiSuccessResult<bool>(true, dicOutput);

            }
            catch (Exception et)
            {
                return (new ApiErrorResult<bool>()).MHaveMessage(et.Message, et.StackTrace!);
            }
        }

    }
}
