using qlsinhvien.Entities;

namespace qlsinhvien.Models;

public class QuyenDetail
{
    public string TenNguoiDung { get; set; } = null!;
    public string TenVaiTro { get; set; } = null!;
    public IEnumerable<QuyenDto> Quyens { get; set; } = new HashSet<QuyenDto>();
}