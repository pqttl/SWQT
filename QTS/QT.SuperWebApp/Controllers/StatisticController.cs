using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QT.SuperWebApp.Services;
using SWQT._768ConstantValue;
using System.Data;

namespace QT.SuperWebApp.Controllers
{
    public class StatisticController : BaseController
    {
        private readonly IStatisticApiClient _iApiClient;
        private readonly BLLProject _bllPlugin = new BLLProject();

        public StatisticController(IStatisticApiClient iApiClient)
        {
            _iApiClient = iApiClient;
        }

        public IActionResult Index()
        {
            string strTemp = nameof(StatisticController);
            string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
            return RedirectToAction(nameof(StatisticController.ByQuantityOrder), strController);
            //return View(nameof(ByQuantity));
        }

        public IActionResult ByQuantity()
        {
            ViewBag.vbstrUrlForAStartStatistic = Url.Action(nameof(JsonResultGetDataForStatisticByTime));

            ViewBag.vbstrUrlForAShowLineChart = Url.Action(nameof(JsonResultShowChartQuantity2Week));
            ViewBag.vbstrUrlForAShowBarChart = Url.Action(nameof(JsonResultShowChartQuantity6Month));
            ViewBag.vbstrUrlForAShowMultiPieChart = Url.Action(nameof(JsonResultShowChartQuantityByCustomer));
            ViewBag.vbstrUrlForAShowPolarAreaChart = Url.Action(nameof(JsonResultShowChartMaxQuantityByCustomer));

            string strTemp = nameof(QT.SuperWebApp.Controllers.BaseController);
            string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
            string strAction = nameof(QT.SuperWebApp.Controllers.BaseController.PartialViewSortMaxToMin);
            string strUrl = Url.Action(strAction, strController) + "?arrayStrInput=1311";
            ViewBag.vbstrUrlForDivSortMaxToMin = strUrl;
            return View();
        }

        #region ByQuantityOrder

        public IActionResult ByQuantityOrder()
        {
            //ViewBag.vbstrUrlForAStartStatistic = Url.Action(nameof(JsonResultGetDataForStatisticByTime));

            //ViewBag.vbstrUrlForAShowLineChart = Url.Action(nameof(JsonResultShowChartQuantity2Week));
            //ViewBag.vbstrUrlForAShowBarChart = Url.Action(nameof(JsonResultShowChartQuantity6Month));
            //ViewBag.vbstrUrlForAShowMultiPieChart = Url.Action(nameof(JsonResultShowChartQuantityByCustomer));
            //ViewBag.vbstrUrlForAShowPolarAreaChart = Url.Action(nameof(JsonResultShowChartMaxQuantityByCustomer));

            string strTemp = nameof(QT.SuperWebApp.Controllers.StatisticController);
            string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
            string strAction = nameof(QT.SuperWebApp.Controllers.StatisticController.PVChooseTime);
            string strUrl = Url.Action(strAction, strController) + "?arrayStrInput=1311";
            ViewBag.vbstrUrlForDivChooseTime = strUrl;
            return View();
        }

        public IActionResult PVChooseTime(string[] arrayStrInput)
        {
            string strNameFunction = nameof(PVChooseTime);
            try
            {
                {
                    string strTemp = nameof(QT.SuperWebApp.Controllers.StatisticController);
                    string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
                    string strAction = nameof(QT.SuperWebApp.Controllers.StatisticController.PVManyChart);
                    string strUrl = Url.Action(strAction, strController) + "?arrayStrInput=1311";
                    ViewBag.vbstrUrlForShow_PVManyChart = strUrl;
                }

                ViewBag.vbstrUrlForAStartStatistic = Url.Action(nameof(JsonResultGetDataForStatisticByTime));

                string strPath = "";
                strPath += ""+nameof(ByQuantityOrder);
                strPath += "/"+ strNameFunction;
                return PartialView(strPath);
            }
            catch (Exception et)
            {
                string str = et.Message;
                return Content($"<div>{str}</div>");
            }
        }
        
        public IActionResult PVManyChart(string[] arrayStrInput)
        {
            string strNameFunction = nameof(PVManyChart);
            try
            {
                {
                    string strTemp = nameof(QT.SuperWebApp.Controllers.StatisticController);
                    string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
                    string strAction = nameof(QT.SuperWebApp.Controllers.StatisticController.PVOneChart);
                    string strUrl = Url.Action(strAction, strController) + "?arrayStrInput=";
                    ViewBag.vbstrUrlForShow_PVOneChart_Line = strUrl+"Line";
                    ViewBag.vbstrUrlForShow_PVOneChart_Bar = strUrl+ "Bar";
                    ViewBag.vbstrUrlForShow_PVOneChart_MultiPie = strUrl+ "MultiPie";
                    ViewBag.vbstrUrlForShow_PVOneChart_PolarArea = strUrl+ "PolarArea";
                }

                ViewBag.vbstrUrlForAShowLineChart = Url.Action(nameof(JsonResultShowChartQuantity2Week));
                ViewBag.vbstrUrlForAShowBarChart = Url.Action(nameof(JsonResultShowChartQuantity6Month));
                ViewBag.vbstrUrlForAShowMultiPieChart = Url.Action(nameof(JsonResultShowChartQuantityByCustomer));
                ViewBag.vbstrUrlForAShowPolarAreaChart = Url.Action(nameof(JsonResultShowChartMaxQuantityByCustomer));

                {
                    string strTemp = nameof(QT.SuperWebApp.Controllers.BaseController);
                    string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
                    string strAction = nameof(QT.SuperWebApp.Controllers.BaseController.PartialViewSortMaxToMin);
                    string strUrl = Url.Action(strAction, strController) + "?arrayStrInput=1311";
                    ViewBag.vbstrUrlForDivSortMaxToMin = strUrl;
                }

                string strPath = "";
                strPath += ""+nameof(ByQuantityOrder);
                strPath += "/"+ strNameFunction;
                return PartialView(strPath);
            }
            catch (Exception et)
            {
                string str = et.Message;
                return Content($"<div>{str}</div>");
            }
        }
        
        public IActionResult PVOneChart(string[] arrayStrInput)
        {
            string strNameFunction = nameof(PVOneChart);
            try
            {
                ViewBag.vbstrNameChart = arrayStrInput[0];

                string strPath = "";
                strPath += ""+nameof(ByQuantityOrder);
                strPath += "/"+ strNameFunction;
                return PartialView(strPath);
            }
            catch (Exception et)
            {
                string str = et.Message;
                return Content($"<div>{str}</div>");
            }
        }

        #endregion

        #region JsonResult ajax

        public async Task<IActionResult> JsonResultGetDataForStatisticByTime(string[] arrayStrInput)
        {
            string strNameFunction = nameof(JsonResultGetDataForStatisticByTime);
            try
            {
                {
                    var dicInput = new Dictionary<string, object>();

                    {
                        int intIndexIncrease = -1;
                        dicInput["strStartDate"] = arrayStrInput[++intIndexIncrease];
                        dicInput["strEndDate"] = arrayStrInput[++intIndexIncrease];
                        dicInput["intPageIndex"] = 0;
                        dicInput["intPageSize"] = 99999;
                    }
                    //if (dicInput!=null)
                    //{
                    //    return Json(new
                    //    {
                    //        blnStatusJs = false,
                    //        strMess = "fghgfhgfhgfhg"
                    //    });
                    //}

                    var mApi = await _iApiClient.TApiGetStatisticOrderByDictionary(dicInput);

                    if (mApi.BlnIsSuccessed == false)
                    {
                        return Json(new
                        {
                            blnStatusJs = false,
                            strMess = mApi.StrMessage
                        });
                    }

                    string strJson = JsonConvert.SerializeObject(mApi.DicResult);
                    HttpContext.Session.SetString(strNameFunction, strJson);

                    DateTime dtimeEnd = DateTime.ParseExact(dicInput["strEndDate"].ToString()!
        , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);
                    DateTime dtimeStart = dtimeEnd;
                    int intSoLanT2 = 0;
                    for (int i = 0; i < 365; i++)
                    {
                        if (dtimeEnd.AddDays(-i).DayOfWeek == DayOfWeek.Monday)
                        {
                            intSoLanT2++;
                        }
                        if (intSoLanT2 > 1)
                        {
                            dtimeStart = dtimeEnd.AddDays(-i);
                            break;
                        }
                    }
                    string strTimeStart2Week = dtimeStart.ToString(QTFormat.STR_DATE_DD_MM_YYYY.STR);
                    string strTimeEnd2Week = dtimeEnd.ToString(QTFormat.STR_DATE_DD_MM_YYYY.STR);

                    string strTimeStart6Month = "";
                    string strTimeEnd6Month = "";
                    {
                        int intIndexIncrease = -1;
                        strTimeStart6Month = arrayStrInput[++intIndexIncrease];
                        strTimeEnd6Month = arrayStrInput[++intIndexIncrease];
                    }

                    return Json(new
                    {
                        blnStatusJs = true,
                        strMess = "suceess",

                        strTimeStart6Month = strTimeStart6Month,
                        strTimeEnd6Month = strTimeEnd6Month,

                        strTimeStart2Week = strTimeStart2Week,
                        strTimeEnd2Week = strTimeEnd2Week,

                        strNameVoid = strNameFunction
                    });

                }
            }
            catch (Exception et)
            {
                return Json(new
                {
                    blnStatusJs = false,
                    strMess = et.Message + "\n" + et.StackTrace,
                    //strIdFocus = nameof(strSpanKg)
                });
            }
        }

        public IActionResult JsonResultShowChartQuantity2Week(string[] arrayStrInput)
        {
            string strNameFunction = nameof(JsonResultShowChartQuantity2Week);
            try
            {
                {
                    string strJson = "";
                    {
                        var strSession = HttpContext.Session.GetString(nameof(JsonResultGetDataForStatisticByTime));
                        if (strSession == null)
                        {
                            return Json(new
                            {
                                blnStatusJs = false,
                                strNameVoid = strNameFunction,
                                strMess = "Bạn vui lòng tải lại trang để thực hiện thao tác này!"
                            });
                        }
                        strJson = strSession;
                    }
                    var dicInput = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        strJson);

                    DataTable DT_AllIdOrder = JsonConvert.DeserializeObject<DataTable>(
                        dicInput!["DT_AllIdOrder"].ToString()!)!;
                    DataTable DT_AllDetailOrderByListIdOrder = JsonConvert.DeserializeObject<DataTable>(
                        dicInput["DT_AllDetailOrderByListIdOrder"].ToString()!)!;
                    _bllPlugin.ChangeColumnNameInDataTable(ref DT_AllIdOrder);

                    var lstTupleTimeLongShortQuantityAllSangChieuOrder =
                        new List<Tuple<string, string, int, int, int, DateTime>>();
                    _bllPlugin.GetListTupleTimeQuantityOrderFromDatatable(
                        ref lstTupleTimeLongShortQuantityAllSangChieuOrder
                        , arrayStrInput, DT_AllIdOrder);

                    int intSoLanT2 = 0;
                    var lstTupleOutput = new List<Tuple<string, string, int, int, int, DateTime>>();
                    for (int i = lstTupleTimeLongShortQuantityAllSangChieuOrder.Count - 1; i >= 0; i--)
                    {
                        var item = lstTupleTimeLongShortQuantityAllSangChieuOrder[i];

                        //lstTupleOutput.Add(item);
                        string strThuMay = "T" + (((int)item.Item6.DayOfWeek) + 1);
                        if (strThuMay == "T1")
                        {
                            strThuMay = "CN";
                        }
                        lstTupleOutput.Add(new Tuple<string, string, int, int, int, DateTime>(
                            "", strThuMay + " " + item.Item2
                            , item.Item3, item.Item4, item.Item5, new DateTime()));

                        if (item.Item6.DayOfWeek == DayOfWeek.Monday)
                        {
                            intSoLanT2++;
                        }
                        if (intSoLanT2 > 1)
                        {
                            break;
                        }
                    }
                    lstTupleOutput.Reverse();

                    string strListName = "";
                    string strListQuantityAll = "";
                    string strListQuantitySang = "";
                    string strListQuantityChieu = "";
                    foreach (var item in lstTupleOutput)
                    {
                        if (strListQuantityAll == "")
                        {
                            strListName += $"\"{item.Item2}\"";
                            strListQuantityAll += $"{item.Item3}";
                            strListQuantitySang += $"{item.Item4}";
                            strListQuantityChieu += $"{item.Item5}";
                            continue;
                        }

                        strListName += $",\"{item.Item2}\"";
                        strListQuantityAll += $",{item.Item3}";
                        strListQuantitySang += $",{item.Item4}";
                        strListQuantityChieu += $",{item.Item5}";

                    }

                    return Json(new
                    {
                        blnStatusJs = true,
                        strMess = "suceess",
                        strNameVoid = strNameFunction,
                        strArrayNameJs = $"[{strListName}]",
                        strArrayQuantityJs = $"[{strListQuantityAll}]",
                        strArrayQuantitySangJs = $"[{strListQuantitySang}]",
                        strArrayQuantityChieuJs = $"[{strListQuantityChieu}]"
                    });
                }
            }
            catch (Exception et)
            {
                return Json(new
                {
                    blnStatusJs = false,
                    strNameVoid = strNameFunction,
                    strMess = et.Message + "\n" + et.StackTrace
                });
            }
        }

        public IActionResult JsonResultShowChartQuantity6Month(string[] arrayStrInput)
        {
            string strNameFunction = nameof(JsonResultShowChartQuantity6Month);
            try
            {
                {
                    string strJson = "";
                    {
                        var strSession = HttpContext.Session.GetString(nameof(JsonResultGetDataForStatisticByTime));
                        if (strSession == null)
                        {
                            return Json(new
                            {
                                blnStatusJs = false,
                                strNameVoid = strNameFunction,
                                strMess = "Bạn vui lòng tải lại trang để thực hiện thao tác này!"
                            });
                        }
                        strJson = strSession;
                    }
                    var dicInput = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        strJson);

                    DataTable DT_AllIdOrder = JsonConvert.DeserializeObject<DataTable>(
                        dicInput!["DT_AllIdOrder"].ToString()!)!;
                    DataTable DT_AllDetailOrderByListIdOrder = JsonConvert.DeserializeObject<DataTable>(
                        dicInput["DT_AllDetailOrderByListIdOrder"].ToString()!)!;
                    _bllPlugin.ChangeColumnNameInDataTable(ref DT_AllIdOrder);

                    var lstTupleTimeLongShortQuantityAllSangChieuOrder =
                        new List<Tuple<string, string, int, int, int, DateTime>>();
                    _bllPlugin.GetListTupleTimeQuantityOrderFromDatatable(
                        ref lstTupleTimeLongShortQuantityAllSangChieuOrder
                        , arrayStrInput, DT_AllIdOrder);

                    var lstStrThang = new List<string>();
                    foreach (var item in lstTupleTimeLongShortQuantityAllSangChieuOrder)
                    {
                        string strThang = $"Tháng {item.Item6.ToString("MM")}";
                        if (lstStrThang.Count == 0)
                        {
                            lstStrThang.Add(strThang);
                            continue;
                        }

                        if (lstStrThang[lstStrThang.Count - 1] == strThang)
                        {
                            continue;
                        }

                        lstStrThang.Add(strThang);

                    }

                    var lstTupleOutput = new List<Tuple<string, string, int, int, int, DateTime>>();
                    foreach (var item in lstTupleTimeLongShortQuantityAllSangChieuOrder)
                    {
                        string strThang = $"Tháng {item.Item6.ToString("MM")}";

                    }

                    int intIndexStart = 0;
                    foreach (var strThangInList in lstStrThang)
                    {
                        int intAll = 0;
                        int intSang = 0;
                        int intChieu = 0;
                        for (int i = intIndexStart; i < lstTupleTimeLongShortQuantityAllSangChieuOrder.Count; i++)
                        {
                            var item = lstTupleTimeLongShortQuantityAllSangChieuOrder[i];
                            string strThang = $"Tháng {item.Item6.ToString("MM")}";
                            if (strThang != strThangInList)
                            {
                                intIndexStart = i;
                                break;
                            }

                            intAll += item.Item3;
                            intSang += item.Item4;
                            intChieu += item.Item5;
                        }

                        lstTupleOutput.Add(new Tuple<string, string, int, int, int, DateTime>(
                            "", strThangInList
                            , intAll, intSang, intChieu, new DateTime()));
                    }

                    string strListName = "";
                    string strListQuantityAll = "";
                    string strListQuantitySang = "";
                    string strListQuantityChieu = "";
                    foreach (var item in lstTupleOutput)
                    {
                        if (strListQuantityAll == "")
                        {
                            strListName += $"\"{item.Item2}\"";
                            strListQuantityAll += $"{item.Item3}";
                            strListQuantitySang += $"{item.Item4}";
                            strListQuantityChieu += $"{item.Item5}";
                            continue;
                        }

                        strListName += $",\"{item.Item2}\"";
                        strListQuantityAll += $",{item.Item3}";
                        strListQuantitySang += $",{item.Item4}";
                        strListQuantityChieu += $",{item.Item5}";

                    }

                    return Json(new
                    {
                        blnStatusJs = true,
                        strMess = "suceess",
                        strNameVoid = strNameFunction,
                        strArrayNameJs = $"[{strListName}]",
                        strArrayQuantityJs = $"[{strListQuantityAll}]",
                        strArrayQuantitySangJs = $"[{strListQuantitySang}]",
                        strArrayQuantityChieuJs = $"[{strListQuantityChieu}]"
                    });
                }
            }
            catch (Exception et)
            {
                return Json(new
                {
                    blnStatusJs = false,
                    strNameVoid = strNameFunction,
                    strMess = et.Message + "\n" + et.StackTrace
                });
            }
        }

        public IActionResult JsonResultShowChartQuantityByCustomer(string[] arrayStrInput)
        {
            string strNameFunction = nameof(JsonResultShowChartQuantityByCustomer);
            try
            {
                {
                    string strJson = "";
                    {
                        var strSession = HttpContext.Session.GetString(nameof(JsonResultGetDataForStatisticByTime));
                        if (strSession == null)
                        {
                            return Json(new
                            {
                                blnStatusJs = false,
                                strNameVoid = strNameFunction,
                                strMess = "Bạn vui lòng tải lại trang để thực hiện thao tác này!"
                            });
                        }
                        strJson = strSession;
                    }
                    var dicInput = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        strJson);

                    DataTable DT_AllIdOrder = JsonConvert.DeserializeObject<DataTable>(
                        dicInput!["DT_AllIdOrder"].ToString()!)!;
                    DataTable DT_AllDetailOrderByListIdOrder = JsonConvert.DeserializeObject<DataTable>(
                        dicInput["DT_AllDetailOrderByListIdOrder"].ToString()!)!;
                    _bllPlugin.ChangeColumnNameInDataTable(ref DT_AllIdOrder);

                    var lstTupleIdNameQuantity = new List<Tuple<string, string, int>>();
                    _bllPlugin.GetListTupleIdNameQuantityFromDatatable(
                        ref lstTupleIdNameQuantity
                        , arrayStrInput, DT_AllIdOrder);



                    var lstTupleMinToMax = new List<Tuple<string, string, int>>();
                    lstTupleMinToMax = lstTupleIdNameQuantity.OrderBy(x => x.Item3).ToList();

                    int intQuantityCurrent = -1311;
                    var lstListTupleGop = new List<List<Tuple<string, string, int>>>();
                    foreach (var item in lstTupleMinToMax)
                    {
                        if (lstListTupleGop.Count == 0 || item.Item3 > intQuantityCurrent)
                        {
                            intQuantityCurrent = item.Item3;
                            lstListTupleGop.Add(new List<Tuple<string, string, int>>() { item });
                            continue;
                        }

                        lstListTupleGop[lstListTupleGop.Count - 1].Add(item);
                    }

                    var lstTupleMinToMaxSauKhiGop = new List<Tuple<string, string, int>>();
                    var lstTupleMinToMaxTheoLoaiQuantity = new List<Tuple<string, string, int>>();
                    foreach (var lstTupleCungSoLuong in lstListTupleGop)
                    {
                        if (lstTupleCungSoLuong.Count == 1)
                        {
                            lstTupleMinToMaxSauKhiGop.Add(lstTupleCungSoLuong[0]);
                            lstTupleMinToMaxTheoLoaiQuantity.Add(lstTupleCungSoLuong[0]);
                            continue;
                        }

                        string strName = "";
                        var lstTemp = lstTupleCungSoLuong;
                        foreach (var item in lstTemp)
                        {
                            strName += "" + item.Item2 + "  ";
                        }
                        strName = $"Có {lstTupleCungSoLuong.Count} KH đều có {lstTupleCungSoLuong[0].Item3} đơn hàng";
                        lstTupleMinToMaxSauKhiGop.Add(new Tuple<string, string, int>(
                            "", strName, lstTupleCungSoLuong.Count * lstTupleCungSoLuong[0].Item3));
                        lstTupleMinToMaxTheoLoaiQuantity.Add(new Tuple<string, string, int>(
                            "", strName, lstTupleCungSoLuong[0].Item3));
                    }






                    var lstStrColor = new List<string>() {
                        "#0074D9", "#FF4136", "#2ECC40", "#FF851B", "#7FDBFF", "#B10DC9"
                        , "#FFDC00", "#001f3f", "#39CCCC", "#01FF70", "#85144b", "#F012BE"
                        , "#3D9970", "#111111", "#AAAAAA"
                    };

                    var rnd = new Random();
                    var lstStrColorTemp = new List<string>(lstStrColor);

                    var lstTupleOutput = new List<Tuple<string, string, int, string>>();
                    var lstTupleOutputCenter = new List<Tuple<string, string, int, string>>();
                    for (int i = 0; i < lstTupleMinToMaxSauKhiGop.Count; i++)
                    {
                        if (lstStrColorTemp.Count == 0)
                        {
                            lstStrColorTemp = new List<string>(lstStrColor);
                        }
                        int intIndexRandom = rnd.Next(lstStrColorTemp.Count);
                        string strColorRandom = lstStrColorTemp[intIndexRandom];
                        lstStrColorTemp.RemoveAt(intIndexRandom);

                        {
                            var item = lstTupleMinToMaxSauKhiGop[i];
                            lstTupleOutput.Add(new Tuple<string, string, int, string>(
                                item.Item1, item.Item2, item.Item3, strColorRandom));
                        }

                        {
                            var item = lstTupleMinToMaxTheoLoaiQuantity[i];
                            lstTupleOutputCenter.Add(new Tuple<string, string, int, string>(
                                item.Item1, item.Item2, item.Item3, strColorRandom));
                        }

                    }

                    lstTupleOutput = lstTupleOutput.OrderBy(x => x.Item3).ToList();

                    string strListName = "";
                    string strListQuantityAll = "";
                    string strListColor = "";
                    _bllPlugin.GetStringListFromListTupleByCustomer(ref strListName
                        , ref strListQuantityAll, ref strListColor
                        , lstTupleOutput);

                    string strListNameCenter = "";
                    string strListQuantityCenter = "";
                    string strListColorCenter = "";
                    _bllPlugin.GetStringListFromListTupleByCustomer(ref strListNameCenter
                        , ref strListQuantityCenter, ref strListColorCenter
                        , lstTupleOutputCenter);

                    var lstStrNoteColorSpan = new List<string>();
                    foreach (var item in lstTupleOutput)
                    {
                        string strName = item.Item2;
                        string strColor = item.Item4;
                        lstStrNoteColorSpan.Add($" <span style=\"      font-size: 12px;      font-family: Arial, Helvetica, sans-serif; display: inline-flex;align-items: center;     \">  <span class=\"mx-2\" style=\"      background-color: {strColor};      color: rgba(0, 0, 0, 0);      font-size: 7px;      \">123456789</span>   <span style=\"      color: dimgray;      \">{strName}</span> </span> ");
                    }

                    string strTemp = "";
                    foreach (var item in lstStrNoteColorSpan)
                    {
                        strTemp += item;
                    }

                    string strIdDivNoteColor = "idDivNoteColor" + "_" + strNameFunction;
                    strIdDivNoteColor = "idDivNoteColor";
                    string strNoteColor = $"<div class=\"d-flex justify-content-center flex-wrap\" id=\"{strIdDivNoteColor}\">   {strTemp}</div>";

                    return Json(new
                    {
                        blnStatusJs = true,
                        strMess = "suceess",
                        strNameVoid = strNameFunction,
                        strNoteColor = $"{strNoteColor}",

                        strArrayNameCenterJs = $"[{strListNameCenter}]",
                        strArrayNameJs = $"[{strListName}]",
                        strArrayColorCenterJs = $"[{strListColorCenter}]",
                        strArrayColorJs = $"[{strListColor}]",
                        strArrayQuantityCenterJs = $"[{strListQuantityCenter}]",
                        strArrayQuantityJs = $"[{strListQuantityAll}]"
                    });
                }
            }
            catch (Exception et)
            {
                return Json(new
                {
                    blnStatusJs = false,
                    strNameVoid = strNameFunction,
                    strMess = et.Message + "\n" + et.StackTrace
                });
            }
        }

        public IActionResult JsonResultShowChartMaxQuantityByCustomer(string[] arrayStrInput)
        {
            string strNameFunction = nameof(JsonResultShowChartMaxQuantityByCustomer);
            try
            {
                {
                    string strJson = "";
                    {
                        var strSession = HttpContext.Session.GetString(nameof(JsonResultGetDataForStatisticByTime));
                        if (strSession == null)
                        {
                            return Json(new
                            {
                                blnStatusJs = false,
                                strNameVoid = strNameFunction,
                                strMess = "Bạn vui lòng tải lại trang để thực hiện thao tác này!"
                            });
                        }
                        strJson = strSession;
                    }
                    var dicInput = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        strJson);

                    DataTable DT_AllIdOrder = JsonConvert.DeserializeObject<DataTable>(
                        dicInput!["DT_AllIdOrder"].ToString()!)!;
                    DataTable DT_AllDetailOrderByListIdOrder = JsonConvert.DeserializeObject<DataTable>(
                        dicInput["DT_AllDetailOrderByListIdOrder"].ToString()!)!;
                    _bllPlugin.ChangeColumnNameInDataTable(ref DT_AllIdOrder);

                    var lstTupleIdNameQuantity = new List<Tuple<string, string, int>>();
                    _bllPlugin.GetListTupleIdNameQuantityFromDatatable(
                        ref lstTupleIdNameQuantity
                        , arrayStrInput, DT_AllIdOrder);



                    var lstTupleMinToMax = new List<Tuple<string, string, int>>();
                    lstTupleMinToMax = lstTupleIdNameQuantity.OrderBy(x => x.Item3).ToList();

                    int intQuantityCurrent = -1311;
                    var lstListTupleGop = new List<List<Tuple<string, string, int>>>();
                    foreach (var item in lstTupleMinToMax)
                    {
                        if (lstListTupleGop.Count == 0 || item.Item3 > intQuantityCurrent)
                        {
                            intQuantityCurrent = item.Item3;
                            lstListTupleGop.Add(new List<Tuple<string, string, int>>() { item });
                            continue;
                        }

                        lstListTupleGop[lstListTupleGop.Count - 1].Add(item);
                    }

                    var lstTupleMinToMaxSauKhiGop = new List<Tuple<string, string, int>>();
                    var lstTupleMinToMaxTheoLoaiQuantity = new List<Tuple<string, string, int>>();
                    foreach (var lstTupleCungSoLuong in lstListTupleGop)
                    {
                        if (lstTupleCungSoLuong.Count == 1)
                        {
                            lstTupleMinToMaxSauKhiGop.Add(lstTupleCungSoLuong[0]);
                            lstTupleMinToMaxTheoLoaiQuantity.Add(lstTupleCungSoLuong[0]);
                            continue;
                        }

                        string strName = "";
                        var lstTemp = lstTupleCungSoLuong;
                        foreach (var item in lstTemp)
                        {
                            strName += "" + item.Item2 + "  ";
                        }
                        strName = $"Có {lstTupleCungSoLuong.Count} KH đều có {lstTupleCungSoLuong[0].Item3} đơn hàng";
                        lstTupleMinToMaxSauKhiGop.Add(new Tuple<string, string, int>(
                            "", strName, lstTupleCungSoLuong.Count * lstTupleCungSoLuong[0].Item3));
                        lstTupleMinToMaxTheoLoaiQuantity.Add(new Tuple<string, string, int>(
                            "", strName, lstTupleCungSoLuong[0].Item3));
                    }






                    var lstStrColor = new List<string>() {
                        "#0074D9", "#FF4136", "#2ECC40", "#FF851B", "#7FDBFF", "#B10DC9"
                        , "#FFDC00", "#001f3f", "#39CCCC", "#01FF70", "#85144b", "#F012BE"
                        , "#3D9970", "#111111", "#AAAAAA"
                    };

                    var rnd = new Random();
                    var lstStrColorTemp = new List<string>(lstStrColor);

                    var lstTupleOutput = new List<Tuple<string, string, int, string>>();
                    var lstTupleOutputCenter = new List<Tuple<string, string, int, string>>();
                    for (int i = 0; i < lstTupleMinToMaxSauKhiGop.Count; i++)
                    {
                        if (lstStrColorTemp.Count == 0)
                        {
                            lstStrColorTemp = new List<string>(lstStrColor);
                        }
                        int intIndexRandom = rnd.Next(lstStrColorTemp.Count);
                        string strColorRandom = lstStrColorTemp[intIndexRandom];
                        lstStrColorTemp.RemoveAt(intIndexRandom);

                        {
                            var item = lstTupleMinToMaxSauKhiGop[i];
                            lstTupleOutput.Add(new Tuple<string, string, int, string>(
                                item.Item1, item.Item2, item.Item3, strColorRandom));
                        }

                        {
                            var item = lstTupleMinToMaxTheoLoaiQuantity[i];
                            lstTupleOutputCenter.Add(new Tuple<string, string, int, string>(
                                item.Item1, item.Item2, item.Item3, strColorRandom));
                        }

                    }

                    {
                        var lstTupleTemp = new List<Tuple<string, string>>();
                        for (int i = lstTupleOutputCenter.Count - 1; i >= 0; i--)
                        {
                            var item = lstTupleOutputCenter[i];
                            lstTupleTemp.Add(new Tuple<string, string>(item.Item2, "" + item.Item3));
                        }

                        var dicTemp = new Dictionary<string, object>();
                        dicTemp["List<Tuple<string,string>>"] = lstTupleTemp;

                        string strTimeBeginEnd = "...";
                        if (arrayStrInput.Length > 1)
                        {
                            strTimeBeginEnd = $"{arrayStrInput[0]} - {arrayStrInput[1]}";
                        }
                        dicTemp["string.strTimeBeginEnd"] = strTimeBeginEnd;

                        string strJsonTemp = JsonConvert.SerializeObject(dicTemp);
                        HttpContext.Session.SetString(nameof(PartialViewSortMaxToMin), strJsonTemp);
                    }

                    lstTupleOutput = lstTupleOutput.OrderBy(x => x.Item3).ToList();
                    if (lstTupleOutputCenter.Count > 2)
                    {
                        var tupleTemp = lstTupleOutputCenter[0];
                        lstTupleOutputCenter.RemoveAt(0);
                        lstTupleOutputCenter.Add(tupleTemp);
                    }

                    string strListName = "";
                    string strListQuantityAll = "";
                    string strListColor = "";
                    _bllPlugin.GetStringListFromListTupleByCustomer(ref strListName
                        , ref strListQuantityAll, ref strListColor
                        , lstTupleOutput);

                    string strListNameCenter = "";
                    string strListQuantityCenter = "";
                    string strListColorCenter = "";
                    _bllPlugin.GetStringListFromListTupleByCustomer(ref strListNameCenter
                        , ref strListQuantityCenter, ref strListColorCenter
                        , lstTupleOutputCenter);

                    var lstStrNoteColorSpan = new List<string>();
                    foreach (var item in lstTupleOutput)
                    {
                        string strName = item.Item2;
                        string strColor = item.Item4;
                        lstStrNoteColorSpan.Add($" <span style=\"      font-size: 12px;      font-family: Arial, Helvetica, sans-serif; display: inline-flex;align-items: center;     \">  <span class=\"mx-2\" style=\"      background-color: {strColor};      color: rgba(0, 0, 0, 0);      font-size: 7px;      \">123456789</span>   <span style=\"      color: dimgray;      \">{strName}</span> </span> ");
                    }

                    string strTemp = "";
                    foreach (var item in lstStrNoteColorSpan)
                    {
                        strTemp += item;
                    }

                    string strIdDivNoteColor = "idDiv2NoteColor" + "_" + strNameFunction;
                    strIdDivNoteColor = "idDiv2NoteColor" ;
                    string strNoteColor = $"<div class=\"d-flex justify-content-center flex-wrap\" id=\"{strIdDivNoteColor}\">   {strTemp}</div>";

                    return Json(new
                    {
                        blnStatusJs = true,
                        strMess = "suceess",
                        strNameVoid = strNameFunction,
                        strNoteColor = $"{strNoteColor}",

                        strArrayNameCenterJs = $"[{strListNameCenter}]",
                        strArrayNameJs = $"[{strListName}]",
                        strArrayColorCenterJs = $"[{strListColorCenter}]",
                        strArrayColorJs = $"[{strListColor}]",
                        strArrayQuantityCenterJs = $"[{strListQuantityCenter}]",
                        strArrayQuantityJs = $"[{strListQuantityAll}]"
                    });
                }
            }
            catch (Exception et)
            {
                return Json(new
                {
                    blnStatusJs = false,
                    strNameVoid = strNameFunction,
                    strMess = et.Message + "\n" + et.StackTrace
                });
            }
        }

        #endregion
    }
}
