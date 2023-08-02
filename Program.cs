using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppQLSVContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings"));
});
var app = builder.Build();
app.MapControllers();

app.Run();