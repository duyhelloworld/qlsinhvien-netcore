using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class ApplicationContext : IdentityDbContext<IdentityUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }
    // public DbSet<SinhVien> SinhViens { get; set; }
    // public DbSet<DiemSinhVien> DiemSinhViens { get; set; }
    // public DbSet<GiangVien> GiangViens { get; set; }
    // public DbSet<Khoa> Khoas { get; set; }
    // public DbSet<LopMonHoc> LopMonHocs { get; set; }
    // public DbSet<LopQuanLi> LopQuanLis { get; set; }
    // public DbSet<MonHoc> MonHocs { get; set; }
    // public DbSet<BoMon> BoMons { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        foreach (var type in builder.Model.GetEntityTypes())
        {
            var tableName = type.GetTableName()!;
            if (tableName.StartsWith("AspNet"))
            {
                type.SetTableName(tableName.Replace("AspNet", ""));
            }
        }
    }
}