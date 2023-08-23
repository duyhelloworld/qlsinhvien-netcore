using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Services;
using qlsinhvien.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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

var app = builder.Build();
app.MapControllers();

app.Run();