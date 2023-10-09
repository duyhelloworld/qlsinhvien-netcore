using qlsinhvien.Entities;
using qlsinhvien.Models;

namespace qlsinhvien.Services;

public interface IQuyenService
{
    public Task<IEnumerable<QuyenDto>> LayTatCa();
    public Task<IEnumerable<QuyenDetail>> LayTheoNguoiDung();
    public Task<IEnumerable<QuyenDto>> LayTheoTen(string TenQuyen);
    public Task<IEnumerable<QuyenDto>> LayTheoTenNguoiDung(string TenNguoiDung);
    public Task<IEnumerable<QuyenDto>> LayTheoVaiTro(string TenVaiTro);
}