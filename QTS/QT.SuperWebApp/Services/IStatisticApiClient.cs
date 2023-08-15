using SWQT._512ViewModels.Common;

namespace QT.SuperWebApp.Services
{
    public interface IStatisticApiClient
    {
        Task<ApiResult<bool>> TApiGetStatisticOrderByDictionary(Dictionary<string, object> dicInput);
    }
}
