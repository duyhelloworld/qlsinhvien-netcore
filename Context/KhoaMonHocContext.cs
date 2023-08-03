using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class KhoaMonHocDbContext : DbContext
{
    public KhoaMonHocDbContext(DbContextOptions<KhoaMonHocDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<KhoaMonHoc> KhoaMonHocs { get; set; }
}