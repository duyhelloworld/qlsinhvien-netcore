using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace qlsinhvien.Entities;

public class QuyenDto
{
    [MinLength(1)]
    public string TenQuyen { get; set; } = null!;

    public string? GhiChu { get; set; }

    public static QuyenDto Convert(Quyen quyen)
    {
        return new QuyenDto()
        {
            TenQuyen = quyen.TenQuyen,
            GhiChu = quyen.GhiChu,
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