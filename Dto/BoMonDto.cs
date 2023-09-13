using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities;

public class BoMonDto
{
    [Range(1, 200)]
    public int MaBoMon { get; set; }
    [Required]
    public string TenBoMon { get; set; } = null!;
    public ICollection<int>? MaMonHocs { get; set; }
    public ICollection<int>? MaGiangViens { get; set; }
    public ICollection<int>? MaKhoas { get; set; }
}