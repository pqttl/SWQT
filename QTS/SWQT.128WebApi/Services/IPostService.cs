using SWQT._512ViewModels.Admin.Post;
using SWQT._512ViewModels.Common;
using SWQT._576Entity.Entities;
using System.Data;

namespace SWQT._128WebApi.Services
{
    public interface IPostService
    {
        ApiResult<bool> AddPost(VMAddPostRequest mRequest);
        ApiResult<List<TblListPost>> GetListDetailByListId(List<int> lstInput);
        ApiResult<PagedResult<DataTable>> GetPostPaging(VMGetPostPaging mRequest);
        ApiResult<PagedResult<List<TblListPost>>> GetPostPagingNewest(VMGetPostPaging mRequest);
        ApiResult<bool> BlnUpdateList(List<TblListPost> mRequest);
        ApiResult<bool> BlnDeleteByListId(List<int> mRequest);
    }
}
