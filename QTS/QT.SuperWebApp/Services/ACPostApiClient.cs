using Newtonsoft.Json;
using SWQT._512ViewModels.Admin.Post;
using SWQT._512ViewModels.Common;
using SWQT._576Entity.Entities;
using SWQT._768ConstantValue.LinkApi;
using System.Data;

namespace QT.SuperWebApp.Services
{
    public class ACPostApiClient : BaseApiClient, IPostApiClient
    {

        public ACPostApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        #region GET METHOD

        public async Task<ApiResult<PagedResult<DataTable>>> TApiGetListPaging(VMGetPostPaging mRequest)
        {
            string strRequestUri = $"{STR_URI_Post.STR_URI_LISTPOSTPAGING.STR}"
                + $"?{nameof(mRequest.IntPageIndex)}={mRequest.IntPageIndex}"
                + $"&{nameof(mRequest.IntPageSize)}={mRequest.IntPageSize}";
            //+ $"&{nameof(mRequest.StrKeyword)}={mRequest.StrKeyword}";

            var mApiResult = await TGetAsync<ApiResult<PagedResult<DataTable>>>(strRequestUri);
            return mApiResult;
        }

        public async Task<ApiResult<PagedResult<List<TblListPost>>>> TApiGetListPagingNewest(VMGetPostPaging mRequest)
        {
            string strRequestUri = $"{STR_URI_Post.STR_URI_LISTPOSTPAGING_NEWEST.STR}"
                + $"?{nameof(mRequest.IntPageIndex)}={mRequest.IntPageIndex}"
                + $"&{nameof(mRequest.IntPageSize)}={mRequest.IntPageSize}";
            //+ $"&{nameof(mRequest.StrKeyword)}={mRequest.StrKeyword}";

            var mApiResult = await TGetAsync<ApiResult<PagedResult<List<TblListPost>>>>(strRequestUri);
            return mApiResult;
        }

        public async Task<ApiResult<List<TblListPost>>> TApiGetListDetailByListId(List<int> lstInput)
        {
            string strJsonInput = JsonConvert.SerializeObject(lstInput);
            string strRequestUri = STR_URI_Post.STR_URI_GETLIST_DETAILPOST_BYLISTID.STR;
            var mApiResult = await TGetAsyncByJson<ApiResult<List<TblListPost>>>(
                strRequestUri, strJsonInput);
            return mApiResult;
        }

        #endregion

        #region POST METHOD

        public async Task<ApiResult<bool>> TApiAdd(VMAddPostRequest mRequest)
        {
            string strJsonInput = JsonConvert.SerializeObject(mRequest);
            string strRequestUri = STR_URI_Post.STR_URI_ADD_POST.STR;

            var mApiResult = await TPostAsync<ApiResult<bool>>(strRequestUri, strJsonInput);
            return mApiResult;
        }

        public async Task<ApiResult<bool>> TApiUpdateList(List<TblListPost> mRequest)
        {
            string strJsonInput = JsonConvert.SerializeObject(mRequest);
            string strRequestUri = STR_URI_Post.STR_URI_UPDATE_LIST_POST.STR;

            var mApiResult = await TPostAsync<ApiResult<bool>>(strRequestUri, strJsonInput);
            return mApiResult;
        }

        public async Task<ApiResult<bool>> TApiDeleteByListId(List<int> mRequest)
        {
            string strJsonInput = JsonConvert.SerializeObject(mRequest);
            string strRequestUri = STR_URI_Post.STR_URI_DELETEBY_LISTID.STR;

            var mApiResult = await TPostAsync<ApiResult<bool>>(strRequestUri, strJsonInput);
            return mApiResult;
        }

        #endregion

    }
}
