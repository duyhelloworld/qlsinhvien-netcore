using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;

[Table("Quyen_VaiTro")]
[PrimaryKey("TenQuyen", "TenVaiTro")]
public class QuyenVaiTro
{
    public string TenQuyen { get; set; } = null!;
    [ForeignKey(" TenQuyen")]
    public Quyen Quyen { get; set; } = null!;
    public string TenVaiTro { get; set; } = null!;
    [ForeignKey("TenVaiTro")]
    public VaiTro VaiTro { get; set; } = null!;
}