using Microsoft.AspNetCore.Mvc;
using SWQT._640DataAccessAhk;

namespace QT.SuperWebApp.Controllers
{
    public class AhkController : Controller
    {
        public IActionResult Index()
        {
            return View((new AllAhk()).LstAhk);
        }

        public IActionResult Detail(int intId)
        {
            var mAhk = (new AllAhk()).LstAhk[intId - 1];
            int intSoDoan = mAhk.LstMultiText.Count;
            if (intSoDoan==0)
            {
                intSoDoan = 1;
            }
            ViewBag.vbstrTitleAhk = mAhk.StrTitle+$" ({intSoDoan} đoạn code)";
            return View(mAhk.LstMultiText);
        }

    }
}
