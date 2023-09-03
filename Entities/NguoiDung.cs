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

    public string? TenVaiTro  { get; set; }
    [ForeignKey("TenVaiTro")]
    public VaiTro VaiTro  { get; set; } = null!;

    [StringLength(60)]
    public string? TenHienThi { get; set; } = null!;
}