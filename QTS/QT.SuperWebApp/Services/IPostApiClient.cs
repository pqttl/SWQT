using SWQT._512ViewModels.Admin.Post;
using SWQT._512ViewModels.Common;
using System.Data;

namespace QT.SuperWebApp.Services
{
    public interface IPostApiClient
    {
        Task<ApiResult<bool>> TApiAdd(VMAddPostRequest mRequest);
        Task<ApiResult<PagedResult<DataTable>>> TApiGetListPaging(VMGetPostPaging mRequest);
    }
}
