using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities;

public class QuyenDto
{
    [Range(1, 100)]
    public int MaQuyen { get; set; }

    public string TenQuyen { get; set; } = null!;

    public string? MoTa { get; set; }
}