using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class LopMonHocDto
{
    [JsonRequired]
    public int MaLopMonHoc { get; set; }
    [JsonRequired]
    public string TenLopMonHoc { get; set; }
    [JsonRequired]
    public int MaMonHoc { get; set; }
    [JsonRequired]
    public int MaGiangVien { get; set; }
}