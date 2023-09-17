using System.ComponentModel.DataAnnotations;
using qlsinhvien.Entities;

namespace qlsinhvien.Dto;
public class MonHocDto
{
    [Required]
    [MaxValue(1, EGioiHan.MaxMonHoc)]
    public int MaMonHoc { get; set; }
    public string TenMonHoc { get; set; } = null!;
    public short SoTinChi { get; set; }
    public bool BatBuoc { get; set; }
    public string? MoTa { get; set; }
    public int? MaMonTienQuyet { get; set; }
    [MaxValue(1, EGioiHan.MaxBoMon)]
    public int MaBoMon { get; set; }
    [MaxValue(1, EGioiHan.MaxLopMonHoc)]
    public int MaLopMonHoc { get; set; }
}