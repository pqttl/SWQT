using SWQT._512ViewModels.Admin.Post;
using SWQT._512ViewModels.Common;
using System.Data;

namespace SWQT._128WebApi.Services
{
    public interface IPostService
    {
        ApiResult<bool> AddPost(VMAddPostRequest mRequest);
        ApiResult<PagedResult<DataTable>> GetPostPaging(VMGetPostPaging mRequest);
    }
}
