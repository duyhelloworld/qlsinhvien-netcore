using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class MonHocDbContext : DbContext
{
    public MonHocDbContext(DbContextOptions<MonHocDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<MonHoc> MonHocs { get; set; }
}