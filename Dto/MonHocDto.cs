using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class MonHocDto
{
    [JsonRequired]
    public int MaMonHoc { get; set; }
    [JsonRequired]
    public string TenMonHoc { get; set; }
    [JsonRequired]
    public short SoTinChi { get; set; }
    [JsonRequired]
    public bool BatBuoc { get; set; }

    public string MoTa { get; set; }

    public int MaMonTienQuyet { get; set; }
    [JsonRequired]
    public int MaBoMon { get; set; }

    public int MaLopMonHoc { get; set; }
}