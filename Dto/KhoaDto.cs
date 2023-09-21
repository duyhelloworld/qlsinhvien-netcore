using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using qlsinhvien.Entities;

namespace qlsinhvien.Dto;
public class KhoaDto
{
    [MaxValue(1, EGioiHan.MaxKhoa)]
    public int MaKhoa { get; set; }
    [Required]
    public string TenKhoa { get; set; } = null!;
    public ICollection<int>? MaBoMons { get; set; }
    public ICollection<int>? MaLopQuanLis { get; set; }
}