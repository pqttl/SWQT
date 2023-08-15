using Newtonsoft.Json;
using SWQT._768ConstantValue;
using SWQT._768ConstantValue.LinkApi;
using System.Data;
using System.Net.Http.Headers;
using System.Text;

namespace QT.SuperWebApp.Services
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string StrBaseAddress = "";

        protected BaseApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;

            StrBaseAddress = _configuration[STR_api.STR_BASE_ADDRESS.STR];
        }

        protected async Task<TResponse> TGetAsync<TResponse>(string strRequestUri)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            UpdateClientByToken(ref client);

            var response = await client.GetAsync(strRequestUri);
            return await TResultDeserializeJson<TResponse>(response);
        }

        private void UpdateClientByToken(ref HttpClient client)
        {
            string strTokenSessions = _httpContextAccessor.HttpContext!.Session.GetString(QTConstants.AppSettings.Token.STR)!;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strTokenSessions);
            client.BaseAddress = new Uri(StrBaseAddress);

        }

        public async Task<TResponse> TPostAsync<TResponse>(string strRequestUri, string strJsonInput)
        {
            var httpContent = new StringContent(strJsonInput, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            UpdateClientByToken(ref client);

            var response = await client.PostAsync(strRequestUri, httpContent);
            return await TResultDeserializeJson<TResponse>(response);
        }

        public async Task<TResponse> TPutAsync<TResponse>(string strRequestUri, string strJsonInput)
        {
            var httpContent = new StringContent(strJsonInput, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            UpdateClientByToken(ref client);

            var response = await client.PutAsync(strRequestUri, httpContent);
            return await TResultDeserializeJson<TResponse>(response);
        }

        private async Task<TResponse> TResultDeserializeJson<TResponse>(HttpResponseMessage response)
        {
            string strJson = await response.Content.ReadAsStringAsync();

            var mApiResult = JsonConvert.DeserializeObject<TResponse>(strJson);

            return mApiResult!;
        }





        public async Task<string> TStringPostAsync(string strRequestUri, string strJsonInput)
        {
            var httpContent = new StringContent(strJsonInput, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(StrBaseAddress);

            var response = await client.PostAsync(strRequestUri, httpContent);
            string strJsonDictionary = await response.Content.ReadAsStringAsync();
            return strJsonDictionary;
        }

        protected async Task<TResponse> TDeleteAsync<TResponse>(string strRequestUri)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            UpdateClientByToken(ref client);

            var response = await client.DeleteAsync(strRequestUri);
            string strJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TResponse>(strJson)!;

            var mApiResult = JsonConvert.DeserializeObject<TResponse>(strJson);

            return mApiResult!;
        }

    }
}
