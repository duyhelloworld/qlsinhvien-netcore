using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class KhoaDbContext : DbContext
{
    public KhoaDbContext(DbContextOptions<KhoaDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<Khoa> Khoas { get; set; }
}