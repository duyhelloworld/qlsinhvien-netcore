using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IQuyenService
{
    public Task<IEnumerable<QuyenDto>> LayTatCa();
    public Task<IEnumerable<QuyenDto>> LayTheoTen(string TenQuyen);
    public Task<IEnumerable<QuyenDto>> LayTheoVaiTro(string TenVaiTro);
    public Task<IEnumerable<string>> LayTatCaApiDangDung(string TenQuyen);
    public Task ThemQuyen(QuyenDto quyenDto);
    public Task CapNhatQuyen(string TenQuyen, QuyenDto quyenDto);
}