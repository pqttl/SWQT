using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QT.SuperWebApp.Models;
using QT.SuperWebApp.Services;
using SWQT._512ViewModels.Admin.Post;
using System.Data;
using System.Diagnostics;

namespace QT.SuperWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly BLLProject _bllPlugin = new BLLProject();
        private readonly IPostApiClient _iApiClient;
        private readonly string StrKeySessionListPost= nameof(HomeController) + nameof(Index);

        public HomeController(IPostApiClient iApiClient)
        {
            _iApiClient = iApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var mRequest = new VMGetPostPaging()
            {
                IntPageIndex = 0,
                IntPageSize = 9999
            };
            var mApi = await _iApiClient.TApiGetListPaging(mRequest);
            if (mApi == null)
            {
                return View(null);
            }
            if (mApi.BlnIsSuccessed == true)
            {
                _bllPlugin.ChangeColumnNameInDataTable(ref mApi);
            }

            var mResult = mApi.TResultObj;
            if (mResult == null|| mResult.TOneItem.Rows.Count==0)
            {
                return View(null);
            }

            string strJson = JsonConvert.SerializeObject(mResult.TOneItem);
            HttpContext.Session.SetString(StrKeySessionListPost, strJson);

            var lstStringBackground = new List<string>();
            //lstStringBackground.Add("bg-warning");
            //lstStringBackground.Add("bg-success");
            //lstStringBackground.Add("bg-danger");
            //lstStringBackground.Add("bg-info");

            lstStringBackground.Add("border border-primary");
            lstStringBackground.Add("border border-secondary");
            lstStringBackground.Add("border border-success");
            lstStringBackground.Add("border border-danger");
            lstStringBackground.Add("border border-warning");
            lstStringBackground.Add("border border-info");
            lstStringBackground.Add("border border-dark");

            var lstIntRandom = new List<int>();
            GetListIntIndexRandomByCountList(ref lstIntRandom, lstStringBackground.Count);

            var lstStringClassBackgroundRandom = new List<string>();
            for (int i = 0; i < mResult.TOneItem.Rows.Count; i++)
            {
                //if (i % 2 == 0)
                //{
                //    lstStringClassBackgroundRandom.Add("border border-white");
                //    continue;
                //}

                int intIndex = (i / 1) % lstStringBackground.Count;
                lstStringClassBackgroundRandom.Add(lstStringBackground[lstIntRandom[intIndex]]);
            }

            ViewBag.vbLstString = lstStringClassBackgroundRandom;
            return View(mResult);
        }

        private void GetListIntIndexRandomByCountList(ref List<int> lstIntIndexRandom, int intCountList)
        {
            lstIntIndexRandom = new List<int>();

            var rnd = new Random();
            int intIndexRandom = 0;
            for (int i = 0; i < intCountList; i++)
            {
                do
                {
                    intIndexRandom = rnd.Next(0, intCountList);
                    if (lstIntIndexRandom.Contains(intIndexRandom) == false)
                    {
                        lstIntIndexRandom.Add(intIndexRandom);
                        break;
                    }
                } while (lstIntIndexRandom.Contains(intIndexRandom) == true);
            }
        }

        public IActionResult Detail(int intId)
        {
            try
            {
                string strJson = "";
                {
                    var strSession = HttpContext.Session.GetString(StrKeySessionListPost);
                    if (strSession == null)
                    {
                        return View();
                    }
                    strJson = strSession;
                }
                var dtListPost = JsonConvert.DeserializeObject<DataTable>(
                    strJson);
                foreach (DataRow item in dtListPost!.Rows)
                {
                    int intIdCurrent = Convert.ToInt32(item["Id"].ToString());
                    if (intIdCurrent != intId)
                    {
                        continue;
                    }

                    string strTitle = item["Title"].ToString()!;
                    string strHtml = item["Detail"].ToString()!;
                    return View(new string[] { strTitle, strHtml });
                }

                return View();
            }
            catch (Exception et)
            {
                string str = et.Message;
                ViewBag.vbstrError = str;
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}