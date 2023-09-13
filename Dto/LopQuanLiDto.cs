using System.Text.Json.Serialization;
using qlsinhvien.Entities;

namespace qlsinhvien.Dto;

public class LopQuanLiDto
{
    [JsonRequired]
    public int MaLopQuanLi { get; set; }

    public string TenLopQuanLi { get; set; } = null!;

    public int MaKhoa { get; set; }
    public int MaGiangVien { get; set; }
    public GiangVien? GiangVien { get; set; }
}