using Newtonsoft.Json;
using SWQT._512ViewModels.Admin.Post;
using SWQT._512ViewModels.Common;
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

        #region POST METHOD

        public async Task<ApiResult<bool>> TApiAdd(VMAddPostRequest mRequest)
        {
            string strJsonInput = JsonConvert.SerializeObject(mRequest);
            string strRequestUri = STR_URI_Post.STR_URI_ADD_POST.STR;

            var mApiResult = await TPostAsync<ApiResult<bool>>(strRequestUri, strJsonInput);
            return mApiResult;
        }

        public async Task<ApiResult<PagedResult<DataTable>>> TApiGetListPaging(VMGetPostPaging mRequest)
        {
            string strRequestUri = $"{STR_URI_Post.STR_URI_LISTPOSTPAGING.STR}"
                + $"?{nameof(mRequest.IntPageIndex)}={mRequest.IntPageIndex}"
                + $"&{nameof(mRequest.IntPageSize)}={mRequest.IntPageSize}";
                //+ $"&{nameof(mRequest.StrKeyword)}={mRequest.StrKeyword}";

            var mApiResult = await TGetAsync<ApiResult<PagedResult<DataTable>>>(strRequestUri);
            return mApiResult;
        }

        #endregion

    }
}
