using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class SinhVienDbContext : DbContext {
    public SinhVienDbContext(DbContextOptions<SinhVienDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<SinhVien> SinhViens { get; set; }
}