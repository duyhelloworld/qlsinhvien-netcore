using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class MonHocDto
{
    
    public int MaMonHoc { get; set; }
    
    public string TenMonHoc { get; set; } = null!;
    
    public short SoTinChi { get; set; }
    
    public bool BatBuoc { get; set; }

    public string? MoTa { get; set; }

    public int MaMonTienQuyet { get; set; }
    
    public int MaBoMon { get; set; }

    public int MaLopMonHoc { get; set; }
}