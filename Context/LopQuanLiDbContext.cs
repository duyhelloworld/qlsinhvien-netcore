using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class LopQuanLiDbContext : DbContext
{
    public LopQuanLiDbContext(DbContextOptions<LopQuanLiDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<LopQuanLi> LopQuanLis { get; set; }
}