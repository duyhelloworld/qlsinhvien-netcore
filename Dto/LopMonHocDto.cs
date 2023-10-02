using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class LopMonHocDto
{
    
    public int MaLopMonHoc { get; set; }
    
    public string TenLopMonHoc { get; set; } = null!;

    public int MaMonHoc { get; set; }
    
    public int MaGiangVien { get; set; }
}