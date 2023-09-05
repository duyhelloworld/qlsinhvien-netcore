using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;

[Index("Email", IsUnique = true)]
[Index("SoDienThoai", IsUnique = true)]
public class ConNguoi
{
    [Required]
    [StringLength(40)]
    public required string HoTen { get; set; }

    public bool GioiTinh { get; set; }

    [Column(TypeName = "date")]
    public DateTime? NgaySinh { get; set; }

    [StringLength(80)]
    public string? DiaChiThuongTru { get; set; }

    [StringLength(80)]
    public string? QueQuan { get; set; }

    [Required]
    [MaxLength(150)]
    public required string Email { get; set; }

    [Required]
    [StringLength(10)]
    public required string SoDienThoai { get; set; }
}