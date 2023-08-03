using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class GiangVienDbContext : DbContext
{
    public GiangVienDbContext(DbContextOptions<GiangVienDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<GiangVien> GiangViens { get; set; }
}