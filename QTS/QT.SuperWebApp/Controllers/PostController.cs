using Microsoft.AspNetCore.Mvc;
using QT.SuperWebApp.Services;
using SWQT._512ViewModels.Admin.Post;

namespace QT.SuperWebApp.Controllers
{
    public class PostController : BaseController
    {

        private readonly BLLProject _bllPlugin = new BLLProject();
        private const int INT_PAGE_SIZE = 10000;
        private readonly IPostApiClient _iApiClient;

        public PostController(IPostApiClient iApiClient)
        {
            _iApiClient = iApiClient;
        }

        public async Task<IActionResult> Index(int intPageIndex = 0
            , int intPageSize = INT_PAGE_SIZE)
        {
            //Dùng url để truyền giá trị vào biến thì url không cần phân biệt hoa thường
            //pageIndex, pageindex đều được
            var mRequest = new VMGetPostPaging()
            {
                IntPageIndex = intPageIndex,
                IntPageSize = intPageSize
            };
            var mApi = await _iApiClient.TApiGetListPaging(mRequest);
            if (mApi.BlnIsSuccessed==true)
            {
                _bllPlugin.ChangeColumnNameInDataTable(ref mApi); 
            }

            ViewBag.intPageSize = intPageSize;

            return View(mApi.TResultObj);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(VMAddPostRequest mRequest)
        {
            try
            {
                if (ModelState.IsValid==false)
                {
                    ViewBag.vbstrError = string.Join(" \n ", ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));
                    return View(mRequest);
                }
                if (mRequest.StrTitle==null||mRequest.StrTitle.Trim().Length<12)
                {
                    ViewBag.vbstrError = "Tiêu đề phải từ 12 kí tự trở lên!";
                    return View(mRequest);
                }

                mRequest.StrTitle = mRequest.StrTitle.Trim();

                var mApi = await _iApiClient.TApiAdd(mRequest);
                if (mApi.BlnIsSuccessed)
                {
                    ViewBag.vbstrError = "Thao tác thành công!";
                    return View(mRequest);
                }

                ViewBag.vbstrError = ""+ mApi.StrMessage+"\n"+ mApi.StrDetailMessage;
                return View(mRequest);
            }
            catch (Exception et)
            {
                ViewBag.vbstrError = et.Message + "\n" + et.StackTrace;
                return View(mRequest);
            }
        }

    }
}
