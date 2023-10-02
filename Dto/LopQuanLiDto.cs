using System.Text.Json.Serialization;
using qlsinhvien.Entities;

namespace qlsinhvien.Dto;

public class LopQuanLiDto
{
    public int MaLopQuanLi { get; set; }
    public string TenLopQuanLi { get; set; } = null!;

    public int MaKhoa { get; set; }
    public GiangVien? giangVien{ get; set; }
}