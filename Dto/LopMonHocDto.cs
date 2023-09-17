using System.ComponentModel.DataAnnotations;
using qlsinhvien.Entities;

namespace qlsinhvien.Dto;
public class LopMonHocDto
{
    [Required]
    [MaxValue(1, EGioiHan.MaxLopMonHoc)]
    public int MaLopMonHoc { get; set; }
    public string TenLopMonHoc { get; set; } = null!;
    [MaxValue(1, EGioiHan.MaxMonHoc)]
    public int MaMonHoc { get; set; }
    [MaxValue(1, EGioiHan.MaxGiangVien)]
    public int MaGiangVien { get; set; }
}