using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<SinhVien> SinhViens { get; set; }
    public DbSet<DiemSinhVien> DiemSinhViens { get; set; }
    public DbSet<GiangVien> GiangViens { get; set; }
    public DbSet<Khoa> Khoas { get; set; }
    public DbSet<LopMonHoc> LopMonHocs { get; set; }
    public DbSet<LopQuanLi> LopQuanLis { get; set; }
    public DbSet<MonHoc> MonHocs { get; set; }

    public DbSet<BoMon> BoMons { get; set; }
}