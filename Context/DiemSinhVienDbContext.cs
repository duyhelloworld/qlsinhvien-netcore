using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class DiemSinhVienDbContext : DbContext
{
    public DiemSinhVienDbContext(DbContextOptions<DiemSinhVienDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<DiemSinhVien> DiemSinhViens { get; set; }
}