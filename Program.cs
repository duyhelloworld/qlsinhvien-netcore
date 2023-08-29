using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using qlsinhvien.Context;
using qlsinhvien.Entities;
using qlsinhvien.Services;
using qlsinhvien.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Services
builder.Services.AddScoped<IGiangVienService, GiangVienService>();
builder.Services.AddScoped<IKhoaService, KhoaService>();
builder.Services.AddScoped<IDiemSinhVienService, DiemSinhVienService>();
builder.Services.AddScoped<ISinhVienService, SinhVienService>();
builder.Services.AddScoped<IMonHocService, MonHocService>();
builder.Services.AddScoped<ITaiKhoanService, TaiKhoanService>();


builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings"));
    options.EnableThreadSafetyChecks();
});

builder.Services.AddIdentity<NguoiDung, VaiTro>(option =>
{
    option.User.RequireUniqueEmail = true;

    option.Password.RequireDigit = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequiredUniqueChars = 0;
    option.Password.RequiredLength = 5;

    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedEmail = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;

    option.Lockout.MaxFailedAccessAttempts = 3;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
})
.AddEntityFrameworkStores<ApplicationContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.RequireAuthenticatedSignIn = true;
}).AddJwtBearer(option =>
{
    option.SaveToken = true;
    option.RequireHttpsMetadata = false;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudiences = builder.Configuration.GetSection("JWT:Audiences").Get<IEnumerable<string>>(),
        IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]!)),
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();