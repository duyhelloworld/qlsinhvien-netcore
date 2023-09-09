using Microsoft.AspNetCore.Identity;
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
    public DbSet<NguoiDung> NguoiDungs { get; set; }
    public DbSet<Quyen> Quyens { get; set; }
    public DbSet<VaiTro> VaiTros { get; set; }
    public DbSet<QuyenVaiTro> QuyenVaiTros { get; set; }
    public DbSet<KhoaBoMon> KhoaBoMons { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Bỏ hết mấy bảng chưa xài
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();
        builder.Ignore<IdentityRole>();
        builder.Ignore<IdentityUser>();
        builder.Ignore<IdentityUserRole<string>>();
    }
}