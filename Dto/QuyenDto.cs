using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities;

public class QuyenDto
{
    [MinLength(1)]
    public string TenQuyen { get; set; } = null!;

    public string? GhiChu { get; set; }
}