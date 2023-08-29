using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace qlsinhvien.Entities;

[Table("VaiTro")]
public class VaiTro : IdentityRole
{
    [Key]
    [StringLength(50)]
    // VD: admin
    public string TenVaiTro {get; set;} = null!;

    [StringLength(100)]
    // VD: Adminitrastor
    public string? TenDayDu { get; set; } = null!;

    public ICollection<NguoiDung> NguoiDungs  { get; set; } = new List<NguoiDung>();
}