using qlsinhvien.Entities.SecurityModels;

namespace qlsinhvien.Services;

public interface ITaiKhoanService
{
    // Luồng đăng nhập
    public Task TaoTaiKhoanTrong(ModelDangKi model);
    public Task PhanVaiTro(string TenNguoiDung, string TenVaiTro);

    public Task<ModelTraVe> DangNhap(ModelDangNhap model);
    public Task DangXuat(string token);
    public Task DangXuat();
}