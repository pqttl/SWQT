using Microsoft.AspNetCore.Mvc;
using QT.SuperWebApp.Services;
using SWQT._512ViewModels.Admin.Post;
using SWQT._576Entity.Entities;

namespace QT.SuperWebApp.Controllers
{
    public class PostController : BaseController
    {

        private readonly BLLProject _bllPlugin = new BLLProject();
        private const int INT_PAGE_SIZE = 10;
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
            var mApi = await _iApiClient.TApiGetListPagingNewest(mRequest);

            ViewBag.intPageSize = intPageSize;
            ViewBag.vb_strUrlDelete = Url.Action(nameof(JsonResultDeleteById));

            return View(mApi.TResultObj);
        }
        
        public async Task<IActionResult> IndexOld(int intPageIndex = 0
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

        #region View add

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
                if (ModelState.IsValid == false)
                {
                    ViewBag.vbstrError = string.Join(" \n ", ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));
                    return View(mRequest);
                }
                if (mRequest.StrTitle == null || mRequest.StrTitle.Trim().Length < 12)
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

                ViewBag.vbstrError = "" + mApi.StrMessage + "\n" + mApi.StrDetailMessage;
                return View(mRequest);
            }
            catch (Exception et)
            {
                ViewBag.vbstrError = et.Message + "\n" + et.StackTrace;
                return View(mRequest);
            }
        }

        #endregion

        #region View update

        [HttpGet]
        public async Task<IActionResult> Update(int intId)
        {
            var mApi = await _iApiClient.TApiGetListDetailByListId(new List<int> { intId });
            return View(mApi.TResultObj[0]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TblListPost mRequest)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    ViewBag.vbstrError = string.Join(" \n ", ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));
                    return View(mRequest);
                }
                if (mRequest.Title == null || mRequest.Title.Trim().Length < 12)
                {
                    ViewBag.vbstrError = "Tiêu đề phải từ 12 kí tự trở lên!";
                    return View(mRequest);
                }

                mRequest.Title = mRequest.Title.Trim();

                var mApi = await _iApiClient.TApiUpdateList(new List<TblListPost>() { mRequest });
                if (mApi.BlnIsSuccessed)
                {
                    ViewBag.vbstrError = "Thao tác thành công!";
                    return View(mRequest);
                }

                ViewBag.vbstrError = "" + mApi.StrMessage + "\n" + mApi.StrDetailMessage;
                return View(mRequest);
            }
            catch (Exception et)
            {
                ViewBag.vbstrError = et.Message + "\n" + et.StackTrace;
                return View(mRequest);
            }
        }

        #endregion

        #region JsonResult ajax

        public async Task<IActionResult> JsonResultDeleteById(string[] arrayStrInput)
        {
            try
            {
                {
                    int intId = Convert.ToInt32(arrayStrInput[0]);

                    var mApi = await _iApiClient.TApiDeleteByListId(new List<int> { intId });

                    if (mApi.BlnIsSuccessed == false)
                    {
                        return Json(new
                        {
                            blnStatusJs = false,
                            strMess = mApi.StrMessage
                        });
                    }

                    return Json(new
                    {
                        blnStatusJs = true,
                        strMess = "Thao tác thành công! Trang sẽ được tải lại sau 2 giây!",
                    });

                }
            }
            catch (Exception et)
            {
                return Json(new
                {
                    blnStatusJs = false,
                    strMess = et.Message + "\n" + et.StackTrace,
                });
            }
        }

        #endregion
    }
}
