using SWQT._512ViewModels.Common;

namespace SWQT._128WebApi.Services
{
    public interface IStatisticService
    {
        ApiResult<bool> GetStatisticOrderByDictionary(Dictionary<string, object> dicInput);
    }
}
