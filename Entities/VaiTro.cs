using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace qlsinhvien.Entities;

[Table("VaiTro")]
public class VaiTro
{
    [Key]
    public string TenVaiTro {get; set;} = null!;

    [StringLength(100)]
    public string? GhiChu { get; set; } = null!;

    public ICollection<NguoiDung> NguoiDungs  { get; set; } = new List<NguoiDung>();
    
    public ICollection<Quyen> Quyens { get; set; } = new List<Quyen>();
}