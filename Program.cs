using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// builder.Services.AddHttpClient("httpClient", client => {
//     client.BaseAddress = new Uri("http://localhost:5277");
// });
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    // options.EnableSensitiveDataLogging(true);
    options
        .EnableDetailedErrors()
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings"));
});

var app = builder.Build();
app.MapControllers();

app.Run();