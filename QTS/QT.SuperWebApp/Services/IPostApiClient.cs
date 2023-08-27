using SWQT._512ViewModels.Admin.Post;
using SWQT._512ViewModels.Common;
using SWQT._576Entity.Entities;
using System.Data;

namespace QT.SuperWebApp.Services
{
    public interface IPostApiClient
    {
        Task<ApiResult<bool>> TApiAdd(VMAddPostRequest mRequest);
        Task<ApiResult<bool>> TApiDeleteByListId(List<int> mRequest);
        Task<ApiResult<List<TblListPost>>> TApiGetListDetailByListId(List<int> lstInput);
        Task<ApiResult<PagedResult<DataTable>>> TApiGetListPaging(VMGetPostPaging mRequest);
        Task<ApiResult<PagedResult<List<TblListPost>>>> TApiGetListPagingNewest(VMGetPostPaging mRequest);
        Task<ApiResult<bool>> TApiUpdateList(List<TblListPost> mRequest);
    }
}
