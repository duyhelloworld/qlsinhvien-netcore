using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;

public class MonHocDto
{
    [JsonIgnore]
    public int? MaMonHoc { get; set; }
    public string TenMonHoc { get; set; }
    public int SoTinChi { get; set; }
    public bool BatBuoc { get; set; }
    public string? MoTa { get; set; }
    public HashSet<int>? MaMonTienQuyet { get; set; }
}
