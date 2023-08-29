using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace qlsinhvien.Entities;

[Table("NguoiDung")]
public class NguoiDung : IdentityUser
{
    [Key]
    [StringLength(50)]
    public string TenNguoiDung { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string MatKhau { get; set; } = null!;

    [Required]
    public int MaSo { get; set; } = 0;
    
    public string TenVaiTro  { get; set; } = null!;
    [ForeignKey("TenVaiTro")]
    public VaiTro VaiTro  { get; set; } = null!;

    #region Chưa sử dụng, Đăng nhập chỉ qua tên user
    [NotMapped]
    [StringLength(60)]
    public string? TenHienThi { get; set; }

    [NotMapped]
    [StringLength(60)]
    public override string? Email { get ; set; }

    [NotMapped]
    [StringLength(10)]
    public string? SoDienThoai  {get; set;}
    #endregion
}