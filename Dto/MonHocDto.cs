using System.Text.Json.Serialization;
using qlsinhvien.Entities;

namespace qlsinhvien.Dto;
public class MonHocDto
{
    [JsonRequired]
    public int MaMonHoc { get; set; }
    public string TenMonHoc { get; set; }
    public short SoTinChi { get; set; }
    public bool BatBuoc { get; set; }

    public string MoTa { get; set; }

    public int MaMonTienQuyet { get; set; }
    [JsonRequired]
    public int MaBoMon { get; set; }

    public int MaLopMonHoc { get; set; }
}