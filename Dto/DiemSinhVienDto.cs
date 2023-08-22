using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class DiemSinhVienDto
{
    [JsonRequired]
    public int MaLopMonHoc { get; set; }
    [JsonRequired]
    public int MaSinhVien { get; set; }
    public float DiemChuyenCan { get; set; }
    public float DiemGiuaKi { get; set; }
    public float DiemCuoiKi { get; set; }
    public int HocKi { get; set; }
    public string? GhiChu { get; set; }
}