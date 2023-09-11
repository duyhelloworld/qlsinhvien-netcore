using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;

public class GiangVienDto : ConNguoiDto
{
    [Range(1, 500)]
    public int MaGiangVien { get; set; }

    [Range(1, 500)]
    public int MaBoMon { get; set; }

    public int? MaLopQuanLi { get; set; }

    public ICollection<int>? MaLopMonHocs { get; set; }
}