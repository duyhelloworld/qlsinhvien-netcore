using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities;

public class BoMonDto
{
    [MaxValue(1, EGioiHan.MaxBoMon)]
    public int MaBoMon { get; set; }
    [Required]
    public string TenBoMon { get; set; } = null!;
    public ICollection<int>? MaMonHocs { get; set; }
    public ICollection<int>? MaGiangViens { get; set; }
    public ICollection<int>? MaKhoas { get; set; }
}