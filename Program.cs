using System.Text;
using System.Text.Json.Serialization;
using EnumStringValues;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using qlsinhvien.Atributes;
using qlsinhvien.Context;
using qlsinhvien.Entities;
using qlsinhvien.Services;
using qlsinhvien.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Custom Attributes
builder.Services.AddSingleton(new PhanQuyen(EQuyen.KhongCoQuyen));

// Services
builder.Services.AddScoped<IGiangVienService, GiangVienService>();
builder.Services.AddScoped<IKhoaService, KhoaService>();
builder.Services.AddScoped<IDiemSinhVienService, DiemSinhVienService>();
builder.Services.AddScoped<ISinhVienService, SinhVienService>();
builder.Services.AddScoped<IMonHocService, MonHocService>();
builder.Services.AddScoped<IBoMonService, BoMonService>();
builder.Services.AddScoped<ITaiKhoanService, TaiKhoanService>();
builder.Services.AddScoped<IQuyenService, QuyenService>();
builder.Services.AddScoped<INguoiDungService, NguoiDungService>();
builder.Services.AddScoped<ILopQuanLiService, LopQuanLiService>();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    options.EnableThreadSafetyChecks();
});

EnumExtensions.Behaviour.UseCaching = true;

// builder.Services.AddAuthentication(option =>
// {
//     option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//     option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     option.RequireAuthenticatedSignIn = true;
// });


var app = builder.Build();
app.MapControllers();

app.Run();