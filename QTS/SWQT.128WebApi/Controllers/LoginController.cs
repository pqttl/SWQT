using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWQT._128WebApi.Services;
using SWQT._512ViewModels.Admin.Login;
using SWQT._768ConstantValue.LinkApi;

namespace SWQT._128WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService iService)
        {
            _loginService = iService;
        }

        //Link api: api/Login/TARAuthenticate
        [HttpPost(STR_URI_Login.TARAuthenticate.STR)]
        [AllowAnonymous]
        public IActionResult TARAuthenticate([FromBody] VMLoginRequest mRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string strJsonDictionary = _loginService.StrJsonAuthencate(mRequest);
            return Ok(strJsonDictionary);
        }

    }
}
