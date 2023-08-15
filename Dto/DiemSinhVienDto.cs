using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class DiemSinhVienDto
{
    [JsonRequired]
    public int MaLopMonHoc { get; set; }
    [JsonRequired]
    public int MaSinhVien { get; set; }
    [JsonRequired]
    public float DiemChuyenCan { get; set; }
    [JsonRequired]
    public float DiemGiuaKi { get; set; }
    [JsonRequired]
    public float DiemCuoiKi { get; set; }
    [JsonRequired]
    public int HocKi { get; set; }
    public string GhiChu { get; set; }

}