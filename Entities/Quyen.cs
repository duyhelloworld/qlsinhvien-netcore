using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities;

[Table("Quyen")]
public class Quyen
{
    [Key]
    public string TenQuyen  { get; set; } = null!;

    [MaxLength]
    public string? GhiChu { get; set; } = null!;

    public ICollection<QuyenVaiTro> VaiTros { get; set; } = new List<QuyenVaiTro>();
}