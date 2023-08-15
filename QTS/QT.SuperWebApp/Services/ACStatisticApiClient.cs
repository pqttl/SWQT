using Newtonsoft.Json;
using SWQT._512ViewModels.Common;
using SWQT._768ConstantValue.LinkApi;

namespace QT.SuperWebApp.Services
{
    public class ACStatisticApiClient : BaseApiClient, IStatisticApiClient
    {

        public ACStatisticApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        #region POST METHOD

        public async Task<ApiResult<bool>> TApiGetStatisticOrderByDictionary(Dictionary<string, object> dicInput)
        {
            string strJsonInput = JsonConvert.SerializeObject(dicInput);
            string strRequestUri = STR_URI_Statistic.STR_URI_GET_STATISTIC_ORDER_BY_DICTIONARY.STR;

            var mApiResult = await TPostAsync<ApiResult<bool>>(strRequestUri, strJsonInput);
            return mApiResult;
        }

        #endregion

    }
}
