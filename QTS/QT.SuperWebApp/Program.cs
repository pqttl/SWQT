using Microsoft.AspNetCore.Authentication.Cookies;
using QT.SuperWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Thiet lap redirect den trang login khi chua dang nhap

//Thiet lap redirect den trang login khi chua dang nhap
string strTemp = nameof(QT.SuperWebApp.Controllers.LoginController);
string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
string strActionLogin = nameof(QT.SuperWebApp.Controllers.LoginController.Index);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
        options.LoginPath = $"/{strController}/{strActionLogin}/";
        options.AccessDeniedPath = "/Forbidden/";
    });

#endregion


#region Thiết lập thông số khi sử dụng session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
#endregion

#region Injection gan gia tri cho interface
//Injection gan gia tri cho interface
builder.Services.AddHttpClient();
//builder.Services.AddTransient<IOrderApiClient, OrderApiClient>();
builder.Services.AddTransient<ILoginApiClient, LoginApiClient>();
//builder.Services.AddTransient<IUserApiClient, UserApiClient>();
builder.Services.AddTransient<IStatisticApiClient, ACStatisticApiClient>();
//builder.Services.AddTransient<IViewRenderService, ViewRenderService>();
#endregion


























var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

#region Thiết lập để lưu được thông tin đăng nhập

//Phải thêm lệnh này thì HttpContext.SignInAsync mới có tác dụng lưu thông tin đăng nhập và vào trang chủ
//Còn không thêm thì nó cứ redirect đến trang login như chưa đăng nhập
//Nếu không thêm ở dll api thì bị lỗi 401 unauthozied...
app.UseAuthentication(); 

#endregion

app.UseRouting();

app.UseAuthorization();

#region Thiết lập thông số khi sử dụng session
app.UseSession();
#endregion

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
