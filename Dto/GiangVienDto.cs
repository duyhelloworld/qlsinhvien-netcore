using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;

public class GiangVienDto : ConNguoiDto
{
    
    public int MaGiangVien { get; set; }
    
    public int MaBoMon { get; set; }

    public int? MaLopQuanLi { get; set; }

    public ICollection<int>? MaLopMonHocs { get; set; }
}