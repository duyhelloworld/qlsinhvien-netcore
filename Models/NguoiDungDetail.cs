using qlsinhvien.Dtos;

namespace qlsinhvien.Entities;

public class NguoiDungDetail
{
    public string TenVaiTro { get; set; } = null!;
    public string? GhiChuVaiTro { get; set; }
    public IEnumerable<NguoiDungDto> NguoiDungDtos { get; set; } = null!;
}