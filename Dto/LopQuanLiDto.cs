using System.Text.Json.Serialization;
using qlsinhvien.Entities;

namespace qlsinhvien.Dto;

public class LopQuanLiDto
{
    [JsonRequired]
    [MaxValue(1, EGioiHan.MaxLopQuanLi)]
    public int MaLopQuanLi { get; set; }

    public string TenLopQuanLi { get; set; } = null!;
    [MaxValue(1, EGioiHan.MaxKhoa)]
    public int MaKhoa { get; set; }
    [MaxValue(1, EGioiHan.MaxGiangVien)]
    public int MaGiangVien { get; set; }
}