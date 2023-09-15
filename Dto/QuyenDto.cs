using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities;

public class QuyenDto
{
    [MinLength(1)]
    public string TenQuyen { get; set; } = null!;

    public string? GhiChu { get; set; }

    public IEnumerable<string>? TenVaiTros { get; set; } = null!;

    public static QuyenDto Convert(Quyen quyen)
    {
        return new QuyenDto()
        {
            TenQuyen = quyen.TenQuyen,
            GhiChu = quyen.GhiChu,
            TenVaiTros = quyen.VaiTros.Select(vt => vt.TenVaiTro)
        };
    }

    public static Quyen Convert(QuyenDto quyenDto)
    {
        return new Quyen()
        {
            TenQuyen = quyenDto.TenQuyen,
            GhiChu = quyenDto.GhiChu
        };
    }
}