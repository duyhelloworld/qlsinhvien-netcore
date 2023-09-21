using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IQuyenService
{
    public Task<IEnumerable<QuyenDto>> LayTatCa();
    public Task<IEnumerable<QuyenDto>> LayTheoTen(string TenQuyen);
    public Task<IEnumerable<QuyenDto>> LayTheoNguoiDung(string TenNguoiDung);
    public Task<IEnumerable<QuyenDto>> LayTheoVaiTro(string TenVaiTro);
    // public Task ThemQuyen(QuyenDto quyenDto);
    // public Task CapNhatQuyen(string TenQuyen, QuyenDto quyenDto);
}