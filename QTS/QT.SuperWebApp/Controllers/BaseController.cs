using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SWQT._768ConstantValue;

namespace QT.SuperWebApp.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString(QTConstants.AppSettings.Token.STR);
            if (sessions == null)
            {
                string strTemp = nameof(QT.SuperWebApp.Controllers.LoginController);
                string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
                string strActionLogin = nameof(QT.SuperWebApp.Controllers.LoginController.Index);
                context.Result = new RedirectToActionResult(strActionLogin, strController, null);
            }
            base.OnActionExecuting(context);
        }

        #region load jQuery PartialView

        public IActionResult PartialViewSortMaxToMin(string[] arrayStrInput)
        {
            string strNameFunction = nameof(PartialViewSortMaxToMin);
            try
            {
                string strJson = "";
                {
                    var strSession = HttpContext.Session.GetString(strNameFunction);
                    if (strSession == null)
                    {
                        return Content("strSession == null");
                    }
                    strJson = strSession;
                    HttpContext.Session.SetString(strNameFunction, "");
                    if (strSession == "")
                    {
                        return Content("strSession == ''");
                    }
                }
                var dicInput = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                    strJson);

                List<Tuple<string, string>> lstTupleInput = JsonConvert.DeserializeObject<List<Tuple<string, string>>>(
                    dicInput!["List<Tuple<string,string>>"].ToString()!)!;

                ViewData["List<Tuple<string,string>>"] = lstTupleInput;
                ViewData["string.strTimeBeginEnd"] = dicInput["string.strTimeBeginEnd"].ToString();

                return PartialView(QT.SuperWebApp.ConstantValueProject.CVPartialView.PartialView._CardSortMaxToMin.PATH);
            }
            catch (Exception et)
            {
                string str = et.Message;
                return Content("Exception et");
            }
        }

        #endregion

    }
}
