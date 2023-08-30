using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities;

[Table("NguoiDung")]
public class NguoiDung
{
    [Key]
    [StringLength(50)]
    public string TenNguoiDung { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string MatKhau { get; set; } = null!;

    public int? MaGiangVien { get; set; }
    public int? MaSinhVien { get; set; }

    public int MaVaiTro  { get; set; }
    [ForeignKey("MaVaiTro")]
    public VaiTro VaiTro  { get; set; } = null!;

    #region Chưa sử dụng, Đăng nhập chỉ qua tên user 
    
    [NotMapped]
    [StringLength(60)]
    public string? TenHienThi { get; set; }

    [NotMapped]
    [StringLength(60)]
    public string? Email { get ; set; }

    [NotMapped]
    [StringLength(10)]
    public string? SoDienThoai  {get; set;}
    #endregion
}