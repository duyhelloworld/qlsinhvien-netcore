using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IQuyenService
{
    public Task<IEnumerable<Quyen>> LayTatCa();
    public Task<Quyen?> LayTheoId(int MaQuyen);
    public Task ThemQuyen(QuyenDto quyenDto);
    public Task XoaQuyen(int MaQuyen);

}