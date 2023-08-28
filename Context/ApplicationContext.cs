using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class ApplicationContext : DbContext
{

    public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    #region DbSet
    public DbSet<SinhVien> SinhViens { get; set; }
    public DbSet<DiemSinhVien> DiemSinhViens { get; set; }
    public DbSet<GiangVien> GiangViens { get; set; }
    public DbSet<Khoa> Khoas { get; set; }
    public DbSet<LopMonHoc> LopMonHocs { get; set; }
    public DbSet<LopQuanLi> LopQuanLis { get; set; }
    public DbSet<MonHoc> MonHocs { get; set; }
    public DbSet<BoMon> BoMons { get; set; }
    public DbSet<NguoiDung> NguoiDungs { get; set; }
    public DbSet<VaiTro> VaiTros { get; set; }
    public DbSet<NguoiDungVaiTro> NguoiDungVaiTros { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Bỏ hết mấy bảng chưa xài
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();

        // Tự custom nên bỏ đc
        builder.Ignore<IdentityRole>();
        builder.Ignore<IdentityUser>();
        builder.Ignore<IdentityUserRole<string>>();
        
        // Bỏ hết mấy cột linh tinh
        builder.Entity<VaiTro>(vaitro =>
        {
            vaitro.Ignore(vt => vt.Id);
            vaitro.Ignore(vt => vt.Name);
            vaitro.Ignore(vt => vt.ConcurrencyStamp);
            vaitro.Ignore(vt => vt.NormalizedName);
        });

        builder.Entity<NguoiDung>(nguoiDung =>
        {
            nguoiDung.Ignore(nd => nd.Id);
            nguoiDung.Ignore(nd => nd.PhoneNumber);
            nguoiDung.Ignore(nd => nd.PasswordHash);
            nguoiDung.Ignore(nd => nd.UserName);
            nguoiDung.Ignore(nd => nd.AccessFailedCount);
            nguoiDung.Ignore(nd => nd.NormalizedUserName);
            nguoiDung.Ignore(nd => nd.NormalizedEmail);
            nguoiDung.Ignore(nd => nd.EmailConfirmed);
            nguoiDung.Ignore(nd => nd.SecurityStamp);
            nguoiDung.Ignore(nd => nd.ConcurrencyStamp);
            nguoiDung.Ignore(nd => nd.PhoneNumberConfirmed);
            nguoiDung.Ignore(nd => nd.TwoFactorEnabled);
            nguoiDung.Ignore(nd => nd.LockoutEnd);
            nguoiDung.Ignore(nd => nd.LockoutEnabled);
        });

        // foreach (var entityType in builder.Model.GetEntityTypes())
        // {
        //     var tableName = entityType.GetTableName();
        //     if (tableName!.StartsWith("AspNet"))
        //     {
        //         entityType.SetTableName(tableName.Substring(6));
        //     }
        // }
    }
}