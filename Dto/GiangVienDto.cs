using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using qlsinhvien.Entities;

namespace qlsinhvien.Dto;

public class GiangVienDto : ConNguoiDto
{
    [MaxValue(1,EGioiHan.MaxGiangVien)]
    public int MaGiangVien { get; set; }

    [MaxValue(1, EGioiHan.MaxBoMon)]
    public int MaBoMon { get; set; }

    public int? MaLopQuanLi { get; set; }

    public ICollection<int>? MaLopMonHocs { get; set; }
}