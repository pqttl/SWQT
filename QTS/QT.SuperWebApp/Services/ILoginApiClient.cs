using SWQT._512ViewModels.Admin.Login;

namespace QT.SuperWebApp.Services
{
    public interface ILoginApiClient
    {
        Task<string> TStrJsonAuthenticate(VMLoginRequest mRequest);
    }
}
