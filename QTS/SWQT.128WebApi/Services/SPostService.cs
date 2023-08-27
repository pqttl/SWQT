using AutoMapper;
using SWQT._224DataAccessSQLiteEFCore.DALSQLite;
using SWQT._320DataAccessSQLite.DALSQLite;
using SWQT._512ViewModels.Admin.Post;
using SWQT._512ViewModels.Common;
using SWQT._576Entity.Entities;
using SWQT._768ConstantValue;
using System.Data;

namespace SWQT._128WebApi.Services
{
    public class SPostService: IPostService
    {

        private readonly DALLitePost DAL_Post = new DALLitePost();
        private readonly DALLiteEFPost DALEF_Post = new DALLiteEFPost();
        private readonly BLLProject _bllPlugin = new BLLProject();
        private readonly IConfiguration _iConfig;
        private readonly IMapper _iMapper;

        public SPostService(IConfiguration config, IMapper iMapper)
        {
            _iConfig = config;
            _iMapper = iMapper;
        }

        public ApiResult<bool> AddPost(VMAddPostRequest mRequest)
        {
            var apiError = new ApiErrorResult<bool>();

            if (mRequest.StrTitle == null || mRequest.StrTitle.Trim().Length < 12)
            {
                return apiError.MHaveMessage("Tiêu đề phải từ 12 kí tự trở lên!"
                    , "(mRequest.StrTitle == null || mRequest.StrTitle.Trim().Length < 12)");
            }

            string strError = "";
            Exception exOutput = null!;
            //bool blnSuccess = false;
            DAL_Post.AddList(ref strError, ref exOutput!, new List<VMAddPostRequest> { mRequest });
            if (exOutput != null)
            {
                return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace!);
            }

            if (strError!="")
            {
                return apiError.MHaveMessage("Thao tác không thành công, bạn vui lòng kiểm tra lại!"
                    , strError);
            }

            return new ApiSuccessResult<bool>();
        }

        public ApiResult<bool> BlnUpdateList(List<TblListPost> lstInput)
        {
            try
            {
                var lstData = new List<TblListPost>();
                foreach (var item in lstInput)
                {
                    if (item.Title == null || item.Title.Trim().Length < 12)
                    {
                        return new ApiSuccessResult<bool>().MHaveMessage("Tiêu đề phải từ 12 kí tự trở lên!"
                            , "(mRequest.StrTitle == null || mRequest.StrTitle.Trim().Length < 12)");
                    }

                    string strTitle = item.Title.Trim();
                    string strTextTrimNoUnicode = BLLTools.RemoveUnicode(strTitle);
                    string strMetaTitle = strTextTrimNoUnicode.Replace("  ", " ").Replace(" ", "-");

                    string strDescription = "Truy cập trang để xem chi tiết nội dung này ...";
                    try
                    {
                        string strPlainTextTrim = BLLTools.GetPlainTextFromHtml(item.Detail!);
                        strPlainTextTrim = System.Net.WebUtility.HtmlDecode(strPlainTextTrim);
                        strDescription = strPlainTextTrim.Replace("  ", " ");
                    }
                    catch (Exception et)
                    {
                        string str = et.Message;
                    }

                    strDescription = (strDescription.Length > 240) ? (strDescription.Substring(0, 240) + "...") : strDescription;

                    //var mData = new TblListPost();
                    //mData.Id = item.Id;
                    //mData.Title = strTitle;
                    //mData.Detail = item.Detail;
                    //mData.MetaTitle = strMetaTitle;
                    //mData.Description = strDescription;
                    //mData.ModifiedBy = "adminqt";
                    //mData.ModifiedDate = DateTime.Now.ToString(QTFormat.STR_DATETIME_SQLITE.STR);

                    var mData = _iMapper.Map<TblListPost>(item);
                    mData.Title = strTitle;
                    mData.MetaTitle = strMetaTitle;
                    mData.Description = strDescription;
                    mData.ModifiedBy = "adminqt";
                    mData.ModifiedDate = DateTime.Now.ToString(QTFormat.STR_DATETIME_SQLITE.STR);

                    lstData.Add(mData);
                }

                bool objResult = DALEF_Post.BlnUpdateListSuccess(lstData);
                return new ApiSuccessResult<bool>(objResult);
            }
            catch (Exception et)
            {
                var apiError = new ApiErrorResult<bool>();
                string str = et.Message;
                return apiError.MHaveMessage(str
                    , et.StackTrace!);
            }
        }

        public ApiResult<bool> BlnDeleteByListId(List<int> lstInput)
        {
            try
            {
                bool objResult = DALEF_Post.BlnSuccessDeleteByListId(lstInput);
                return new ApiSuccessResult<bool>(objResult);
            }
            catch (Exception et)
            {
                var apiError = new ApiErrorResult<bool>();
                string str = et.Message;
                return apiError.MHaveMessage(str
                    , et.StackTrace!);
            }
        }

        public ApiResult<PagedResult<DataTable>> GetPostPaging(VMGetPostPaging mRequest)
        {
            Exception exOutput = null!;
            DataTable DT_AllIdPost = null!;
            DAL_Post.GetDTAllIdPost(ref DT_AllIdPost!, ref exOutput!);

            var apiError = new ApiErrorResult<PagedResult<DataTable>>();
            var dicOutput = new Dictionary<string, object>();

            if (exOutput != null)
            {
                dicOutput["Exception"] = exOutput;
                //strJsonDictionary = JsonConvert.SerializeObject(dicOutput
                //  , Formatting.Indented);
                return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace!);
            }

            //int intPageSize = Convert.ToInt32(_iConfig[KeyFileConfig.STR_KEY_SO_ROW_1PAGE_PLUGIN_ORDER.STR]);
            var lstStringId = new List<string>();
            BLLTools.GetListStringIdInDataTable(ref lstStringId
              , mRequest.IntPageIndex, mRequest.IntPageSize, DT_AllIdPost, "Id");
            if (lstStringId.Count == 0)
            {
                //QTMessageBox.ShowNotify(
                //  "Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
                //  , "(lstStringId.Count==0)");
                return apiError.MHaveMessage("Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
                    , "(lstStringId.Count==0)");
            }

            //Exception exOutput = null;
            DataTable DT_AllDetailPostByListIdPost = null!;
            //DALOrder.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder,ref exOutput,lstStringId);
            DAL_Post.GetDTDetailOrderByListIdOrder(ref DT_AllDetailPostByListIdPost
                , ref exOutput!, lstStringId);
            if (exOutput != null)
            {
                //Log4Net.Error(exOutput.Message);
                //Log4Net.Error(exOutput.StackTrace);
                //ShowException(exOutput);
                return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace!);
            }

            if (DT_AllDetailPostByListIdPost == null)
            {
                //QTMessageBox.ShowNotify(
                //  "Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                //  , "(DT_AllDetailOrderByListIdOrder==null)");
                return apiError.MHaveMessage("Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                    , "(DT_AllDetailOrderByListIdOrder==null)");
            }

            //DataTable dtByPage = null!;
            //_bllPlugin.CloneAndCopyRowDataTableByPage(ref dtByPage, mRequest, DT_AllIdPost);

            //var dtOutput = new DataTable();
            //if (mRequest.StrTypeDevice == "pc")
            //{
            //    _bllPlugin.GetDataTableOrderPagingByPcView(ref dtOutput, dtByPage, DT_AllDetailPostByListIdPost);
            //}
            //if (mRequest.StrTypeDevice == "mobile")
            //{
            //    _bllPlugin.GetDataTableOrderPaging(ref dtOutput, dtByPage, DT_AllDetailPostByListIdPost);
            //}

            var mPagedResult = new PagedResult<DataTable>()
            {
                IntTotalRecords = DT_AllIdPost.Rows.Count,
                IntPageIndex = mRequest.IntPageIndex,
                IntPageSize = mRequest.IntPageSize,
                TOneItem = DT_AllDetailPostByListIdPost
            };
            return new ApiSuccessResult<PagedResult<DataTable>>(mPagedResult);
        }

        public ApiResult<PagedResult<List<TblListPost>>> GetPostPagingNewest(VMGetPostPaging mRequest)
        {
            try
            {
                var mPagedResult = new PagedResult<List<TblListPost>>()
                {
                    IntTotalRecords = DALEF_Post.IntTotalRow(),
                    IntPageIndex = mRequest.IntPageIndex,
                    IntPageSize = mRequest.IntPageSize,
                    TOneItem = DALEF_Post.LstByPageAndSize(mRequest)
                };
                return new ApiSuccessResult<PagedResult<List<TblListPost>>>(mPagedResult);
            }
            catch (Exception et)
            {
                var apiError = new ApiErrorResult<PagedResult<List<TblListPost>>>();
                string str = et.Message;
                return apiError.MHaveMessage(str
                    , et.StackTrace!);
            }
        }

        public ApiResult<List<TblListPost>> GetListDetailByListId(List<int> lstInput)
        {
            try
            {
                List<TblListPost> lst = DALEF_Post.LstByListId(lstInput);
                return new ApiSuccessResult<List<TblListPost>>(lst);
            }
            catch (Exception et)
            {
                var apiError = new ApiErrorResult<List<TblListPost>>();
                string str = et.Message;
                return apiError.MHaveMessage(str
                    , et.StackTrace!);
            }
        }

    }
}
