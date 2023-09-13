using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Dto;
public class LopMonHocDto
{
    [Required]
    [Range(1, 200)]
    public int MaLopMonHoc { get; set; }
    public string TenLopMonHoc { get; set; } = null!;
    public int MaMonHoc { get; set; }
    public int MaGiangVien { get; set; }
}