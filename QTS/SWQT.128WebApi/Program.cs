using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SWQT._128WebApi.Services;
using SWQT._224DataAccessSQLiteEFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




#region Enable CORS để front end react gọi được api, còn có 1 cách sửa ở front end bằng cách sửa chrome(cách này đã thử nhưng chưa được)
//IConfigurationSection myArraySection = Configuration.GetSection("ArrayStringLinkFrontendReact");
//var itemArray = myArraySection.AsEnumerable();
//string[] arrayStringLinkFrontend = Configuration.GetSection("ArrayStringLinkFrontendReact").Get<string[]>();
////Sửa arrayStringLinkFrontend ở DNQT.BackendApi\appsettings.json

//builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
//{
//    builder.WithOrigins(arrayStringLinkFrontend)
//           .AllowAnyMethod()
//           .AllowAnyHeader();
//}));
#endregion

#region Khai báo DI
//Declare DI
builder.Services.AddTransient<ILoginService, SLoginService>();
builder.Services.AddTransient<IStatisticService, SStatisticService>();
builder.Services.AddTransient<IPostService, SPostService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
#endregion


#region Thêm Automapper

builder.Services.AddAutoMapper(typeof(Program).Assembly);
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

builder.Services.AddControllers();




//Instal Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="3.1.28"
//Thêm lệnh này nếu không sẽ bị lỗi System.Text.Json.JsonException: A possible object cycle was detected ...
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

#region Thêm swagger và JwtBearer

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger DNQT Solution", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
            new List<string>()
                      }
                    });
});

string issuer = builder.Configuration.GetValue<string>("Tokens:Issuer");
string signingKey = builder.Configuration.GetValue<string>("Tokens:Key");
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = issuer,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = System.TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
    };
});

#endregion




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



















var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}



//Phải thêm lệnh này thì HttpContext.SignInAsync mới có tác dụng lưu thông tin đăng nhập và vào trang chủ
//Còn không thêm thì nó cứ redirect đến trang login như chưa đăng nhập
//Nếu không thêm ở dll api thì bị lỗi 401 unauthozied...
app.UseAuthentication();



app.UseHttpsRedirection();




#region Enable CORS để front end react gọi được api, còn có 1 cách sửa ở front end bằng cách sửa chrome(cách này đã thử nhưng chưa được)
//app.UseCors("MyPolicy");
#endregion




app.UseAuthorization();




#region Thêm swagger và JwtBearer

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger SWQT V1");
});

#endregion




app.MapControllers();

app.Run();
