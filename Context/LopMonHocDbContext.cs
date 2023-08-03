using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class LopMonHocDbContext : DbContext
{
    public LopMonHocDbContext(DbContextOptions<LopMonHocDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<LopMonHoc> LopMonHocs { get; set; }
}