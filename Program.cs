using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using qlsinhvien.Atributes;
using qlsinhvien.Context;
using qlsinhvien.Services;
using qlsinhvien.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Custom Attributes
builder.Services.AddSingleton(new PhanQuyen(""));

// Services
builder.Services.AddScoped<IGiangVienService, GiangVienService>();
builder.Services.AddScoped<IKhoaService, KhoaService>();
builder.Services.AddScoped<IDiemSinhVienService, DiemSinhVienService>();
builder.Services.AddScoped<ISinhVienService, SinhVienService>();
builder.Services.AddScoped<IMonHocService, MonHocService>();
builder.Services.AddScoped<IBoMonService, BoMonService>();
builder.Services.AddScoped<ITaiKhoanService, TaiKhoanService>();
builder.Services.AddScoped<IQuyenService, QuyenService>();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    options.EnableThreadSafetyChecks();
});

// builder.Services.AddIdentity<NguoiDung, VaiTro>()
// .AddDefaultTokenProviders();

builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.RequireAuthenticatedSignIn = false;
});

builder.Services.AddAuthorization();

// builder.Services.AddLogging(config => {
//     config.AddConsole().AddDebug().AddJsonConsole();
// });

var app = builder.Build();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();