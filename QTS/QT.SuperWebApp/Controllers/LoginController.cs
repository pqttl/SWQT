using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using QT.SuperWebApp.Services;
using SWQT._512ViewModels.Admin.Login;
using SWQT._768ConstantValue;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QT.SuperWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginApiClient _loginApiClient;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginApiClient loginApiClient, IConfiguration configuration)
        {
            _loginApiClient = loginApiClient;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        //public async Task<IActionResult> TestFrontEnd()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Index(VMLoginRequest mRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(mRequest);
                }
                if (mRequest.StrUserName == null || mRequest.StrPassword == null)
                {
                    ModelState.AddModelError("", "Tên đăng nhập và mật khẩu phải từ 7 kí tự trở lên!");
                    return View(mRequest);
                }

                mRequest.StrUserName = mRequest.StrUserName!.ToLower();
                var strJsonDictionary = await _loginApiClient.TStrJsonAuthenticate(mRequest);

                string strError = "";
                string strToken = "";
                CheckJsonLogin(ref strToken, ref strError, strJsonDictionary);
                if (strError != "")
                {
                    ModelState.AddModelError("", strError);
                    return View(mRequest);
                }

                var userPrincipal = ClaimsPrincipalValidateToken(strToken);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    IsPersistent = false
                };
                HttpContext.Session.SetString(QTConstants.AppSettings.Token.STR, strToken);
                await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            userPrincipal,
                            authProperties);

                //string strTemp = nameof(HomeController);
                //string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
                //return RedirectToAction(nameof(HomeController.Index), strController);
                
                //string strTemp = nameof(AhkController);
                //string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
                //return RedirectToAction(nameof(AhkController.Index), strController);
                
                string strTemp = nameof(StatisticController);
                string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
                return RedirectToAction(nameof(StatisticController.ByQuantity), strController);

                //string strId = "1";
                //string strTemp = nameof(AhkController);
                //string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
                //return RedirectToAction(nameof(AhkController.Detail), strController, new { intId = strId });
            }
            catch (Exception et)
            {
                ModelState.AddModelError("", et.Message+"\n"+et.StackTrace);
                return View(mRequest);
            }
        }

        private void CheckJsonLogin(ref string strToken, ref string strError, string strJsonDictionary)
        {
            var dicInput = new Dictionary<string, object>();
            try
            {
                dicInput = JsonConvert.DeserializeObject<Dictionary<string, object>>(strJsonDictionary);
                string strKey = "Exception";
                if (dicInput!.ContainsKey(strKey))
                {
                    Exception ep = JsonConvert.DeserializeObject<Exception>(
                        dicInput[strKey].ToString()!)!;
                    strError += "\n" + ep.Message;
                    strError += "\n" + ep.StackTrace;
                    return;
                }

                DataTable dtOutput = JsonConvert.DeserializeObject<DataTable>(dicInput["DataTable"].ToString()!)!;

                var mes = "";
                var status = "notadminadmin";
                if (dtOutput == null)
                {
                    status = "dtOutputNull";
                }
                if (dtOutput != null)
                {
                    if (dtOutput.Rows.Count == 0)
                    {
                        status = "dangnhapsai";
                    }
                }

                string strPhienBanHanCuoi = "";
                if (dtOutput != null)
                {
                    int intSumRow = dtOutput.Rows.Count;
                    if (intSumRow > 0)
                    {
                        string strIdAccount = "" + dtOutput.Rows[intSumRow - 1]["Id"].ToString();
                        //TupleIdNameAccount = new Tuple<string, string>(strIdAccount, strUser);

                        try
                        {
                            string strFormat = "HH:mm:ss dd/MM/yyyy";
                            //DateTime dtStart = (DateTime)dtOutput.Rows[intSumRow - 1]["StartTimeUse"];
                            //DateTime dtEnd = (DateTime)dtOutput.Rows[intSumRow - 1]["EndTimeUse"];
                            DateTime dtStart = DateTime.ParseExact(dtOutput.Rows[intSumRow - 1]["StartTimeUse"].ToString()!
            , strFormat, null);
                            DateTime dtEnd = DateTime.ParseExact(dtOutput.Rows[intSumRow - 1]["EndTimeUse"].ToString()!
            , strFormat, null);

                            strPhienBanHanCuoi = $"(Bạn đang sử dụng phiên bản {dtEnd.ToString(strFormat)})";
                            TimeSpan tsStart = DateTime.Now.Subtract(dtStart);
                            TimeSpan tsEnd = DateTime.Now.Subtract(dtEnd);
                            if (DateTime.Now < dtStart || DateTime.Now > dtEnd)
                            {
                                status = "HetHan";
                            }
                            else
                            {
                                status = "ok";
                            }
                        }
                        catch (Exception etemp)
                        {
                            string str = etemp.Message;
                            status = "HetHan";
                        }
                    }
                }

                string strMessageNotHaveIp = "";
                switch (status)
                {
                    case "ok":
                        #region Trường hợp đăng nhập thành công

                        //{
                        //    string strMessage = "";
                        //    _bllPlugin.KiemTraValueHopLeInFileConfig(ref strMessage);
                        //    if (strMessage != "")
                        //    {
                        //        QTMessageBox.ShowNotify(strMessage);
                        //    }
                        //}

                        //DicLoginInfo["DateTimePhienBanClientHienTai"] = DtPhienBan;

                        //{
                        //    string strMessage = "";
                        //    string strInfoAppLicense = "";
                        //    CheckLicenseApp(ref strInfoAppLicense, ref strMessage);
                        //    _mainWindow.lblInfoAppLicense.Content = strInfoAppLicense;
                        //    if (strMessage != "")
                        //    {
                        //        QTMessageBox.ShowNotify(strMessage);
                        //    }
                        //}

                        //_countDisconnect = 0;

                        //string strUserText = "";
                        //string strPassBase64 = "";
                        //if (CheckSavedAccount)
                        //{
                        //    strUserText = strUser;
                        //    //strPassBase64=_bllPlugin.Base64Encode(_mainWindow.ucLoginMaster.passBox.Password.Trim());
                        //    strPassBase64 = _bllPlugin.Base64Encode("");
                        //}

                        //SaveSettings(ref DicData, ref TupleSetting, strUserText, strPassBase64,
                        //  _serverSelected.IsServer, CheckSavedAccount);
                        //_isServer = _serverSelected.IsServer;

                        //_bllPlugin.TryToRunUnikeyAsAdminIfNotRun();

                        //LoadMenuByPluginAndRuleUser();
                        //if (_lstMenuItems.Count == 0)
                        //{
                        //    QTMessageBox.ShowNotify("Có lỗi trong quá trình tải file plugin, bạn vui lòng liên hệ bộ phận kĩ thuật để được hỗ trợ!"
                        //      , "(_lstMenuItems.Count==0)");
                        //    break;
                        //}

                        //DateTime dtLoginTimeGanNhat = DateTime.Now;
                        //ShowInfoUserLogin(strUser, dtLoginTimeGanNhat);
                        //_mainWindow.txtHanCuoi.Content = strPhienBanHanCuoi;

                        //_isLogin = false;
                        //OnPropertyChanged(nameof(ShowLogin));
                        //_isMain = true;
                        //OnPropertyChanged(nameof(ShowMain));

                        //_mainWindow.windowMain.MinHeight = 700;
                        //_mainWindow.windowMain.MinWidth = 1024;

                        //MenuMouseEnterCommand.Execute(null);

                        //BackToMainMenuCommand.Execute(null);

                        //Hide(); 
                        #endregion

                        break;
                    case "notadminadmin":
                        //QTMessageBox.ShowNotify("Tài khoản hoặc mật khẩu không đúng, bạn vui lòng thao tác lại!");
                        strError = "Tài khoản hoặc mật khẩu không đúng, bạn vui lòng thao tác lại!";
                        break;
                    case "HetHan":
                        //QTMessageBox.ShowNotify("Bạn vui lòng kích hoạt mã gia hạn để tiếp tục sử dụng!");
                        //ShowCheckSystemDialogCommand.Execute(null);
                        strError = "Bạn vui lòng kích hoạt mã gia hạn để tiếp tục sử dụng!";
                        break;
                    case "dtOutputNull":
                        //QTMessageBox.ShowNotify("Kiểm tra dữ liệu đăng nhập không thành công hoặc tài khoản chưa kích hoạt mã gia hạn lần nào, bạn vui lòng thử lại!");
                        strError = "Kiểm tra dữ liệu đăng nhập không thành công hoặc tài khoản chưa kích hoạt mã gia hạn lần nào, bạn vui lòng thử lại!";
                        break;
                    case "dangnhapsai":
                        //QTMessageBox.ShowNotify("Tài khoản hoặc mật khẩu không đúng, bạn vui lòng thao tác lại!");
                        strError = "Tài khoản hoặc mật khẩu không đúng, bạn vui lòng thao tác lại!";
                        break;
                    case "notok":
                        strMessageNotHaveIp = mes.Substring(0, (mes.Length > 28) ? mes.Length - 28 : mes.Length - 1);
                        //QTMessageBox.ShowNotify(strMessageNotHaveIp);
                        strError = strMessageNotHaveIp;
                        break;
                    case "logout":
                        strMessageNotHaveIp = mes.Substring(0, (mes.Length > 28) ? mes.Length - 28 : mes.Length - 1);
                        //QTMessageBox.ShowNotify(strMessageNotHaveIp);
                        //Application.Restart();
                        strError = strMessageNotHaveIp;
                        break;
                    case "disconnect":
                        strMessageNotHaveIp = mes.Substring(0, (mes.Length > 28) ? mes.Length - 28 : mes.Length - 1);
                        //QTMessageBox.ShowNotify(strMessageNotHaveIp);
                        //_countDisconnect++;
                        strError = strMessageNotHaveIp;
                        break;
                    case "exits":
                        //RunCommand(2, mes);
                        strError = mes;
                        break;
                    case "error":
                        //QTMessageBox.ShowNotify(mes);
                        strError = mes;
                        break;
                }


                if (strError == "")
                {
                    strToken = dicInput["string.strJwtTokenForLogin"].ToString()!;
                }
            }
            catch (Exception et)
            {
                string str = et.Message;
                strError = et.Message;
            }
        }

        private ClaimsPrincipal ClaimsPrincipalValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            var validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }

    }
}
