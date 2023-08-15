using Newtonsoft.Json;
using SWQT._512ViewModels.Admin.Login;
using SWQT._768ConstantValue.LinkApi;

namespace QT.SuperWebApp.Services
{
    public class LoginApiClient : BaseApiClient, ILoginApiClient
    {

        public LoginApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<string> TStrJsonAuthenticate(VMLoginRequest mRequest)
        {
            string strJsonInput = JsonConvert.SerializeObject(mRequest);
            string strRequestUri = STR_URI_Login.STR_URI_DANGNHAP.STR;

            string strJsonDictionary = await TStringPostAsync(strRequestUri, strJsonInput);
            return strJsonDictionary;
        }

    }
}
