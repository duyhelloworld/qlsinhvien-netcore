using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities;

[Table("Quyen")]
public class Quyen
{
    [Key]
    public int MaQuyen  { get; set; }

    [Required]
    public string TenQuyen  { get; set; } = null!;

    [MaxLength]
    public string? MoTa { get; set; } = null!;

    public ICollection<VaiTro> VaiTros { get; set; } = new List<VaiTro>();
}