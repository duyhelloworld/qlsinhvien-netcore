using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IQuyenService
{
    public Task<IEnumerable<Quyen>> LayTatCa();
    public Task<Quyen?> LayTheoTen(string TenQuyen);
    public Task ThemQuyen(QuyenDto quyenDto);
    public Task XoaQuyen(string TenQuyen);

}