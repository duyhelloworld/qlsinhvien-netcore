using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class DiemSinhVienDto
{
    [Range(1, 200)]
    public int MaLopMonHoc { get; set; }
    [Required]
    [Range(1, 5000)]
    public int MaSinhVien { get; set; }
    [Range(0, 30)]
    public float DiemChuyenCan { get; set; }
    [Range(0, 10)]
    public float DiemGiuaKi { get; set; }
    [Range(0, 10)]
    public float DiemCuoiKi { get; set; }
    [Range(1, 8)]
    public int HocKi { get; set; }
    public string? GhiChu { get; set; }
}