using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class KhoaDto
{
    [Range(1, 20)]
    public int MaKhoa { get; set; }
    [Required]
    public string TenKhoa { get; set; } = null!;
    public ICollection<int>? MaBoMons { get; set; }
    public ICollection<int>? MaLopQuanLis { get; set; }
}