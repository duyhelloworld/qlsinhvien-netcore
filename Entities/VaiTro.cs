using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities;

[Table("VaiTro")]
public class VaiTro
{
    [Key]
    public string TenVaiTro {get; set;} = null!;

    [StringLength(100)]
    public string? GhiChu { get; set; }

    public ICollection<NguoiDung> NguoiDungs  { get; set; } = new List<NguoiDung>();
    
    public ICollection<QuyenVaiTro> QuyenVaiTros { get; set; } = new List<QuyenVaiTro>();
}