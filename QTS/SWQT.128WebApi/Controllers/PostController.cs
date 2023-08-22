using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWQT._128WebApi.Services;
using SWQT._512ViewModels.Admin.Post;
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

        //Link api: api/Post/TARGetListPostPaging?IntPageIndex=1&IntPageSize=10&strkeyword=
        [HttpGet(STR_URI_Post.TARGetListPostPaging.STR)]
        [AllowAnonymous]
        public IActionResult TARGetListPostPaging([FromQuery] VMGetPostPaging mRequest)
        {
            var mResult = _iService.GetPostPaging(mRequest);
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

    }
}
