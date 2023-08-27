using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWQT._128WebApi.Services;
using SWQT._512ViewModels.Admin.Post;
using SWQT._576Entity.Entities;
using SWQT._768ConstantValue.LinkApi;

namespace SWQT._128WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _iService;

        public PostController(IPostService iService)
        {
            _iService = iService;
        }




        //Link api: api/Post/TARGetListPostPagingNewest?IntPageIndex=1&IntPageSize=10
        [HttpGet(STR_URI_Post.TARGetListPostPagingNewest.STR)]
        [AllowAnonymous]
        public IActionResult TARGetListPostPagingNewest([FromQuery] VMGetPostPaging mRequest)
        {
            var mResult = _iService.GetPostPagingNewest(mRequest);
            return Ok(mResult);
        }
        
        //Link api: api/Post/TARGetListPostPaging?IntPageIndex=1&IntPageSize=10
        [HttpGet(STR_URI_Post.TARGetListPostPaging.STR)]
        [AllowAnonymous]
        public IActionResult TARGetListPostPaging([FromQuery] VMGetPostPaging mRequest)
        {
            var mResult = _iService.GetPostPaging(mRequest);
            return Ok(mResult);
        }




        //Link api: api/Post/TARGetListDetailPostByListId
        [HttpPost(STR_URI_Post.TARGetListDetailPostByListId.STR)]
        [AllowAnonymous]
        public IActionResult TARGetListDetailPostByListId([FromBody] List<int> lstInput)
        {
            var mResult = _iService.GetListDetailByListId(lstInput);
            return Ok(mResult);
        }




        //Link api: api/Post/TARAddPost?...
        [HttpPost(STR_URI_Post.TARAddPost.STR)]
        public IActionResult TARAddPost([FromBody] VMAddPostRequest mRequest)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var mResult = _iService.AddPost(mRequest);
            return Ok(mResult);
        }

        //Link api: api/Post/TARUpdateListPost?...
        [HttpPost(STR_URI_Post.TARUpdateListPost.STR)]
        public IActionResult TARUpdateListPost([FromBody] List<TblListPost> mRequest)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var mResult = _iService.BlnUpdateList(mRequest);
            return Ok(mResult);
        }


        //Link api: api/Post/TARDeleteByListId?...
        [HttpPost(STR_URI_Post.TARDeleteByListId.STR)]
        public IActionResult TARDeleteByListId([FromBody] List<int> mRequest)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var mResult = _iService.BlnDeleteByListId(mRequest);
            return Ok(mResult);
        }




    }
}
