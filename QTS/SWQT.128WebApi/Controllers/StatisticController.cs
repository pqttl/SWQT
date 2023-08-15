using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWQT._128WebApi.Services;
using SWQT._768ConstantValue.LinkApi;

namespace SWQT._128WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _iService;

        public StatisticController(IStatisticService iService)
        {
            _iService = iService;
        }

        //Link api: api/Statistic/TARGetOrderPagingByDictionary?...
        [HttpPost(STR_URI_Statistic.TARGetStatisticOrderByDictionary.STR)]
        public IActionResult TARGetStatisticOrderByDictionary([FromBody] Dictionary<string, object> dicInput)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var mResult = _iService.GetStatisticOrderByDictionary(dicInput);
            return Ok(mResult);
        }

    }
}
