using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;

[Table("NguoiDung_VaiTro")]
[PrimaryKey(nameof(TenNguoiDung), nameof(TenVaiTro))]
public class NguoiDungVaiTro
{

    public string TenNguoiDung {get; set;} = null!;
    [ForeignKey("TenNguoiDung")]
    public NguoiDung NguoiDung  {get; set;} = null!;

    public string TenVaiTro { get; set; } = null!;
    [ForeignKey("TenVaiTro")]
    public VaiTro VaiTro { get; set; } = null!;
}