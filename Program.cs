using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using qlsinhvien.Context;
using qlsinhvien.SecurityConfig;
using qlsinhvien.Services;
using qlsinhvien.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Service
builder.Services.AddScoped<IGiangVienService, GiangVienService>();
builder.Services.AddScoped<IKhoaService, KhoaService>();
builder.Services.AddScoped<IDiemSinhVienService, DiemSinhVienService>();
builder.Services.AddScoped<ISinhVienService, SinhVienService>();
builder.Services.AddScoped<IMonHocService, MonHocService>();

// builder.Services.AddHttpClient("httpClient", client => {
//     client.BaseAddress = new Uri("http://localhost:5277");
// });
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    // options.EnableSensitiveDataLogging(true);
    options
        // .EnableDetailedErrors()
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings"));
});

// In secretKey
var secretKey = builder.Configuration.GetSection("AppSetting:SecretKey").Value;
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey!);
Console.WriteLine("Secret Key = " + secretKey);

// Nếu dùng IOptionMonitor ở UserController
// builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSetting"));

// Bản .net 5.0
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// Có thể dùng CookiesBaseAuthentication
.AddJwtBearer(opt => {
    opt.TokenValidationParameters = new TokenValidationParameters() {
        // Tự gen token nên ko cần 2 tham số này
        // Nếu xài OAuth (google, facebook) thì bật lại (để dùng SSO)
        ValidateIssuer = false,
        // - Check có phải người tạo token (issuer) - thực thể tạo, phát hành token 
        ValidateAudience = false,
        // - Check có phải người nhận token (audience) - token tạo ra chỉ để gửi tới người này 

        // Tham số này chỉ ra hàm check issuer
        // IssuerValidator = (issuer, token, @params) => { return issuer == "duypham" ? issuer : null; }
        // Tham số này chỉ ra hàm check audience
        // AudienceValidator = (audiences, token, @params) => {...}

        // Kí lên token
        ValidateIssuerSigningKey = true,
        // TryAllIssuerSigningKeys = true,

        // Có thể đặt luôn tên người kí ở đây, hoặc comment để null như mặc định
        // ValidIssuers = new string[] {"hiepnguyen", "duypham" },
        
        // Khoảng thời gian cho phép sự chệch lệch thời gian khi kiểm tra thời gian của token
        ClockSkew = TimeSpan.Zero,

        // Đặt route cho API cuối (Audience) có phân biệt kí tự / không
        // IgnoreTrailingSlashWhenValidatingAudience = true,

        // Lưu token sau khi validate
        // SaveSigninToken = false,

        // Thuật toán để giải mã khi token được mã hoá (Có RsaSecurity, SymmetricSecurityKey, Asymmetric, ECDsa, X509, )
        // TokenDecryptionKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("duypham")),

        // Thuật toán kiểm tra tính hợp lệ của chữ ký số trong token khi token được gửi đến máy chủ
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

        // Các thuật toán cho phép để kiểm tra tính hợp lệ của chữ kí số, token. Chi tiết trên https://jwt.io
        // ValidAlgorithms = new [] {"HS256", "HS512"},

        // RequireExpirationTime = true, // token có chứa thông tin về thời gian hết hạn của nó
        // ValidateLifetime = true, // Có xác thực thời gian hiệu lực của token không
        // Thuật toán check lifetime (notBefore, expires mới đúng tên khái niệm)
        // LifetimeValidator = (validFrom, invalidWhen, token, parameters) => { return createdWhen <= DateTime.UtcNow && invalidWhen >= DateTime.UtcNow; }, 

    };
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();